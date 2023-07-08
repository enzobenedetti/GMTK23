using System;
using UnityEngine;

namespace Script
{
    public class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            if (FindObjectsByType<GameManager>(FindObjectsSortMode.None).Length > 1)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(transform);
        }

        private void Start()
        {
            Debug.Log("Start on Game Manager");
        }

        public void WinGame()
        {
            //TODO show win UI
        }

        public void LostGame()
        {
            //TODO show lost UI
        }
    }
}