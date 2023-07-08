using System;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private bool movementHorizontal;

    [SerializeField] private bool movementVertical;
    [SerializeField] private float speed = 1.2f;

    private void Update()
    {
        var moveDir = Vector2.zero;
        if (movementHorizontal)
        {
            moveDir.x = Input.GetAxisRaw("Horizontal");
        }

        if (movementVertical)
        {
            moveDir.y = Input.GetAxisRaw("Vertical");
        }
        
        transform.Translate(moveDir.normalized * (speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            print("Point Scored");
        }
    }
}
