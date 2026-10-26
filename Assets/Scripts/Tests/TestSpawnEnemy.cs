using UnityEngine;

public class TestSpawnEnemy : MonoBehaviour
{
    public GameObject AIPawn;
    public Weapon enemyWeaponPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            EnemyData enemyInfo = new EnemyData();
            enemyInfo.maxHealth = 100;
            enemyInfo.health = 1;
            enemyInfo.moveSpeed = 1;
            enemyInfo.rotationSpeed = 360;
            enemyInfo.weapon = enemyWeaponPrefab;

            GameManager.instance.enemyManager.SpawnEnemy(AIPawn, Vector3.zero, Quaternion.identity, enemyInfo);
            
        }
    }
}
