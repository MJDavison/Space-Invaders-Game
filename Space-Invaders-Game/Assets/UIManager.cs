using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameManager myGM;

    [SerializeField] Text highScoreText;
    [SerializeField] Text playerOneScoreText;    
    [SerializeField] Text playerLivesText;
    [SerializeField] Text levelText;
    [SerializeField] GameObject playerHealthSpriteParent;
    [SerializeField] GameObject playerSpritePrefab;
    List<GameObject> playerHealthSprites;

    [Header("GameOver UI")]
    [SerializeField] Text newHighScoreText;
    [SerializeField] Text scoreText;
    [SerializeField] bool newHighScore;

    public void SetPlayerOneScore(int playerOneScore){
        playerOneScoreText.text = playerOneScore.ToString();
    }
 
    public void UpdateHighScore(int highScore){        
        highScoreText.text = highScore.ToString();
    }

    public void UpdatePlayerLivesText(int lives){
        playerLivesText.text = lives.ToString();
    }

    public void UpdateLevelText(int level){
        levelText.text = level.ToString();
    }

    public void UpdateLivesSpriteCount(int numOfSprites){
        List<GameObject> livesSprites = new List<GameObject>();
        livesSprites.AddRange(GameObject.FindGameObjectsWithTag("PlayerLifeSprite"));

        foreach (GameObject child in livesSprites)
        {
            Destroy(child);
        }
        
        for(int i = 0; i< numOfSprites; i++){
            GameObject playerSprite;
            playerSprite = Instantiate(playerSpritePrefab, playerHealthSpriteParent.transform.position,playerHealthSpriteParent.transform.rotation);
            playerSprite.transform.SetParent(playerHealthSpriteParent.transform);
        }
        UpdatePlayerLivesText(numOfSprites+1);
    }

    public void GameOverUISetup(){
        if(myGM.ScoreManager.IsHighScore() == true){
            newHighScoreText.gameObject.SetActive(true);            
            newHighScoreText.text = "High Score! \n" + myGM.ScoreManager.highScoreSO.highScore.ToString();
        }
        scoreText.text = "Score: \n" + myGM.ScoreManager.PlayerOneScore.ToString();
    }

    internal void Init()
    {
        UpdateLivesSpriteCount(myGM.PlayerManager.Lives-1);
    }
}
