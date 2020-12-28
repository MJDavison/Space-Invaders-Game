// ----------------------------------------------------------------------------
// Author: MJDeveloping
// Portfolio: https://mjdeveloping.github.io/ 
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HighScore", menuName = "HighScore")]
[Serializable]
public class HighScore : ScriptableObject
{
    [SerializeField] public int highScore;
}
