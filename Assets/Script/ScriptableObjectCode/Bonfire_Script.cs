using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bonfire_Script : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            /*스크립트 재생 
            이곳이 아네모네가 말한 동굴이구나
            대충 모험시작 스크립트*/
            Debug.Log("이곳이 동굴의 입구!");
            //SceneManager.LoadScene("5_Chapter2");

        }
    }
}
