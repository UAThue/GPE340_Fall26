using UnityEngine;

public class TestSpawnEnemy : MonoBehaviour
{
    public GameObject AIPawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            GameObject temp = Instantiate<GameObject>(AIPawn, Vector3.zero, Quaternion.identity);
            Pawn thePawn = temp.GetComponent<Pawn>();
            ControllerAI ai = temp.AddComponent<ControllerAI>();
            ai.Possess(thePawn);
            ai.targetTransform = GameManager.instance.playerPawn.transform;     
        }
    }
}
