using UnityEngine;

public class PlayerController : PlayerControllerEntity
{
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        SetRotation();
        SetAcceleration();
        SetCamera();
    }

    private void FixedUpdate()
    {
        _rb.velocity = transform.forward * _forceMovement;
    }

    private void SetRotation()
    {
        Vector3 horizontalMovement = Vector3.up * Input.GetAxis("Yaw");
        Vector3 verticalMovement = Vector3.right * Input.GetAxis("Pitch");
        Vector3 rollMovement = Vector3.forward * Input.GetAxis("Roll");
        
        Vector3 rotationMovement = (horizontalMovement + verticalMovement + rollMovement)
            * maxAngleRotation * Time.deltaTime * speedRotation;

        transform.Rotate(rotationMovement, Space.Self);
    }

    private void SetAcceleration()
    {
        _currentAcceleration += Input.GetAxis("Acceleration") * acceleration * Time.deltaTime;
        _currentAcceleration = Mathf.Clamp(_currentAcceleration, 0, 1);
        _forceMovement = _currentAcceleration * speedMovement;
    }

    private void SetCamera()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (Input.GetButtonDown("ToggleCamera"))
        {
            firstPersonCamera.SetActive(thirdPersonCamera.activeSelf);
            thirdPersonCamera.SetActive(!firstPersonCamera.activeSelf);            
        }
    }
}
