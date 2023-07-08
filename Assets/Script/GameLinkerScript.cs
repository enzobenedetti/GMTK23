using System;
using UnityEngine;

namespace Script
{
    public class GameLinkerScript : MonoBehaviour
    {
        [HideInInspector]public GameManager gameManager;
        [HideInInspector]public LevelManager levelManager;
        
        
        private void Start()
        {
            gameManager = FindObjectOfType<GameManager>();
            levelManager = FindObjectOfType<LevelManager>();
        }
    }
}