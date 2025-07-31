using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    float moveInput;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        moveInput = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            moveInput = 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveInput = -1f;
        }

        rb.linearVelocity = Vector2.up * moveInput * speed;
    
    }
}
