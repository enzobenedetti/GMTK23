using System;
using UnityEngine;

namespace Script
{
    public class BallMovement : MonoBehaviour
    {
        
        [SerializeField]
        private AnimationCurve moveX;
        [SerializeField]
        private AnimationCurve moveY;
        
        //Only used for checking particle start and if ball can enter the hole
        [SerializeField]
        private AnimationCurve moveZ;
        [SerializeField] private Transform ballSprite;
        [SerializeField][Range(0f, 1f)] private float scaleInfluence = 0.5f;
        [SerializeField] private float heightInfluence = 2f;
        [HideInInspector]public bool onGround = true;
        [SerializeField] private ParticleSystem touchGround;
        [SerializeField] private AudioSource groundSound;

        [SerializeField] private float totalTimeOnPlay;
        private float _actualTime;
        private bool _isOnPlay;
        [SerializeField] private bool inWaterAtTheEnd;
        private bool _gameEnded;
        public bool isOnPlay;
        [SerializeField] private AudioSource ballKicked;

        [SerializeField] private Transform character;

        void Update()
        {
            if (Input.GetButtonDown("Jump") && !isOnPlay)
            {
                isOnPlay = true;
                ballKicked.Play();
                character.GetComponent<Animator>().SetTrigger("Shoot");
                character.parent = null;
                FindObjectOfType<GameManager>().StartGame();
            }

            if (isOnPlay && _actualTime <= totalTimeOnPlay)
            {
                _actualTime += Time.deltaTime;
                
                //Update ball position
                transform.position = new Vector3(moveX.Evaluate(_actualTime), moveY.Evaluate(_actualTime), 0);
                Debug.Log(moveX.Evaluate(_actualTime));
                
                ballSprite.localPosition = Vector3.up * moveZ.Evaluate(_actualTime) * heightInfluence + Vector3.up * 0.1f;
                ballSprite.localScale = Vector3.one * (moveZ.Evaluate(_actualTime) * scaleInfluence + 1f);

                if (moveZ.Evaluate(_actualTime) <= .5f && !onGround)
                {
                    onGround = true;
                    touchGround.Play();
                    groundSound.PlayOneShot(groundSound.clip);
                    //TODO check if win here
                }else if (moveZ.Evaluate(_actualTime) > .5f && onGround)
                {
                    onGround = false;
                }
            }

            if (_actualTime >= totalTimeOnPlay && !_gameEnded)
            {
                isOnPlay = false;
                if (inWaterAtTheEnd)
                {
                    GetComponent<SpriteRenderer>().enabled = false;
                    ballSprite.GetComponent<SpriteRenderer>().enabled = false;
                    //TODO Play water particle
                }
                _gameEnded = true;
                FindObjectOfType<GameManager>().LostGame();
            }
        }
    }
}
