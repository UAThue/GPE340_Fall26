using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    [HideInInspector] public Controller controller;
    [Header("Movement Data")]
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 360;
    [Header("Weapons")]
    public Weapon weapon;
    public abstract void Move(Vector3 moveVector);
    // public abstract void Rotate(float angle);
    public abstract void RotateToLookAt(Vector3 pointToLookAt);

    public abstract void Possess(Controller controllerToPosses);
    public abstract void UnPossess();
}
