using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot_Script : MonoBehaviour
{
    public GameObject on_scr;
    public GameObject off_scr;
    public GameObject monster;
    public GameObject player;
    public GameObject Lamp_light;
    public GameObject Player_Flash_light;
    public GameObject Player_Lamp_light;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            on_scr.SetActive(true);
            off_scr.SetActive(false);
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<Player_Script>().enabled = true;
            player.GetComponent<Animator>().SetBool("isWalk", false);
            monster.SetActive(true);
            Lamp_light.SetActive(false);
            Player_Flash_light.SetActive(true);
            Player_Lamp_light.SetActive(true);
        }
    }
}
