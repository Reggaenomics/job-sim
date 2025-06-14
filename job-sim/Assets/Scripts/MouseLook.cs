using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Tooltip("How sensitive the mouse look is")]
    public float mouseSensitivity = 100f;

    [Tooltip("Assign the Player (capsule) here")]
    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        // lock & hide the cursor in the center
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // get mouse inputs
        float mouseX = Input.GetAxisRaw("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * mouseSensitivity * Time.deltaTime;


        // accumulate / clamp vertical look
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // apply rotations
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
