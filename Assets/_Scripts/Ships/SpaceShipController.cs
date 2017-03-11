using UnityEngine;

public abstract class SpaceShipController : SpaceShipEntity
{
    protected virtual void Awake()
    {
        _currentLife = _maxLife;
        _currentShield = _maxShield;

        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_rb.velocity.magnitude >= _maxMagnitudeHit)
        {
            DestroyShip();
        }
    }

    public Vector3 GetCurrentPosition()
    {
        try
        {
            return _rb.position;
        }
        catch (System.Exception ex)
        {
            throw new System.Exception("Ha ocurrido un error en GetCurrentPosition: " + ex.Message);
        }
    }

    public virtual void DestroyShip()
    {
        if (_explosionPrefabClip != null)
        {
            AudioSource.PlayClipAtPoint(_explosionPrefabClip, this.transform.position, 1);
        }

        if (_explosionPrefab != null)
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    public void Damage(int damageAmmount)
    {
        _currentLife -= damageAmmount;
        if (_currentLife <= 0)
        {
            DestroyShip();
        }
    }
}
