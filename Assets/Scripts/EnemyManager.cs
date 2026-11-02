using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public List<EnemyWave> GameWaves;

    public struct EnemySpawn
    {
        public GameObject enemyPrefab;
        public float chanceToSpawn;
    }

    public struct Wave
    {
        public List<EnemySpawn> spawns;        
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy ( GameObject enemyPawnPrefab, Vector3 position, Quaternion rotation, EnemyData data)
    {
        // Spawn a prefab for the enemy at position/rotation
        GameObject newEnemy = Instantiate(enemyPawnPrefab, position, rotation);

        // Get the new enemy pawn
        Pawn newEnemyPawn = newEnemy.GetComponent<Pawn>();

        // Get the enemy health data
        Health enemyHealthComponent = newEnemy.GetComponent<Health>();

        // if the EnemyData was passed in,
        if (data != null)
        {
            // Set the enemy health data
            if (enemyHealthComponent != null)
            {
                enemyHealthComponent.maxHealth = data.maxHealth;
                enemyHealthComponent.currentHealth = data.health;
            }

            // Set the enemy movement data
            if (newEnemyPawn!= null )
            {
                newEnemyPawn.moveSpeed = data.moveSpeed;
                newEnemyPawn.rotationSpeed = data.rotationSpeed;
            }

            // Equip the weapon passed in
            if (data.weapon != null)
            {
                if (newEnemyPawn != null)
                {
                    newEnemyPawn.Equip(data.weapon);
                }
            }
        }

        // Add the enemy controller to the pawn
        ControllerAI newEnemyController = newEnemy.AddComponent<ControllerAI>();
        newEnemyController.Possess(newEnemyPawn);
    }

}

public class EnemyData
{
    public float health;
    public float maxHealth;
    public Weapon weapon;
    public float moveSpeed;
    public float rotationSpeed;
}
