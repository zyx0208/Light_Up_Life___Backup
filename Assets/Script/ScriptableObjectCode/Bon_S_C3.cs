using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bon_S_C3 : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            /*스크립트 재생 
            중간에 
            적 죽이면 주변 구역이 밝아지는구나! 관련 스크립트 있으면 좋겠다만 일단은 희망사항 */
            Debug.Log("이정도 레벨은 EZ");

        }
    }
}
