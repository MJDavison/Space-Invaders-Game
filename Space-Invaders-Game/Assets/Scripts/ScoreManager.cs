using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] GameManager myGM;
    [SerializeField] public HighScore highScoreSO;
    
    [SerializeField] int playerOneScore;        

    public int PlayerOneScore { get => playerOneScore; 
    set {
            playerOneScore = value;
            myGM.UIManager.SetPlayerOneScore(playerOneScore);
        }  
    }    
    public bool IsHighScore(){
        if(playerOneScore > highScoreSO.highScore){
            highScoreSO.highScore = playerOneScore;
            return true;

        } else{
            return false;
        }       
    }

    internal void Init()
    {
        GameObject GameController = GameObject.FindGameObjectWithTag("GameController");
        myGM = GameController.GetComponent<GameManager>();
    }
}
