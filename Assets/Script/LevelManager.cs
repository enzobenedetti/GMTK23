using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class LevelManager : MonoBehaviour
    {
        /// <summary>
        /// Load a level, you can also reload a level from here
        /// </summary>
        /// <param name="level">Set here the level numbers</param>
        public void StartLevel(int level)
        {
            SceneManager.LoadScene(level);
        }

        public void GoToMainMenu()
        {
            SceneManager.LoadScene(0);
        }
    }
}
