using UnityEngine;
using System.Collections;

public class DelegateHandler : MonoBehaviour{
    public delegate void CheckEnemyStatusDelegate(GameObject[] bottomLayer);
    public static CheckEnemyStatusDelegate checkEnemyStatusDelegate;

    public void CheckEnemyStatus(GameObject[] bottomLayer){
        checkEnemyStatusDelegate(bottomLayer);
    }
}