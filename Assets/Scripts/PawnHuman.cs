using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PawnHuman : Pawn
{
    public Animator anim;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // Get the animator component
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Move(Vector3 moveDirection)
    {
        moveDirection = Vector3.ClampMagnitude(moveDirection, 1) * moveSpeed;

        // Set our movement parameters based on our input
        // This blends the correct animation in the animator controller
        anim.SetFloat("Forward", moveDirection.z);
        anim.SetFloat("Right", moveDirection.x);    


    }
}
