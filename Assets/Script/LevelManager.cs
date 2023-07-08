using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class LevelManager : MonoBehaviour
    {
        /// <summary>
        /// Load the next level
        /// </summary>
        public void StartNextLevel()
        {
            UpdateLevelsUnlocked();
            if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            else SceneManager.LoadScene(0);
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene(0);
        }

        private void UpdateLevelsUnlocked()
        {
            PlayerPrefs.SetInt("LevelsDone", SceneManager.GetActiveScene().buildIndex);
        }
    }
}
