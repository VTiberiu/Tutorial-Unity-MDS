using System.Collections.Generic;
using UnityEngine;

[System.Obsolete]
public class CameraFollowCarWithinBoundsScript : MonoBehaviour
{
    public Transform target;
    void Update()
    {
        transform.position = new Vector3(Mathf.Max(Mathf.Min(target.position.x, 8), -8), Mathf.Max(Mathf.Min(target.position.y, 5), -5), transform.position.z);
    }
}