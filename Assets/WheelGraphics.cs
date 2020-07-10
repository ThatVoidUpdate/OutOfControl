using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelGraphics : MonoBehaviour
{
    WheelCollider collider;
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponentInParent<WheelCollider>();
    }

    // Update is called once per frame
    void Fixed()
    {
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
        this.transform.position = position;
        this.transform.rotation = rotation;
    }
}
