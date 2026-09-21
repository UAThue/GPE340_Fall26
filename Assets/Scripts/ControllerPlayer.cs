using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerPlayer : Controller
{
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

    public override void MakeDecisions()
    {
        // Get the move vector of our axes
        Vector3 moveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //TODO: Tell pawn to rotate based on X

        //TODO: Tell pawn to move based on inputs
        // Tell our pawn to move
        pawn.Move(moveVector);
    }
}
