using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ObstacleDragger : MonoBehaviour
{
    public bool IsDragging;
    Camera cam;
    public GameObject DraggingObject;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (IsDragging)
            {
                //move object
                DraggingObject.transform.position += Vector3.left * 10;
                Vector3 CameraOffset = DraggingObject.transform.position - transform.position;
                Vector3 NewPoint = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, CameraOffset.magnitude));
                DraggingObject.transform.position = new Vector3(NewPoint.x, DraggingObject.transform.position.y, DraggingObject.transform.position.z);
            }
            else
            {
                //check if can drag object
                RaycastHit hit;
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.transform.gameObject.CompareTag("Obstacle"))
                    {
                        DraggingObject = hit.transform.gameObject;
                        IsDragging = true;
                    }
                }
            }
        }
        else
        {
            IsDragging = false;
            DraggingObject = null;
        }
    }
}
