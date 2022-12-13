using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Donggul_Next_Stage : MonoBehaviour
{
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player")&&(spawner1.activeSelf == false) && (spawner2.activeSelf == false) && (spawner3.activeSelf == false))
        {
            SceneManager.LoadScene("7_Chapter4");
        }
    }
}
