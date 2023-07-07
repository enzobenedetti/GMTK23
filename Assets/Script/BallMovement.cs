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

        [SerializeField] private float totalTimeOnPlay;
        private float _actualTime;
        private bool _isOnPlay;

        void Update()
        {
            if (Input.GetButtonDown("Jump") && !_isOnPlay)
            {
                _isOnPlay = true;
            }

            if (_isOnPlay)
            {
                _actualTime += Time.deltaTime;
                transform.position = new Vector3(moveX.Evaluate(_actualTime), moveY.Evaluate(_actualTime), 0);
            }
        }
    }
}
