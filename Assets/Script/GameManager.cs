using System;
using UnityEngine;

namespace Script
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private MusicManager musicManager;
        
        private void Awake()
        {
            if (FindObjectsByType<GameManager>(FindObjectsSortMode.None).Length > 1)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(transform);
        }

        public void StartGame()
        {
            //TODO player can move
            musicManager.PlayMusicWithTagOnScene();
        }

        public void WinGame()
        {
            //TODO show win UI
            musicManager.PlayBaseOnly();
        }

        public void LostGame()
        {
            //TODO show lost UI
            musicManager.PlayBaseOnly();
        }
    }
}