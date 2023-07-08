using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float minBallHitSpeed;
    [SerializeField] private float maxBallHitSpeed;
    [SerializeField] private float upSpeed;
    [SerializeField] private float frictionCoefficient;
    [SerializeField] private float dragCoefficient;


    private Rigidbody2D _rigidbody2D;
    private Arrow _arrow;
    const float Gravity = 9.8f;
    private float _upSpeed = 0.0f;
    private float _height = 0.0f;
    private float _decelarationFriction = 0.0f;
    private float _timeSinceShot = 0.0f;
    private bool _isBallShot = false;
    
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _arrow = arrow.GetComponent<Arrow>();
        _decelarationFriction = frictionCoefficient * Gravity;
    }


    private void Update()
    {
        // Input is only for developement and testing purpose. This piece of code will be called by the game manager
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchBall();
        }

        if (!_isBallShot)
        {
            return;
        }

        _timeSinceShot += Time.deltaTime;
        
        if (_height >= 0.0f)
        {
            _height = _upSpeed * _timeSinceShot - 0.5f * Gravity * Mathf.Pow(_timeSinceShot, 2); // h = ut - 1/2gt^2
        }
        else
        {
            _upSpeed = 0.0f;
            _height = 0.0f;
        }
    }
    
    private void FixedUpdate()
    {
        if (_height < 0.01f)
        {
            if (_rigidbody2D.velocity.sqrMagnitude > 0.1f)
            {
                _height = 0.0f;
                var vel = _rigidbody2D.velocity;
                vel -= (_decelarationFriction * Time.deltaTime) * vel.normalized;
                _rigidbody2D.velocity = vel;
            }
            else
            {
                _rigidbody2D.velocity = Vector3.zero;
                _isBallShot = false;
            }
        }
    }

    private void LaunchBall()
    {
        arrow.SetActive(true);
        _rigidbody2D.velocity = Vector3.zero;
        _rigidbody2D.position = spawnPoint.position;
        StartCoroutine(RotateArrow());
        print("Finished");
    }

    private IEnumerator RotateArrow()
    {
        arrow.transform.rotation = Quaternion.Euler(Vector3.zero);
        var animationTime = Random.Range(_arrow.minArrowRotateAnimationTime, _arrow.maxArrowRotateAnimationTime);
        var increment = Random.value > 0.5f ? _arrow.rotationSpeed : -_arrow.rotationSpeed;
        
        while (animationTime > 0)
        {
            animationTime -= Time.deltaTime;
            var currentAngle = arrow.transform.rotation.eulerAngles.z;
            currentAngle = currentAngle <= 180 ? currentAngle : currentAngle - 360;
            if (currentAngle >= _arrow.maxAngle)
            {
                increment = -_arrow.rotationSpeed;
            }
            else if (currentAngle < _arrow.minAngle)
            {
                increment = _arrow.rotationSpeed;
            } else if (Random.value < 0.01f)
            {
                increment = -increment;
            }
            arrow.transform.Rotate(Vector3.forward, increment * Time.deltaTime);
            yield return null;
        }
        var direction = arrow.transform.rotation * Vector3.right;
        _rigidbody2D.velocity = direction * Random.Range(minBallHitSpeed, maxBallHitSpeed);
        
        
        _upSpeed = upSpeed;
        _isBallShot = true;
        _timeSinceShot = 0.0f;
        _height = 0.01f;
    }
}
