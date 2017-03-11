using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ammunition : MonoBehaviour
{
    protected GameObject _owner;
    protected int _damage;
    protected float _speed;

    Rigidbody _rb;

    public void Init(GameObject owner, int damage, float speed)
    {
        _owner = owner;
        _damage = damage;
        _speed = speed;

        _rb.useGravity = false;
        _rb.velocity = this.transform.forward * speed;
    }

    protected virtual void Awake()
    {
        _rb = GetComponent<Rigidbody>();        
    }

    protected abstract void Damage(SpaceShipController ship);

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == _owner)
            return;

        SpaceShipController ship = collision.gameObject.GetComponent<SpaceShipController>();
        if(ship != null)
        {
            Damage(ship);
        }

        Destroy(this.gameObject);
    }
}
