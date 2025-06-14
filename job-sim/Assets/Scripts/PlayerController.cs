using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Tooltip("Movement speed in units/second")]
    public float moveSpeed = 5f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
void Update()
{
    // Grant $10 when the player hits Space
    if (Input.GetKeyDown(KeyCode.Space))
    {
        CurrencyManager.Instance.AddMoney(10);
    }
}

void FixedUpdate()
{
    // Read raw input
    float h = Input.GetAxis("Horizontal"); // A/D, ←/→
    float v = Input.GetAxis("Vertical");   // W/S, ↑/↓

    // Build a direction relative to the Player’s local axes
    Vector3 input = new Vector3(h, 0f, v);
    Vector3 moveDirection = transform.TransformDirection(input);
    // Zero out any accidental Y component (just in case)
    moveDirection.y = 0f;

    // Scale by speed & fixed delta
    Vector3 move = moveDirection.normalized * moveSpeed * Time.fixedDeltaTime;

    // Apply the movement
    rb.MovePosition(rb.position + move);
}
}