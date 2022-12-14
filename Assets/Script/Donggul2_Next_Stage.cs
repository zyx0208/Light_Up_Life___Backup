using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Donggul2_Next_Stage : MonoBehaviour
{
    public GameObject monster;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player") && (monster.activeSelf == false))
        {
            SceneManager.LoadScene("8_Chapter5");
        }
    }
}
