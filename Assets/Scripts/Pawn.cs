using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    [HideInInspector] public Controller controller;
    public float moveSpeed = 5.0f;
    public abstract void Move(Vector3 moveVector);
    // public abstract void Possess(Controller controller);
    // public abstract void UnPossess();
}
