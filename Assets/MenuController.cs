using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.root.transform.position = new Vector3(0, 1.858f, -12.8f);
        other.gameObject.GetComponentInParent<Rigidbody>().velocity = Vector3.zero;
        other.gameObject.GetComponentInParent<Rigidbody>().AddForce(new Vector3(0, 0, 200000));
    }

    public void Quit()
    {
        Application.Quit();
    }
}
