using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Dounggul3_Next_Stage : MonoBehaviour
{
    public GameObject monster1;
    public GameObject monster2;
    public GameObject monster3;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player") && (monster1.activeSelf == false) && (monster2.activeSelf == false) && (monster3.activeSelf == false))
        {
            SceneManager.LoadScene("9_Chapter6");
        }
    }
}
