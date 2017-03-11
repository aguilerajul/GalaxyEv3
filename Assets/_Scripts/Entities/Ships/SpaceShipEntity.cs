using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpaceShipEntity : MonoBehaviour
{
    [Header("Values")]
    [SerializeField]
    protected float _maxMagnitudeHit = 10f;
    [SerializeField]
    protected float _maxShield;
    [SerializeField]
    protected float _maxLife;

    [Header("Prefabs")]
    [SerializeField]
    protected GameObject _explosionPrefab;
    [SerializeField]
    protected AudioClip _explosionPrefabClip;

    protected float _currentLife;
    protected float _currentShield;
    protected Rigidbody _rb;
}
