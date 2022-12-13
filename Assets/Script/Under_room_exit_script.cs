using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Under_room_exit_script : MonoBehaviour
{
    public GameObject scr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "Player") && (scr.activeSelf == true))
        {
            SceneManager.LoadScene("5_Chapter2");
        }
    }
}
