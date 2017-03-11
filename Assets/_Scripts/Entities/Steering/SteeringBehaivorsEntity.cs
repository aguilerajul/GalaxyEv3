using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[ExecuteInEditMode]
public class SteeringBehaivorsEntity : MonoBehaviour
{
    [SerializeField]
    protected float _maxForce;
    [SerializeField]
    protected SpaceShipController _target;
    
    public bool IsActive { get; set; }

    protected Rigidbody _rb;
}
