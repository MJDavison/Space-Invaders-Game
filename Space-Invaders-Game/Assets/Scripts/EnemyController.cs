using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float elapsedTime;
    GameManager myGM;
    //Rigidbody2D enemyRB;
    //float enemyMovementSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        myGM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        //enemyRB = GetComponent<Rigidbody2D>();
        
    }

    

    // Update is called once per frame
    void Update()
    {
        //MoveEnemy();
        elapsedTime += Time.deltaTime;
    }
}
