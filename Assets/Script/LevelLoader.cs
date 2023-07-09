using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Script
{
    public class LevelLoader : MonoBehaviour
    {
        public Canvas canvas;

        public Button activeLevelButton;
        public Button inactiveLevelButton;
        public int numberOfLevels;
        public Vector2 topLeft;
        public Vector2 bottomRight;
        public float horizontalSpacing;
        public float verticalSpacing;
        public GameLinkerScript gameLinkerScript;
        

        private List<Button> levelButtons = new List<Button>();
        
        private static readonly int CloseIn = Animator.StringToHash("CloseIn");

        private int _maxUnlockedLevel;

        public void Awake()
        {
            _maxUnlockedLevel = PlayerPrefs.GetInt(LevelManager.LevelsDone, 1);
            GenerateLevelCards();
            print(_maxUnlockedLevel);
        }

        private void GenerateLevelCards()
        {
            var xCounter = 0;
            var yCounter = 0;
            for (var i = 1; i <= numberOfLevels; i++)
            {
                var btnPrefab = i <= _maxUnlockedLevel ? activeLevelButton : inactiveLevelButton;
                var levelBtn = Instantiate(btnPrefab, canvas.transform, false);
                levelBtn.GetComponentInChildren<TextMeshProUGUI>().text = (i).ToString();
                levelBtn.GetComponent<RectTransform>().anchoredPosition = new Vector2(
                    topLeft.x + xCounter * horizontalSpacing,
                    topLeft.y - yCounter * verticalSpacing);
                var l = i;
                // print($"{l}  {_maxUnlockedLevel}");
                levelBtn.onClick.AddListener(() => LoadLevel(l));
                levelButtons.Add(levelBtn);
                xCounter++;
                if (topLeft.x + xCounter * horizontalSpacing > bottomRight.x)
                {
                    xCounter = 0;
                    yCounter++;
                }
            }
        }

        public void LoadMainMenu()
        {
            gameLinkerScript.CallMainMenu();
        }

        private void LoadLevel(int level)
        {
            if (level <= _maxUnlockedLevel)
            {
                gameLinkerScript.LoadLevel(level);
            }
        }
    }
}
