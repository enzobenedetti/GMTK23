using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Animator curtainAnimator;
        [SerializeField] private float animationDelay;
        private static readonly int Close = Animator.StringToHash("Close");

        /// <summary>
        /// Load the next level
        /// </summary>
        public void StartNextLevel()
        {
            UpdateLevelsUnlocked();
            if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings -1)
                LoadSceneWithAnimation(SceneManager.GetActiveScene().buildIndex + 1);
            else LoadSceneWithAnimation(0);
        }

        public void RestartLevel()
        {
            LoadSceneWithAnimation(SceneManager.GetActiveScene().buildIndex);
        }

        public void GoToMainMenu()
        {
            LoadSceneWithAnimation(0);
        }

        private void UpdateLevelsUnlocked()
        {
            PlayerPrefs.SetInt("LevelsDone", SceneManager.GetActiveScene().buildIndex);
        }

        private void LoadSceneWithAnimation(int index)
        {
            if (FindObjectOfType<GameLinkerScript>())
                FindObjectOfType<GameLinkerScript>().curtain.SetTrigger(Close);
            else curtainAnimator.SetTrigger(Close);
            StartCoroutine(LoadSceneWithDelay(index, animationDelay));
        }

        private static IEnumerator LoadSceneWithDelay(int index, float delay)
        {
            yield return new WaitForSeconds(delay);
            SceneManager.LoadScene(index);
        }
    }
}
