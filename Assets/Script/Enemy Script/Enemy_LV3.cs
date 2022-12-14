using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

//원거리 공격 총알 발사 스크립트
public class Enemy_LV3 : MonoBehaviour
{
    public GameObject bullet;
    public double EE_timer = 0.0;
    public double E_AttackCooldown = 1.0;
    public Slider PlayerHpSlider;
    public bool isCollider = false;
    public int stage;
    public float Damage;
    int MaxHP;
    int CurHP;

    NavMeshAgent nav_LV3;
    public Transform target;

    void Awake()
    {
        nav_LV3 = GetComponent<NavMeshAgent>();
        nav_LV3.enabled = false; //네비끄기

    }

    void Update()
    {
        nav_LV3.SetDestination(target.position);

        if (EE_timer > 0) //타이머가 0초보다 크면 매 프레임마다 타이머가 줄어듦
        {
            EE_timer -= Time.deltaTime;
        }
        else //타이머가 0초보다 낮을 때, 바라보는 방향으로 총알 발사
        {
            if (isCollider)
            {
                Instantiate(bullet, this.transform.position + new Vector3(0, 1, 0), this.transform.rotation);

                EE_timer = E_AttackCooldown;
            }
        }

        if (CurHP <= 0)
        {
            Die();
        }
    }

    void Start()
    {
        nav_LV3.enabled = true;
        MaxHP = 5;
        CurHP = MaxHP;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("사정거리 안에 플레이어가 있습니다");
            //PlayerHpSlider.value -= Damage;
            isCollider = true;

            if (PlayerHpSlider.value <= 0)
            {
                // 이거 리로드씬으로 바꾸기
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        //대미지 판정
        if (other.tag == "Bullet")
        {
            Debug.Log("남은 체력 = " + CurHP);
            LV3_Damage(1);
        }
    }

    public void SetHP(int hp)
    {
        this.MaxHP = hp;
    }

    void Die()
    {
        this.gameObject.SetActive(false);
    }

    public void LV3_Damage(int damage)
    {
        CurHP -= damage;

    }



}