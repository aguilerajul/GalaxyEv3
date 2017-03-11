using UnityEngine;

public class FleeController : SteeringBehavior
{
    protected override Vector3 GetForceUnclamped(float speedMovement)
    {
        return (transform.position - _target.GetCurrentPosition()).normalized * speedMovement;
    }
}
