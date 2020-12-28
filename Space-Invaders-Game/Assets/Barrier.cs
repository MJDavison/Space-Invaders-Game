using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] int durability = 5;
    [SerializeField] Color fullDurabilty;
    [SerializeField] Color slightlyDamaged;
    [SerializeField] Color quiteDamaged;
    [SerializeField] Color veryDamaged;
    [SerializeField] Color extremelyDamaged;
    [SerializeField] Color aboutToBreak;
    // Start is called before the first frame update
    void Start()
    {
        CheckDurabilty();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Projectile")){
            durability--;
            CheckDurabilty();
            Destroy(other.gameObject);
        }    
    }

    private void OnCollisionStay2D(Collision2D other) {
        if(other.gameObject.CompareTag("Enemy")){
            durability--;
            CheckDurabilty();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    private void CheckDurabilty(){
        switch(durability){
            case 5:  
                //print("Barrier at full durablity");      
                sprite.color = fullDurabilty;  
                break;      
            case 4:
                //print("Barrier slightly damaged");
                sprite.color = slightlyDamaged;
                break;            
            case 3:
                //print("Barrier quite damaged");
                sprite.color = quiteDamaged;
                break;           
            case 2:
                //print("Barrier very damaged");
                sprite.color = veryDamaged;
                break;            
            case 1:
                //print("Barrier about to break");
                sprite.color = aboutToBreak;
                break;                    
            default:
                //print("Barrier broken");
                sprite.gameObject.SetActive(false);
                break;
        }
    }
}

