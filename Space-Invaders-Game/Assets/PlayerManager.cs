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

    // internal void Init()
    // {
    //     throw new NotImplementedException();
    // }
}
