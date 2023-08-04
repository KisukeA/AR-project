using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 touchStart;
    public float zoomSpeed = 0.15f;
    public float rotationSpeed = 0.2f;
    public float maxRotationAngle = 45f;
    public float minRotationAngle = -45f;

    private Quaternion initialRotation;
    private Quaternion targetRotation;
    private float initialFieldOfView;
    private float targetFieldOfView;

    private void Start()
    {
        initialRotation = transform.parent.rotation;
        targetRotation = initialRotation;
        initialFieldOfView = Camera.main.fieldOfView;
        targetFieldOfView = initialFieldOfView;
    }

    private void Update()
    {
        // Handle touch input
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            // Rotate the camera's parent object based on touch delta position
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            transform.parent.Rotate(Vector3.up, -touchDeltaPosition.x * rotationSpeed, Space.World);
        }
        else if (Input.touchCount == 2)
        {
            // Zoom the camera based on pinch gesture
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            Camera.main.fieldOfView += -difference * zoomSpeed;
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 40f, 120f); // Adjust the min/max zoom levels as desired

            // Rotate the camera's parent object upwards when zooming in, and downwards when zooming out
            float rotationAmount = difference * rotationSpeed;
            float newRotationAngle = targetRotation.eulerAngles.x + rotationAmount;
            newRotationAngle = Mathf.Clamp(newRotationAngle, minRotationAngle, maxRotationAngle);
            transform.Rotate(new Vector3(newRotationAngle, 0, 0) * Time.deltaTime);            
        }
    }
}
