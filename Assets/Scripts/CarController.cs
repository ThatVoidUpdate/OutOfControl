using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarController : MonoBehaviour
{
    public float Force;
    public Text DistanceText;
    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, Force));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        transform.position = new Vector3(0, transform.position.y, transform.position.z);

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (DistanceText != null)
        {
            DistanceText.text = $"Distance: {(transform.position - new Vector3(0, 1.858f, -12.8f)).magnitude:F2}";
        }
        
    }

    public void Dead()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
