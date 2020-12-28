using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] EnemyManager EnemyManager;
    [SerializeField] int enemiesPerLayer;
    [SerializeField] int numOfLayers;
    [ReadOnly] [SerializeField] int numOfEnemies;    
    [ReadOnly] [SerializeField] Vector3 positionToSpawn;
    [SerializeField] Vector3 startingPosition;
    [SerializeField] Transform enemyParent;
    [SerializeField] GameManager myGM;
    [SerializeField] GameObject enemy;

    [SerializeField] GameObject[] enemyPrefabs; // 3 normal, 1 mysterious for a total of 4.

    private void Awake()
    {        
        numOfEnemies = enemiesPerLayer * numOfLayers;            
    }

    public void SpawnMysteriousShip(){
        GameObject mysteriousShip = Instantiate(enemyPrefabs[3]);
        mysteriousShip.transform.SetParent(gameObject.transform.parent.transform); //The parent of the parent transform, so the game parent.        
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    public void SpawnEnemies(){
        positionToSpawn = startingPosition;
        int enemyID = 0;
        int enemyToSpawn = 0;
        for (int i = 0; i < numOfLayers; i++)
        {
            for (int j = 1; j <= enemiesPerLayer; j++)
            {
                enemyID++;
                if (i == 0){
                    enemyToSpawn = 2;
                }
                else if (i == 1){
                    enemyToSpawn = 1;
                }else if (i == 3){
                    enemyToSpawn = 0;
                }          
                enemy = Instantiate(enemyPrefabs[enemyToSpawn],positionToSpawn, enemyPrefabs[enemyToSpawn].transform.rotation);                                        
                enemy.transform.parent = enemyParent;
                enemy.GetComponent<Enemy>().Layer = i;
                enemy.name = "Enemy ID: "+enemyID;
                EnemyManager.AllEnemiesArray.Add(enemy);
                
                
                positionToSpawn = new Vector3(positionToSpawn.x + 0.8f, positionToSpawn.y, positionToSpawn.z);
            }
            positionToSpawn = new Vector3(startingPosition.x, positionToSpawn.y-0.8f, positionToSpawn.z);
        }
    }

       
}
