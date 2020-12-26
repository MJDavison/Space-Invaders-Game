using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{    
    [Header("Game Borders")]
    Vector2 topLeftCorner = new Vector2(-3.5f, 8f);
    Vector2 bottomRightCorner = new Vector2(4.5f, -0);

    public Vector2 TopLeftCorner { get => topLeftCorner; set => topLeftCorner = value; }
    public Vector2 BottomRightCorner { get => bottomRightCorner; set => bottomRightCorner = value; }

    // Start is called before the first frame update
    void Start()
    {
        // print("Top Left Corner: " + topLeftCorner + " Top Right Corner: ("+bottomRightCorner.x+", "+topLeftCorner.y+")");
        // print("Bottom Left Corner: (" + topLeftCorner.x +", " + bottomRightCorner.y + ") Bottom Right Corner: "+bottomRightCorner);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
