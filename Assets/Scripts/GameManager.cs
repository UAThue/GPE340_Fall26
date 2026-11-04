using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{


    public static GameManager instance;

    [Header("Enemies and Spawn Points")]
    public EnemyManager enemyManager;
    public List<PawnSpawnPoint> spawnPoints;

    public GameObject playerPawn;
    public bool isPaused = false;
    private float timeScale;
    public float targetTimeScale = 1.0f;
    public float slowMoTransitionTime = 0.4f;

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
        timeScale = Mathf.MoveTowards(timeScale, targetTimeScale, slowMoTransitionTime * Time.deltaTime);
        Time.timeScale = timeScale;
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

    public void SlowMotion ()
    {
        Time.timeScale = 0.4f;
    }

    public void Pause()
    {
        // Set our paused flag
        isPaused = true;

        // Set our animation/framerate 
        Time.timeScale = 0.0f;
    }

    public void Unpause()
    {
        isPaused = false;

        // Set our animation/framerate 
        Time.timeScale = 1.0f;
    }

    public void TogglePause()
    {
        if (isPaused)
        {
            Unpause();
        }
        else
        {
            Pause();
        }
    }


}
