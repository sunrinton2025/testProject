using minyee2913.Utils;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField]
    CamEffector cam;
    [SerializeField]
    Vector3 offset;
    [SerializeField]
    float lerp;

    public void Follow()
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(transform.position.x, transform.position.y, cam.transform.position.z) + offset, lerp * Time.deltaTime);
    }
}
