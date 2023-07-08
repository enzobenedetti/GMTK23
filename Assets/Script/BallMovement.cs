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
        private bool _onGround = true;
        [SerializeField] private ParticleSystem touchGround;

        [SerializeField] private float totalTimeOnPlay;
        private float _actualTime;
        public bool isOnPlay;

        void Update()
        {
            if (Input.GetButtonDown("Jump") && !isOnPlay)
            {
                isOnPlay = true;
            }

            if (isOnPlay && _actualTime <= totalTimeOnPlay)
            {
                _actualTime += Time.deltaTime;
                
                //Update ball position
                transform.position = new Vector3(moveX.Evaluate(_actualTime), moveY.Evaluate(_actualTime), 0);
                Debug.Log(moveX.Evaluate(_actualTime));
                
                ballSprite.localPosition = Vector3.up * moveZ.Evaluate(_actualTime) + Vector3.up * 0.1f;
                ballSprite.localScale = Vector3.one * (moveZ.Evaluate(_actualTime) * scaleInfluence + 1f);

                if (moveZ.Evaluate(_actualTime) <= .5f && !_onGround)
                {
                    _onGround = true;
                    touchGround.Play();
                    //TODO check if win here
                }else if (moveZ.Evaluate(_actualTime) > .5f && _onGround)
                {
                    _onGround = false;
                }
            }
        }
    }
}
