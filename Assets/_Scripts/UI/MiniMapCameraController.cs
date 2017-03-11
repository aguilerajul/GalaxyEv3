using UnityEngine;

public class MiniMapCameraController : MonoBehaviour
{
    Camera _camera;
    [SerializeField]
    Transform _target;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (!_target)
            return;

        Vector3 targetPosition = _target.position;
        targetPosition.y = transform.position.y;

        transform.position = targetPosition;

    }
}
