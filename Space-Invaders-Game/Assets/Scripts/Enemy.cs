using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class Enemy : MonoBehaviour
{    
    [SerializeField] EnemyManager EnemyManager;
    [SerializeField] int layer;    
    [SerializeField] int pointWorth;

    Ray2D ray;
    RaycastHit2D hit;
    [SerializeField] bool lowestEnemyInLane;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] bool isMysteriousShip;
    float elapsedTime;
    float shotCoolDown;

    private void Awake() {
        EnemyManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemyManager>();
    }

    public Enemy(int layer)
    {                        
        this.Layer = layer;        
    }

    public int Layer { get => layer; set => layer = value; }
    public int PointWorth { get => pointWorth; set => pointWorth = value; }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            Destroy(gameObject);
            EnemyManager.RemoveFromBottomLayerArray(gameObject);
            EnemyManager.AllEnemiesArray.Remove(gameObject);
            EnemyManager.myGM.ScoreManager.PlayerOneScore += PointWorth;
            Destroy(other.gameObject);
            //Add score etc...
        }
    }
    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (!isMysteriousShip)
        {
            shotCoolDown -= Time.deltaTime;

            hit = Physics2D.Raycast(transform.position, -Vector2.up);


            if (hit.collider != null)
            {
                if (!hit.collider.CompareTag("Enemy"))
                {
                    lowestEnemyInLane = true;
                }
            }
            else
            {
                lowestEnemyInLane = true;
            }

            if (lowestEnemyInLane)
            {
                EnemyManager.AddToBottonLayerArray(gameObject);
            }
        }               
    }

    public void Shoot()
    {

        GameObject projectile = Instantiate(projectilePrefab, new Vector2(transform.position.x, transform.position.y - 0.3f), projectilePrefab.transform.rotation);
        projectile.GetComponent<Rigidbody2D>().velocity = Vector2.down * 5;

    }
}
