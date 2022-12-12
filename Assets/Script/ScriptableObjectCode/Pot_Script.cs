using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot_Script : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag== "Player")
        {
            /*스크립트 재생 
            아네모네를 만나게 됐다.
            아네모네가 대충 맵안에 있는 몬스터 한마리 잡아달라 부탁
            몬스터한테 접근하는 순간 스크립트 재생*/
            Debug.Log("너가 그...!");

        }
    }
}
