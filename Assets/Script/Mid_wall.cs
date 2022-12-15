using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_wall : MonoBehaviour
{
    public GameObject off_scr;
    public GameObject on_scr;
    public GameObject player;

    private void Start()
    {
        player.GetComponent<Player_Script>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            off_scr.SetActive(false);
            on_scr.SetActive(true);
            Player_Script.is_script_time = true;
            this.gameObject.SetActive(false);
        }
    }
}
