using System;
using UnityEngine;

namespace Script
{
    public class KartMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        private SpriteRenderer _spriteRenderer;
        private void Update()
        {
            if (!_spriteRenderer) _spriteRenderer = GetComponent<SpriteRenderer>();
            
            if (FindObjectOfType<BallMovement>().isOnPlay)
            {
                transform.position += (!_spriteRenderer.flipX ? Vector3.left : Vector3.right) * speed * Time.deltaTime;
            }
        }
    }
}