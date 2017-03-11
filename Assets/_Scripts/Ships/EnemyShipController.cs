using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : SpaceShipController
{
    [SerializeField]
    float IADistance;
    [SerializeField]
    LayerMask _playerLayer;
    [SerializeField]
    WeaponController[] _weapons;
    
    PlayerShipController _player;
    SteeringManager _steeringManager;

    public void Initialize(PlayerShipController playerShip)
    {
        _player = playerShip;
    }

    private void Start()
    {
        Initialize(FindObjectOfType<PlayerShipController>());
    }

    protected override void Awake()
    {
        base.Awake();
        _steeringManager = GetComponent<SteeringManager>();
    }

    private void FixedUpdate()
    {
        if (!_player)
            return;

        float distance = Vector3.Distance(this.transform.position, _player.transform.position);
        if (distance > IADistance)
        {
            _steeringManager.ApplyBehaviour(typeof(WanderController));
        }
        else
        {
            _steeringManager.ApplyBehaviour(typeof(SeekController));

            foreach (var weapon in _weapons)
            {
                RaycastHit raycastHit;
                RaycastHit raycastHitSphere;
                bool isInRadius = false;

                Vector3 spawnPosition = weapon.GetSpawnPoint();

                isInRadius = Physics.Raycast(spawnPosition, this.transform.forward * IADistance, out raycastHit, _playerLayer);
                isInRadius |= Physics.SphereCast(spawnPosition + this.transform.forward * 2, 2, this.transform.forward, out raycastHitSphere, _playerLayer);

                if (isInRadius)
                {
                    weapon.Shoot();
                }
            }
        }

    }

    private static bool ValidateRayCastCollisions(RaycastHit raycastHit, RaycastHit raycastHitSphere, bool isInRadius)
    {
        try
        {
            var raycastCollider = raycastHit.collider;
            var raycastSphereCollider = raycastHitSphere.collider;
            if (raycastCollider && raycastSphereCollider)
            {
                return (isInRadius && (raycastHit.collider.GetComponent<SpaceShipController>()))
                    || (isInRadius && (raycastHitSphere.collider.GetComponent<SpaceShipController>()));
            }

            return false;
        }
        catch (System.Exception ex)
        {
            Debug.Log("Ha ocurrido un error en ValidateRayCastCollisions: " +
                ex.Message + " " + ex.StackTrace);
            return false;
        }
    }
}
