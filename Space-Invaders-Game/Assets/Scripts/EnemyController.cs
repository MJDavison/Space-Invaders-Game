using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] EnemyManager EnemyManager;    
    
    GameManager myGM;
    
    [SerializeField] float directionToMove = 0.1f;    

    GameObject GameController;

    
    [SerializeField] int timeUntilMovement = 1;
    [SerializeField] int howOftenToMove = 5;

    [SerializeField] float minX = 3.5f; //-7.75f;
    [SerializeField] float maxX = 4.5f; //7.75f;
    

    //Rigidbody2D enemyRB;
    //float enemyMovementSpeed = 1;
    // Start is called before the first frame update
    private void OnEnable() {        
        GameController = GameObject.FindGameObjectWithTag("GameController");
        EnemyManager = GameController.GetComponent<EnemyManager>();        
        myGM = GameController.GetComponent<GameManager>();        
        StartCoroutine(MoveEnemy(gameObject.transform,timeUntilMovement,howOftenToMove));        
    }

    



    
    
    public IEnumerator MoveEnemy(Transform enemyToMove, int timerToStart, int timerToRepeat ){
        yield return new WaitForSeconds(timerToStart);
        if(Mathf.Approximately(transform.position.x, maxX)||Mathf.Approximately(transform.position.x, minX)){
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
        StartCoroutine(MoveEnemy(transform,timeUntilMovement,howOftenToMove));
        
    } 


    

}
