using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace MJDeveloping.Unity.Games.Space_Invader_Game
{
    public class PlayerController : MonoBehaviour
    {
        [ReadOnly][SerializeField] Rigidbody2D myRB;
        [ReadOnly][SerializeField] GameManager myGM;

        [SerializeField] float playerMovementSpeed;
        [SerializeField] GameObject projectilePrefab;
        [SerializeField] float shotPosition = 0.5f;
        // Start is called before the first frame update
        void Start()
        {
            myRB = GetComponent<Rigidbody2D>();
            myGM = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnMove(InputValue value){
            float horizontalInput = value.Get<float>();
            
            //Debug.Log("Move " + horizontalInput);
            myRB.velocity = Vector2.right * horizontalInput * playerMovementSpeed;
        }

        public void OnFire(){
            //Debug.Log("Fire");
            GameObject projectile = Instantiate(projectilePrefab,new Vector2(transform.position.x, transform.position.y + shotPosition),transform.rotation);
            projectile.GetComponent<Rigidbody2D>().velocity = Vector2.up * 5;
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if(other.CompareTag("Projectile")){
                Destroy(other.gameObject);
                Destroy(gameObject);
                myGM.PlayerManager.RespawnPlayer();
            }
        }
    }
}
