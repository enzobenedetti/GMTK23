using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private MusicManager musicManager;

        public GameObject winCanvas;
        public GameObject lostCanvas;
        private void Awake()
        {
            if (FindObjectsByType<GameManager>(FindObjectsSortMode.None).Length > 1)
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(transform);
            if (!musicManager) musicManager = GetComponent<MusicManager>();
        }

        public void StartGame()
        {
            //TODO player can move
            musicManager.PlayMusicWithTagOnScene();
        }

        public void WinGame()
        {
            //TODO show win UI
            winCanvas.SetActive(true);
            // musicManager.PlayBaseOnly();
        }

        public void LostGame()
        {
            //TODO show lost UI
            lostCanvas.SetActive(true);
            // musicManager.PlayBaseOnly();
        }
    }
}