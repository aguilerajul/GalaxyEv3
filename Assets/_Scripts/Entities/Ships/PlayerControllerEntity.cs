using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerControllerEntity : MonoBehaviour
{
    [Header("Values")]
    public float maxAngleRotation;
    public float speedMovement;
    public float speedRotation;
    public float acceleration;

    [Header("Cameras")]
    [SerializeField]
    protected GameObject thirdPersonCamera;
    [SerializeField]
    protected GameObject firstPersonCamera;

    protected float _currentAcceleration;
    protected float _forceMovement;
    protected Rigidbody _rb;
}
