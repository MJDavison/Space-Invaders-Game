using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] int lives;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] Sprite playerSprite;
    [SerializeField] GameManager myGM;
    

    public int Lives { get => lives; set => lives = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        if(lives > 0){        
            GameObject player = Instantiate(playerPrefab, Vector2.zero, Quaternion.identity);
            player.transform.SetParent(myGM.gameParent.transform);
            lives--;
            myGM.UIManager.UpdateLivesSpriteCount(lives);
        } else{
            myGM.GameOver();
        }

    }
}
