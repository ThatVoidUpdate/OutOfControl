using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour
{
    public UnityEvent DeadEvent;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("DEAD");
        collision.collider.gameObject.transform.root.GetComponent<CarController>().Dead();
    }
}
