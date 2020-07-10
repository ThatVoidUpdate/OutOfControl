using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public GameObject Target;
    public Vector3 offset;

    // Update is called once per frame
    void Update()
    {
        transform.position = Target.transform.position + offset;
        transform.LookAt(Target.transform.position);
    }
}
