using UnityEngine;

public class MiniMapController : MonoBehaviour
{    
    void Update()
    {
        Vector3 angle = transform.root.eulerAngles;
        transform.rotation = Quaternion.Euler(90, angle.y, 0);
    }
}
