using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger_wall : MonoBehaviour
{
    public GameObject script1;
    public GameObject script2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            script1.SetActive(false);
            script2.SetActive(true);
        }
    }
}
