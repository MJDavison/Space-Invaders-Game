using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{    
    public GAME_STATE state;
    [Header("Game Borders")]
    Vector2 topLeftCorner = new Vector2(-3.5f, 7f);
    Vector2 bottomRightCorner = new Vector2(4.5f, -0);

    public int level = 1;

    public Vector2 TopLeftCorner { get => topLeftCorner; set => topLeftCorner = value; }
    public Vector2 BottomRightCorner { get => bottomRightCorner; set => bottomRightCorner = value; }
    
    public ScoreManager ScoreManager { get => scoreManager; set => scoreManager = value; }
    public PlayerManager PlayerManager { get => playerManager; set => playerManager = value; }
    public EnemyManager EnemyManager { get => enemyManager; set => enemyManager = value; }
    public UIManager UIManager { get => uiManager; set => uiManager = value; }

    [Header("Management Script References")]
    [SerializeField] static GameManager myGM;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] PlayerManager playerManager;
    [SerializeField] EnemyManager enemyManager;
    [SerializeField] UIManager uiManager;

    [Header("State Parents")]
    [SerializeField] public GameObject menuParent;
    [SerializeField] public GameObject gameParent;
    [SerializeField] public GameObject gameOverParent;
    

    private void Awake() {
        myGM = this.GetComponent<GameManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        gameParent.SetActive(false);
        gameOverParent.SetActive(false);
        state = GAME_STATE.INIT;
    }

    public void StartGame(){
        state=GAME_STATE.GAME;
        menuParent.SetActive(false);
        gameParent.SetActive(true);        
        InitializeManagers();
    }

    private void InitializeManagers()
    {
        scoreManager.Init();
//        playerManager.Init();
        enemyManager.Init();
        uiManager.Init();
    }

    internal void GameOver()
    {
        state = GAME_STATE.OVER;
        gameParent.SetActive(false);
        gameOverParent.SetActive(true);           
        uiManager.GameOverUISetup();     
    }
    
}
