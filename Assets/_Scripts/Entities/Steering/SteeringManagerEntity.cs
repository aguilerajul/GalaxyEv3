using System.Collections.Generic;
using UnityEngine;

public class SteeringManagerEntity : MonoBehaviour
{
    [SerializeField]
    protected SpaceShipController _target;

    [Header("Values")]
    [SerializeField]
    protected float _maxSpeed = 10f;
    [SerializeField]
    protected float _maxForce = 15f;
    [SerializeField]
    protected float _maxAngle = 45f;

    protected List<System.Type> _activatedBehaviorList;
    
    protected SteeringBehavior[] _steeringBehaviors;
    protected Rigidbody _rb;
}
