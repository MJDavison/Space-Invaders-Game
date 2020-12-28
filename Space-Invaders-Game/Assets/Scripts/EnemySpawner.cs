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

    [SerializeField] GameObject[] enemyPrefabs; // 3 normal, 1 fly over for a total of 4.

    private void Awake()
    {        
        numOfEnemies = enemiesPerLayer * numOfLayers;
        //startingPosition = new Vector3(-2.5f, 7.5f, 0f);
        positionToSpawn = startingPosition;
    }
    // Start is called before the first frame update
    void Start()
    {
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



        InvokeRepeating("MoveEnemy", 5, 2);
    }
    float directionToMove = 0.1f;    
    public void MoveEnemy(){
        
        if(Mathf.Approximately(transform.position.x, 4.5f)||Mathf.Approximately(transform.position.x, 3.5f)){
            //(float)transform.position.x == (float)myGM.BottomRightCorner.x
            if(directionToMove.Equals(0.1f)){
                directionToMove = -0.1f;                
                //print("Direction To Move Changed");
            } else{
                directionToMove = 0.1f;
                //print("Direction To Move Changed");            
            }            
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
        }
        
        
        
        //print(Math.Round(transform.position.x, 15).ToString());        
        transform.Translate(new Vector2(directionToMove, 0));
        //print("Direction To Move:" + directionToMove);
        //enemyRB.velocity = Vector2.right * directionToMove * enemyMovementSpeed;
        
    }    
}
