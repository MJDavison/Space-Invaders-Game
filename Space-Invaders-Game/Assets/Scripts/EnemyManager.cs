using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{    
    
    [SerializeField] GameManager myGM;

    [SerializeField] List<GameObject> bottomLayerEnemiesArray;
    [SerializeField] List<GameObject> allEnemiesArray;

    public List<GameObject> AllEnemiesArray { get => allEnemiesArray; set => allEnemiesArray = value; }
    
    private void Awake() {
        bottomLayerEnemiesArray = new List<GameObject>(11);;
        AllEnemiesArray = new List<GameObject>();        
        
    }

    private void Update() {
        if(allEnemiesArray.Count == 0){
            myGM.GameOver();
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {            
        if(myGM.state == GAME_STATE.GAME){  
            InvokeRepeating("ChooseEnemyToFire",5,2);
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
            int enemyInArray = Random.Range(0,bottomLayerEnemiesArray.Count-1);
            bottomLayerEnemiesArray[enemyInArray].GetComponent<EnemyController>().Shoot();
        }
    }


}
