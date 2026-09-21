using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    public Pawn pawn;
    public abstract void MakeDecisions();
    // public abstract void Possess (Pawn pawnToPossess);
    // public abstract void UnPossess (Pawn pawnToPossess);
}
