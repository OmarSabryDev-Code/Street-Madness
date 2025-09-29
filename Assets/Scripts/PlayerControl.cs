using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float laneChangeSpeed = 7f;
    public float tiltAmount = 15f; // degrees to tilt during turn
    public float tiltReturnSpeed = 5f;

    private Vector3 targetPosition;
    private int currentLane;

    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    public float swipeThreshold = 50f;

    private float currentTilt = 0.5f; // store tilt angle
    private float targetTilt = 0.5f;  // target tilt angle
    public TrailRenderer trail; 
    private Animation playerAnimation;

    private void Start()
    {
        currentLane = 2; // middle lane
        targetPosition = LaneManager.Instance.GetLanePosition(currentLane);
    }

    private void Update()
    {
        HandleSwipeInput();
        MoveForward();
        SmoothLaneMovement();
        ApplyTilt();
    }

    void MoveForward()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
    }

    void SmoothLaneMovement()
    {
        Vector3 desiredPosition = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * laneChangeSpeed);
    }

    void ApplyTilt()
    {
        currentTilt = Mathf.Lerp(currentTilt, targetTilt, Time.deltaTime * tiltReturnSpeed);
        transform.rotation = Quaternion.Euler(0, 0, -currentTilt); 
    }

    void HandleSwipeInput()
{
    // MOBILE INPUT
    if (Input.touchCount == 1)
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            startTouchPosition = touch.position;
        }

        if (touch.phase == TouchPhase.Ended)
        {
            endTouchPosition = touch.position;
            Vector2 swipeDelta = endTouchPosition - startTouchPosition;
            if (swipeDelta.magnitude > swipeThreshold) // check threshold here
            {
                DetectSwipe(swipeDelta);
            }
        }
    }

    // MOUSE INPUT (TESTING)
    if (Input.GetMouseButtonDown(0))
    {
        startTouchPosition = Input.mousePosition;
    }

    if (Input.GetMouseButtonUp(0))
    {
        endTouchPosition = Input.mousePosition;
        Vector2 swipeDelta = endTouchPosition - startTouchPosition;
        if (swipeDelta.magnitude > swipeThreshold) // check threshold here
        {
            DetectSwipe(swipeDelta);
        }
    }
}

void DetectSwipe(Vector2 swipeDelta)
{
    if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y)) // Horizontal swipe only
    {
        if (swipeDelta.x > 0 && currentLane < 4) // Swipe Right
        {
            currentLane++;
            targetTilt = -tiltAmount; // tilt right
        }
        else if (swipeDelta.x < 0 && currentLane > 0) // Swipe Left
        {
            currentLane--;
            targetTilt = tiltAmount; // tilt left
        }

        // Clamp currentLane to be safe (optional)
        currentLane = Mathf.Clamp(currentLane, 0, 4);

        targetPosition = LaneManager.Instance.GetLanePosition(currentLane);

        CancelInvoke(nameof(ResetTilt));
        Invoke(nameof(ResetTilt), 0.3f);
    }
}


    void ResetTilt()
    {
        targetTilt = 0f;
    }
}
