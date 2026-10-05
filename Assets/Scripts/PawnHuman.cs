using UnityEngine;
using UnityEngine.InputSystem.XR;

[RequireComponent(typeof(Animator))]
public class PawnHuman : Pawn
{
    private Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the animator component
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Possess(Controller controllerToPosses)
    {
        controller.pawn = this;
        controller = controllerToPosses;
    }

    public override void UnPossess()
    {
        // Drop our controller (and have our controller drop this pawn)
        controller.pawn = null;
        controller = null;
    }


    public override void Move(Vector3 moveDirection)
    {
        // Clamp our move direction to prevent moving in 1,1 (or greater) direction
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1);
        
        // Extend the movement vector to include our move speed
        moveDirection *= moveSpeed;

        // Set our movement parameters based on our input
        // This blends the correct animation in the animator controller

        /**** VERSION 1 - this is "Local Movement" (character moves forward/backward/left/right) ****/
        //anim.SetFloat("Forward", moveDirection.z);
        //anim.SetFloat("Right", moveDirection.x);    

        /**** VERSION 2 - goal is "World Movement" (character moves N,S,E,W)   */
        // Use "moveDirection" (input) as a WORLD direction to move! Covert that to find out the local direction we need to pass to animator.
        moveDirection = transform.InverseTransformDirection(moveDirection);
        animator.SetFloat("Forward", moveDirection.z);
        animator.SetFloat("Right", moveDirection.x);
    }

    public override void RotateToLookAt( Vector3 pointToLookAt )
    {
        {
            // Find the vector from our position to the target point
            Vector3 lookVector = pointToLookAt - transform.position;

            // Find the rotation that will look down that vector with world up being the up direction
            Quaternion lookRotation = Quaternion.LookRotation(lookVector, Vector3.up);

            // Rotate slightly towards that target rotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
    }

    public void OnAnimatorMove()
    {
        // After the animation runs
        // Use root motion to move the game object
        transform.position = animator.rootPosition;
        transform.rotation = animator.rootRotation;

        // If we have a NavMeshAgent on our controller,
        ControllerAI aiController = controller as ControllerAI;
        if (aiController != null)
        {
            // Set our navMeshAgent to understand it is as the position from the animator
            aiController.agent.nextPosition = animator.rootPosition;
        }
    }
}
