using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{


    public static GameManager instance;

    [Header("Enemies and Spawn Points")]
    public EnemyManager enemyManager;
    public List<PawnSpawnPoint> spawnPoints;

    public GameObject playerPawn;

    private void Awake()
    {
        instance = this;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      




    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public void DoStuff()
    {
        if (spawnPoints[0].type == PawnSpawnPoint.SpawnPointType.Enemy)
        {
            // Spawn enemy
        }

    }

}
