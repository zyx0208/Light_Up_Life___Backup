using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Welcome_wall : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fire1;
    public GameObject fire2;

    public GameObject fire_effect1;
    public GameObject fire_effect2;

    public GameObject on_sound;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            fire1.SetActive(true);
            fire2.SetActive(true);
            fire_effect1.SetActive(true);
            fire_effect2.SetActive(true);
            on_sound.SetActive(true);
        }
    }
}
