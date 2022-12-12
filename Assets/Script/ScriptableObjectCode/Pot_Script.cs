using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot_Script : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag== "Player")
        {
            /* 플레이어가 아네모네가 갇혀있는 램프에 닿으면 스크립트가 재생된다
            -> 지하실의 수상한 빛의 정체는 바로 너였구나!
            -> (아네모네) 어서 날 꺼내줘! 갑자기 몬스터의 공격을 받아 빛이 사라졌다. 아네모네는 몬스터의 기척을 느끼는 특성이 있음
            -> 지하실에 몬스터 한 마리가 있는데 그 몬스터를 잡아달라는 이야기 . 그리고 마우스 클릭하면 총 나가게 코드 다시짜기
            총알은 지하실에 있는 몬스터에 접근하면 발사가 가능하게 코딩 */
            Debug.Log("너가 그...!");

        }
    }
}
