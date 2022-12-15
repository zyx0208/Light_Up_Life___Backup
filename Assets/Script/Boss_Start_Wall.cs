using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Start_Wall : MonoBehaviour
{
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    public GameObject wall4;
    public GameObject Boss;
    public GameObject off_sound;
    public GameObject on_sound;
    private void Start()
    {
        wall1.SetActive(false);
        wall2.SetActive(false);
        wall3.SetActive(false);
        wall4.SetActive(false);
        Boss.SetActive(false);
    }
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            wall1.SetActive(true);
            wall2.SetActive(true);
            wall3.SetActive(true);
            wall4.SetActive(true);
            Boss.SetActive(true);
            on_sound.SetActive(true);
            off_sound.SetActive(false);
        }
    }
}
