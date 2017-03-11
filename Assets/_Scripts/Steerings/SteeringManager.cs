using UnityEngine;

public class SteeringManager : SteeringManagerEntity
{
    public void Initialize()
    {
        //TODO: A;adir cuando se instancien las naves
        _steeringBehaviors = GetComponents<SteeringBehavior>();
        _rb = GetComponent<Rigidbody>();

        _activatedBehaviorList = new System.Collections.Generic.List<System.Type>();

        foreach(SteeringBehavior steeringBehavior in _steeringBehaviors)
        {
            steeringBehavior.Initialize(_rb, _target);
        }
    }

    private void Awake()
    {
        Initialize();
    }

    void FixedUpdate()
    {
        Vector3 desiredVelocity = SetDesiredVelocity();
        SetRotation(desiredVelocity);

        transform.forward = _rb.velocity.normalized;
    }

    private Vector3 SetDesiredVelocity()
    {
        Vector3 desiredVelocity = _rb.velocity;
        desiredVelocity = SetForce(desiredVelocity);
        desiredVelocity = Vector3.ClampMagnitude(desiredVelocity, _maxForce);
        return desiredVelocity;
    }

    private void SetRotation(Vector3 desiredVelocity)
    {
        _rb.velocity = Vector3.RotateTowards(
                    _rb.velocity,
                    desiredVelocity,
                    _maxAngle * Mathf.Deg2Rad * Time.fixedDeltaTime,
                    _maxSpeed
                );
    }

    private Vector3 SetForce(Vector3 desiredVelocity)
    {
        for (int i = 0; i < _steeringBehaviors.Length; i++)
        {
            SteeringBehavior steeringBehavior = _steeringBehaviors[i];
            Vector3 force = steeringBehavior.GetForce(_maxSpeed) / _rb.mass;
            desiredVelocity += force;
        }

        return desiredVelocity;
    }
    
    public void ApplyBehaviour(System.Type type)
    {
        if (!MustApplyBehaviour(type)) return;

        foreach (var steeringBehavior in _steeringBehaviors)
        {
            steeringBehavior.IsActive = steeringBehavior.GetType() == type;
        }

        _activatedBehaviorList.Add(type);
    }

    bool MustApplyBehaviour(System.Type type)
    {
        try
        {
            foreach (System.Type itemType in _activatedBehaviorList)
            {
                if (itemType.Equals(type))
                    return true;
            }
            
            return false;
        }
        catch (System.Exception ex)
        {
            Debug.Log("Ha Ocurrido un error: " + ex.Message + " " + ex.StackTrace);
            return true;
        }
    }
}
