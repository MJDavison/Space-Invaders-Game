using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{    
    
    [SerializeField] public GameManager myGM;
    [SerializeField] EnemySpawner spawner;

    [SerializeField] List<GameObject> bottomLayerEnemiesArray;
    [SerializeField] List<GameObject> allEnemiesArray;

    public List<GameObject> AllEnemiesArray { get => allEnemiesArray; set => allEnemiesArray = value; }
    
    private void OnEnable() {
        bottomLayerEnemiesArray = new List<GameObject>(11);;
        AllEnemiesArray = new List<GameObject>();   
    }


    private void Update() {
        if(allEnemiesArray.Count == 0){
            myGM.level++;
            myGM.UIManager.UpdateLevelText(myGM.level);            
            spawner.SpawnEnemies();
        }
    }
    

    public void AddToBottonLayerArray(GameObject enemy){
        if(!bottomLayerEnemiesArray.Contains(enemy)){
            bottomLayerEnemiesArray.Add(enemy);
        }
        
    }

    public void RemoveFromBottomLayerArray(GameObject enemy){
        if(bottomLayerEnemiesArray.Contains(enemy)){
            bottomLayerEnemiesArray.Remove(enemy);
        }
        
    }

    public void ChooseEnemyToFire(){        
        if(bottomLayerEnemiesArray.Count > 0) {
            int enemyInArray = UnityEngine.Random.Range(0,bottomLayerEnemiesArray.Count-1);
            bottomLayerEnemiesArray[enemyInArray].GetComponent<Enemy>().Shoot();
        }
    }

    internal void Init()
    {
        InvokeRepeating("ChooseEnemyToFire",5,2);
        spawner.InvokeRepeating("SpawnMysteriousShip",10,100);
    }
}
