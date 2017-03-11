using UnityEngine;

public class SeekController : SteeringBehavior
{
    protected override Vector3 GetForceUnclamped(float speedMovement)
    {
        Vector3 position = (_target.GetCurrentPosition() - transform.position).normalized;

        return (_target.GetCurrentPosition() - transform.position).normalized * speedMovement;
    }
}
