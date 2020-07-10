using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float Force;
    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, Force));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }
}
