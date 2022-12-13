using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monster_Script : MonoBehaviour
{
    public GameObject player;
    private void Start()
    {
        player.GetComponent<Player_Script>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            this.gameObject.SetActive(false);
            Player_Script.is_script_time = true;
            player.GetComponent<Animator>().SetBool("isWalk", false);
        }
    }
}
