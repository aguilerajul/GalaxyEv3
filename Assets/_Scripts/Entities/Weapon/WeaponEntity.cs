using UnityEngine;

public class WeaponEntity : MonoBehaviour
{
    [SerializeField]
    protected Transform _spawnPoint;
    [SerializeField]
    protected Ammunition _lasserPrefab;
    [SerializeField]
    protected float _rateTimeToShoot;

    protected float _nextRateTimeToShoot;

#if UNITY_EDITOR
    [SerializeField]
    protected bool _activateDebugMode;
#endif
}
