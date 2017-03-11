using UnityEngine;

public abstract class SteeringBehavior : SteeringBehaivorsEntity
{   
    public void Initialize(Rigidbody rb, SpaceShipController target)
    {
        _rb = rb;
        _target = target;
        IsActive = true;
    }

    public Vector3 GetForce(float speedMovement)
    {
        if (!IsActive)
            return Vector3.zero;

        return Vector3.ClampMagnitude(GetForceUnclamped(speedMovement), _maxForce);
    }

    protected abstract Vector3 GetForceUnclamped(float speedMovement);
}
