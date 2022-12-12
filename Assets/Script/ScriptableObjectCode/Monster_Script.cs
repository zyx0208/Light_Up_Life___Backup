using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Monster_Script : MonoBehaviour
{
    void OnInvoke()

    {

        //위 코드에 따라 1초 뒤에 아래와 같은 로그 참조.

        SceneManager.LoadScene("5_Chapter2");

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            /* 플레이어가 몬스터 collider와 충돌하면 스크립트 재생
             이때 플레이어가 총알 발사 가능하게 코딩. 몬스터 잡으면
            동굴에 가줘... 동굴이동 맵으로 씬전환*/
            Debug.Log("이녀석이 아네모네가 잡아달라는 몬스터인가? 하지만 나.. 무기같은거 전혀 가지고있지 않은걸!!!");
            Invoke("OnInvoke", 3.0f); //이걸 몬스터 잡고나서 스크립트 재생후 씬전환 코드로 바꿀거임

        }
    }
}
