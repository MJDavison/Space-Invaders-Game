using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    float elapsedTime;
    GameManager myGM;
    Ray2D ray;
    RaycastHit2D hit;
    [SerializeField] bool lowestEnemyInLane;
    [SerializeField] GameObject projectilePrefab;

    float shotCoolDown;

    //Rigidbody2D enemyRB;
    //float enemyMovementSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        myGM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();                        
    }

    

    // Update is called once per frame
    void Update()
    {    
        elapsedTime += Time.deltaTime;
        shotCoolDown -= Time.deltaTime;
        hit = Physics2D.Raycast(transform.position, -Vector2.up);
        

        if(hit.collider != null){
            if(!hit.collider.CompareTag("Enemy")){
                lowestEnemyInLane = true;
            }      
        }else{
            lowestEnemyInLane = true;
        }
        
        if(lowestEnemyInLane){
            //print("I am the lowest!" + transform.name);
        }
        
    }

    private void LateUpdate() {
        int valueToFire = 5;
        if(lowestEnemyInLane && shotCoolDown <= 0){
            if(Random.Range(0,11) == valueToFire){
                Shoot();
            }
            //Can shoot, so shoot every few seconds.            
        }
    }

    private void Shoot(){        
        GameObject projectile =  Instantiate(projectilePrefab, new Vector2(transform.position.x, transform.position.y - 0.3f), projectilePrefab.transform.rotation);
        projectile.GetComponent<Rigidbody2D>().velocity = Vector2.down * 5;
        shotCoolDown = 5;
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Projectile")){
            Destroy(gameObject);
            Destroy(other.gameObject);
            //Add score etc...
        }
    }

}
