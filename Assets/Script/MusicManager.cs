using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Script
{
    public class MusicManager : MonoBehaviour
    {
        [SerializeField] private List<AudioSource> scores;

        public void PlayMusicWithTagOnScene()
        {
            foreach (AudioSource audio in scores)
            {
                if (audio == scores[0]) continue;
                if (GameObject.FindWithTag(audio.name))
                {
                    audio.DOFade(1f, 1f);
                }
                else
                {
                    audio.DOFade(0f, 1f);
                }
            }
        }

        public void PlayBaseOnly()
        {
            foreach (AudioSource audio in scores)
            {
                if (audio == scores[0]) continue;
                audio.DOFade(0f, 1f);
            }
        }
    }
}