using System;
using UnityEngine;

namespace Script
{
    /// <summary>
    /// As the GameManager in scene will be overrided by the one already there,
    /// This script has the purpose to make the link between the gameManager in DontDestoryOnLoad
    /// and other Gameobject only in one Scene
    /// </summary>
    public class GameLinkerScript : MonoBehaviour
    {
        [HideInInspector]
        public GameManager gameManager;
        [HideInInspector]public LevelManager levelManager;

        public GameObject winCanvas;
        public GameObject lostCanvas;
        public Animator curtain;
        
        
        private void Start()
        {
            gameManager = FindObjectOfType<GameManager>();
            levelManager = FindObjectOfType<LevelManager>();
        }

        public void CallNextLevel()
        {
            levelManager.StartNextLevel();
        }

        public void CallRestartLevel()
        {
            levelManager.RestartLevel();
        }

        public void CallMainMenu()
        {
            levelManager.GoToMainMenu();
        }
    }
}