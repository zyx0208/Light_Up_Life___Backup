using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//원거리 공격 총알 발사 스크립트
public class EnemyAttack : MonoBehaviour
{
    public GameObject bullet;
    public double EE_timer = 0.0;
    public double E_AttackCooldown = 2.0;
    public Slider PlayerHpSlider;
    public float B_Damage;


    /*void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Debug.Log("들어왔땅!!");

        }
    }*/

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("사정거리 안에 플레이어가 있습니다");
            Instantiate(bullet, this.transform.position, this.transform.rotation);
            EE_timer = E_AttackCooldown;
            PlayerHpSlider.value -= B_Damage;

            if (PlayerHpSlider.value <= 0)
            {
                // 이거 리로드씬으로 바꾸기
                SceneManager.LoadScene("EnemyScene");
            }

        }
    }
}
