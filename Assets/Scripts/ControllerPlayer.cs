using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerPlayer : Controller
{
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

    public override void Possess(Pawn pawnToPossess)
    {
        pawnToPossess.controller = this;
        pawn = pawnToPossess;
    }

    public override void UnPossess()
    {
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
