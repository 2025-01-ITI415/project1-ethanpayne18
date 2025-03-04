using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform Player;  // Reference to the player ball
    public float smoothSpeed = 5f; // Smoothing factor for camera movement
    public float rotationSpeed = 100f; // Speed of camera rotation

    private Vector3 offset;
    private float currentAngle = 0f; // Track camera angle

    void Start()
    {
        // Store initial offset
        offset = transform.position - Player.position;
    }

    void LateUpdate()
    {
        // Read input from movement keys
        float horizontal = Input.GetAxis("Horizontal");
        
        // Rotate camera based on player movement
        currentAngle += horizontal * rotationSpeed * Time.deltaTime;
        Quaternion rotation = Quaternion.Euler(0, currentAngle, 0);
        Vector3 newPosition = Player.position + rotation * offset;

        // Smoothly move the camera to the new position
        transform.position = Vector3.Lerp(transform.position, newPosition, smoothSpeed * Time.deltaTime);

        // Always look at the player
        transform.LookAt(Player);
    }
}
