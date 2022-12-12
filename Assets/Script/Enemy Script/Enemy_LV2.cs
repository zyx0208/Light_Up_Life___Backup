using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemy_LV2 : MonoBehaviour
{
    // 몬스터가 플레이어 자동추적하는 코드 + LV2몬스터 근접공격시 슬라이더 조절
    public Slider PlayerHpSlider;
    public Transform target;
    public float Damage;
    NavMeshAgent nav;
    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = false; //네비끄기

    }

    void Update()
    {
        nav.SetDestination(target.position);
    }

    void Start()
    {
        nav.enabled = true; //네비켜기
    }
    void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            Debug.Log("근접공격을 받고있습니다");
            PlayerHpSlider.value -= Damage;

        }
    }


}