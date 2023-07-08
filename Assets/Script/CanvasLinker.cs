using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class CanvasLinker : MonoBehaviour
    {
        [SerializeField] private GameObject winCanvas;
        [SerializeField] private GameObject lostCanvas;

        private void OnEnable()
        {
            SceneManager.sceneLoaded += FindNewCanvasReferences;
        }

        private void OnDisable()
        {
            SceneManager.sceneLoaded -= FindNewCanvasReferences;
        }


        private void FindNewCanvasReferences(Scene scene, LoadSceneMode mode)
        {
            // Because canvas do not persist between scenes, we need to find their reference dynamically
            print("Finding new canvas references");
            var gameManager = FindObjectOfType<GameManager>();
            gameManager.winCanvas = winCanvas;
            gameManager.lostCanvas = lostCanvas;
        }
    }
}
