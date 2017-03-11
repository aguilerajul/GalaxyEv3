using UnityEngine;

public class WeaponController : WeaponEntity
{


    public void Shoot()
    {
        if(Time.time > _nextRateTimeToShoot)
        {
            _nextRateTimeToShoot += Time.time + _rateTimeToShoot;

            Instantiate(_lasserPrefab, this.transform.position, this.transform.rotation)
            .Init(this.transform.root.gameObject, 1, 200);
        }        
    }

    public Vector3 GetSpawnPoint()
    {
        return _spawnPoint.position;
    }

    private void OnDrawGizmos()
    {
        if (!_activateDebugMode) return;

        Gizmos.color = Color.red;
        Gizmos.DrawRay(_spawnPoint.transform.position, this.transform.forward * 300);
    }
}
