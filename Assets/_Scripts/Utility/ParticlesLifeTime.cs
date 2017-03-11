using UnityEngine;

public class ParticlesLifeTime : MonoBehaviour
{
    [Tooltip("If TimeToDestroy is equals to 0 the time to destroy will be the particleSystem main duration")]
    [SerializeField]
    float _timeToDestroy = 0;

    ParticleSystem _particleSystem;

    // Use this for initialization
    void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();

        if (_timeToDestroy > 0)
            Destroy(this.gameObject, _timeToDestroy);
        else if(_particleSystem != null)
            Destroy(this.gameObject, _particleSystem.main.duration);
        else
            Destroy(this.gameObject, 5f);
    }
}
