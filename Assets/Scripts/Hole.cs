using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Script {
public class Hole : MonoBehaviour
{
    [SerializeField] private bool movementHorizontal;

    [SerializeField] private bool movementVertical;
    [SerializeField] private float speed = 1.2f;

    [SerializeField] private AudioSource clap;
    [SerializeField] private AudioSource ballInHole;
    
    private Rigidbody2D _rigidbody2D;
    private Vector2 _moveDir = Vector2.zero;
    private GameManager _gameManager;

    [SerializeField] private Sprite idle;
    [SerializeField] private Sprite left;
    [SerializeField] private Sprite right;
    [SerializeField] private Sprite up;
    [SerializeField] private Sprite down;
    [SerializeField] private SpriteRenderer shadow;

    [SerializeField] private GameObject arrowTuto;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _gameManager = FindObjectOfType<GameManager>();
    }


    private void Update()
    {
        if (!FindObjectOfType<BallMovement>()) return;
        if (!FindObjectOfType<BallMovement>().isOnPlay) return;
        if (movementHorizontal)
        {
            _moveDir.x = Input.GetAxisRaw("Horizontal");
        }

        if (movementVertical)
        {
            _moveDir.y = Input.GetAxisRaw("Vertical");
        }
        
        AnimateFlag();

        if (arrowTuto && _moveDir != Vector2.zero)
        {
            arrowTuto.SetActive(false);
        }
    }

    private void AnimateFlag()
    {
        if (_moveDir == Vector2.zero)
            GetComponent<SpriteRenderer>().sprite = idle;
        else if (_moveDir.x > 0f)
            GetComponent<SpriteRenderer>().sprite = right;
        else if (_moveDir.x < 0f)
            GetComponent<SpriteRenderer>().sprite = left;
        else if (_moveDir.y > 0f)
            GetComponent<SpriteRenderer>().sprite = up;
        else if (_moveDir.y < 0f)
            GetComponent<SpriteRenderer>().sprite = down;

        shadow.sprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void FixedUpdate()
    {
        if (!FindObjectOfType<BallMovement>()) return;
        if (!FindObjectOfType<BallMovement>().isOnPlay) return;
        _rigidbody2D.MovePosition(_rigidbody2D.position + _moveDir.normalized * (speed * Time.fixedDeltaTime));
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (!other.transform.GetComponent<BallMovement>().onGround) return;
            other.gameObject.SetActive(false);
            clap.Play();
            ballInHole.Play();
            GetComponentInChildren<ParticleSystem>().Play();
            _gameManager.WinGame();
        }
    }
}
}