using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControllerAI : Controller
{
    [HideInInspector] public NavMeshAgent agent;
    public float stoppingDistance;
    public Transform targetTransform;
    public float viewAngle;
    public float shootDistance;
    private Vector3 desiredVelocity = Vector3.zero;


    // Start is called before the first frame update
    protected void Start()
    {
    }

    // Update is called once per frame
    public void Update()
    {
        // Act based on inputs
        MakeDecisions();
    }


    public override void Possess(Pawn pawnToPossess)
    {
        // Set the cotnroller and pawn variables
        pawnToPossess.controller = this;
        pawn = pawnToPossess;

        // Get the agent off the pawn
        agent = pawn.GetComponent<NavMeshAgent>();

        // If it doesn't have one, add one and store it
        if (agent == null)
        {
            agent = pawn.gameObject.AddComponent<NavMeshAgent>();
        }

        // Set the stopping distance
        agent.stoppingDistance = stoppingDistance;

        // Set the max speed of the AI from the pawn data
        agent.speed = pawn.moveSpeed;

        // Set the max rotation speed of the AI from the pawn data
        agent.angularSpeed = pawn.rotationSpeed;

        // Disable movement and rotation from the NavMeshAgent
        agent.updatePosition = false;
        agent.updateRotation = false;
    }

    public override void UnPossess()
    {
        // Remove the NavMeshAgent
        Destroy(agent);

        // Set the variables (from the base class's definition)
        pawn.controller = null;
        pawn = null;
    }


    public void SeekTarget ()
    {
        // Set our NavMeshAgent to seek our target
        agent.SetDestination(targetTransform.position);

        // Find the velocity that the agent wants to move in order to follow the path
        desiredVelocity = agent.desiredVelocity;

        // Send the direction in to our Move function (use the move function to add speed)
        pawn.Move(desiredVelocity.normalized);

        // Look towards the player
        pawn.RotateToLookAt(targetTransform.position);
    }

    public void FindTarget()
    {
        // Otherwise
        // Find the first player controller we can find
        ControllerPlayer player = FindFirstObjectByType<ControllerPlayer>();

        // If that controller exists and it has a pawn, set it as the target
        if (player != null && player.pawn != null)
        {
            targetTransform = player.pawn.transform;
        }
    }

    public override void MakeDecisions()
    {
        // If we don't have a pawn, we can't make decisions for it, so do nothing
        if (pawn == null)
        {
            return;
        }

        // If we have a target -- seek it
        if (targetTransform != null)
        {
            SeekTarget();
            TryShoot();

        } 
        else
        {
            FindTarget();
        }
    }

    public virtual void TryShoot()
    {
        // If we are close enough to the player, start shooting
        if (Vector3.Distance(pawn.transform.position, targetTransform.position) <= shootDistance)
        {
            // If they are in the view angle
            Vector3 vectorToTarget = targetTransform.position - pawn.transform.position;
            float angleToTarget = Vector3.Angle(pawn.transform.forward, vectorToTarget);
            if ( angleToTarget <= viewAngle )
            {
                // Start shooting
                pawn.weapon.PrimaryFireStart();
            }

        } else
        {
            // We are too far from the player, stop shooting
            pawn.weapon.PrimaryFireEnd();
        }

    }
}