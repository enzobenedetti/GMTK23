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

        public GameObject winCanvas;
        public GameObject lostCanvas;
        public Animator curtain;

        public void CallNextLevel()
        {
            FindObjectOfType<LevelManager>().StartNextLevel();
        }
        
        public void LoadLevel(int index)
        {
            FindObjectOfType<LevelManager>().LoadLevel(index);
        }

        public void CallRestartLevel()
        {
            FindObjectOfType<LevelManager>().RestartLevel();
        }

        public void CallMainMenu()
        {
            FindObjectOfType<LevelManager>().GoToMainMenu();
        }

        public void CallLevelsMenu()
        {
            FindObjectOfType<LevelManager>().GoToLevelsMenu();
        }
    }
}