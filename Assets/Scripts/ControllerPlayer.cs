using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerPlayer : Controller
{
    [Header("Data")]
    [SerializeField] private int lives = 3;

    [Header("Key Objects")]
    public Camera playerCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Act based on inputs
        MakeDecisions();
    }

    public void SubtractLife()
    {
        lives--;
    }

    public override void Possess(Pawn pawnToPossess)
    {
        pawnToPossess.controller = this;
        pawn = pawnToPossess;

        // Check if that pawn has a health component
        Health pawnHealth = pawn.GetComponent<Health>();

        // If so, then add "SubtractLife()" to the OnDeath event for that pawn
        if (pawnHealth != null)
        {
            pawnHealth.OnDeath.AddListener(SubtractLife);
        }

    }

    public override void UnPossess()
    {
        // Check if that pawn has a health component
        Health pawnHealth = pawn.GetComponent<Health>();
        // If so, then REMOVE "SubtractLife()" from the OnDeath event for that pawn
        if (pawnHealth != null)
        {
            pawnHealth.OnDeath.RemoveListener(SubtractLife);
        }

        // Disconnect the pawn
        pawn.controller = null;
        pawn = null;
    }

    public override void MakeDecisions()
    {
        // Get the move vector of our axes
        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Tell our pawn to move
        pawn.Move(moveVector);

        // Find the point on the "foot plane" that the mouse is overlapping, and rotate towards it
        Plane footPlane;
        footPlane = new Plane(Vector3.up, pawn.transform.position);

        Ray mouseRay;
        mouseRay = playerCamera.ScreenPointToRay(Input.mousePosition);

        float hitDistance;
        if (footPlane.Raycast(mouseRay, out hitDistance))
        {
            // If we hit the plane
            Vector3 raycastHitPoint = mouseRay.GetPoint(hitDistance);

            // Rotate to look at that point
            pawn.RotateToLookAt(raycastHitPoint);
        }
        else
        {
            // We didn't hit the plane
            // DO NOTHING
        }


    }
}
