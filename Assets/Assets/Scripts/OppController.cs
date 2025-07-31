using UnityEngine;

public class OppController : MonoBehaviour
{
    Rigidbody2D rb;
    float moveInput;
    [SerializeField] float moveSpeed = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        moveInput = 0f;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveInput = 1f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveInput = -1f;
        }

        rb.linearVelocity = Vector2.up * moveInput * moveSpeed;
    }
}
