using UnityEngine;

public class WanderController : SteeringBehavior
{
    [SerializeField]
    float CircleRadius = 40f;
    [SerializeField]
    float MaxRadius = 60f;
    [SerializeField]
    float TurnChance = 0.002f;

    Vector3 velocity;
    Vector3 wanderForce;

    protected override Vector3 GetForceUnclamped(float speedMovement)
    {
        var desiredVelocity = GetWanderForce(speedMovement);
        desiredVelocity = desiredVelocity.normalized * speedMovement;

        var steeringForce = desiredVelocity - velocity;
        steeringForce = Vector3.ClampMagnitude(steeringForce, _maxForce);
        steeringForce /= _rb.mass;

        return steeringForce;
    }

    private void OnGUI()
    {
        Debug.DrawRay(transform.position, velocity.normalized * 2, Color.blue);
        //Debug.DrawRay(transform.position, desiredVelocity.normalized * 2, Color.green);
    }

    private void Start()
    {
        velocity = Random.onUnitSphere;
        wanderForce = GetRandomWanderForce();
    }

    public Vector3 GetWanderForce(float speedMovement)
    {
        if (transform.position.magnitude > MaxRadius)
        {
            var directionToCenter = (_target.GetCurrentPosition() - transform.position).normalized;
            wanderForce = velocity.normalized + directionToCenter;
        }
        else if (Random.value < TurnChance)
        {
            wanderForce = GetRandomWanderForce();
        }

        return wanderForce;
    }

    public Vector3 GetRandomWanderForce()
    {
        var circleCenter = velocity.normalized;
        var randomPoint = Random.insideUnitCircle;

        var displacement = new Vector3(randomPoint.x, randomPoint.y) * CircleRadius;
        displacement = Quaternion.LookRotation(velocity) * displacement;

        var wanderForce = circleCenter + displacement;
        return wanderForce;
    }
}


//using UnityEngine;

//public class WanderController : SteeringManager
//{    
//    [SerializeField]
//    float CircleRadius = 40f;
//    [SerializeField]
//    float MaxRadius = 60f;
//    [SerializeField]
//    float TurnChance = 0.002f;

//    Vector3 velocity;
//    Vector3 wanderForce;

//    private void Start()
//    {
//        velocity = Random.onUnitSphere;
//        wanderForce = GetRandomWanderForce();        
//    }

//    private void Update()
//    {
//        var desiredVelocity = GetWanderForce();
//        desiredVelocity = desiredVelocity.normalized * _maxSpeed;

//        var steeringForce = desiredVelocity - velocity;
//        steeringForce = Vector3.ClampMagnitude(steeringForce, _maxForce);
//        steeringForce /= _rb.mass;

//        velocity = Vector3.ClampMagnitude(velocity + steeringForce, _maxSpeed);
//        transform.position += velocity * Time.deltaTime;
//        transform.forward = velocity.normalized;

//        Debug.DrawRay(transform.position, velocity.normalized * 2, Color.red);
//        Debug.DrawRay(transform.position, desiredVelocity.normalized * 2, Color.green);
//    }

//    public Vector3 GetWanderForce()
//    {
//        if (transform.position.magnitude > MaxRadius)
//        {
//            var directionToCenter = (_target.GetCurrentPosition() - transform.position).normalized;
//            wanderForce = velocity.normalized + directionToCenter;
//        }
//        else if (Random.value < TurnChance)
//        {
//            wanderForce = GetRandomWanderForce();
//        }

//        return wanderForce;
//    }

//    public Vector3 GetRandomWanderForce()
//    {
//        var circleCenter = velocity.normalized;
//        var randomPoint = Random.insideUnitCircle;

//        var displacement = new Vector3(randomPoint.x, randomPoint.y) * CircleRadius;
//        displacement = Quaternion.LookRotation(velocity) * displacement;

//        var wanderForce = circleCenter + displacement;
//        return wanderForce;
//    }
//}


//public class WanderController : SteeringBehavior
//{
//    [SerializeField]
//    float _circleDistance;
//    [SerializeField]
//    float _circleRadius;
//    [SerializeField]
//    float _angleIncrement;

//    Vector3 _velocity;
//    float _lastAngle;

//    private void Start()
//    {
//        _velocity = Random.onUnitSphere;
//    }

//    protected override Vector3 GetForceUnclamped(float speedMovement)
//    {
//        Vector3 centerCircle = transform.forward * _circleRadius;
//        Vector3 vCircle = new Vector3
//        {
//            x = Mathf.Sin(_lastAngle) * _circleRadius,
//            y = 0,
//            z = Mathf.Cos(_lastAngle) * _circleRadius
//        };

//        _lastAngle = Random.Range(-_angleIncrement / 2f, _angleIncrement / 2f) * Mathf.Deg2Rad * Time.fixedDeltaTime;

//        return (centerCircle + vCircle);
//    }
//}
