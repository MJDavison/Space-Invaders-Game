using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //GameObject[,] enemies;
    [SerializeField] GameObject[,] enemies;
    [SerializeField] int enemiesPerLayer;
    [SerializeField] int numOfLayers;

    private void Awake() {
        enemies = new GameObject[enemiesPerLayer,numOfLayers];
        
    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject test = new GameObject();
        enemies[0,0] = test; //This would be the enemy on the top layer, furthest left.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
