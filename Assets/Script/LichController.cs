using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LichController : MonoBehaviour
{
    public int HP = 100;
    public GameObject tracingBullet;
    public GameObject Monster;
    int MaxHP = 100;
    int pattern;
    bool isRaged = false;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim= GetComponent<Animator>();
        StartCoroutine(BossPattern());
        Debug.Log("실행중");

    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
            Die();
        else if (HP < MaxHP / 2) //체력이 절반보다 낮을 때
        {
            isRaged = true;
        }
        
    }

    void killme()
    {
        SceneManager.LoadScene("10_THE_END");
    }

    void Die()
    {
        anim.SetBool("isDead", true);
        Invoke("killme", 5f);
    }

    public void Attack1()
    {
        anim.SetTrigger("isAttacking");
        Invoke("SummonTracingBullet", 0.6f);
    }


    void SpacialAttack()
    {
        anim.SetTrigger("isBttacking");
        Invoke("SummonMonster", 1.4f);
        HP -= 1;
    }

    //damage의 수치만큼 HP를 줄입니다.
    void Hit(int damage)
    {
        anim.SetTrigger("isHit");
        HP -= damage;
    }

    

    IEnumerator BossPattern()
    {
        while(HP>0)
        {
            pattern = Random.Range(1, 3);
            
            Debug.Log("pattern = " + pattern);

            if (isRaged)
            {
                if (pattern == 1)
                {
                    SpacialAttack();
                    Debug.Log("SpacialAttack");
                }
                else if (pattern == 2)
                {
                    Attack1();
                    Debug.Log("Attack");
                }  
            }
            else
            {
                Attack1();
                Debug.Log("Attack");
            }

            Debug.Log("HP = " + HP);
            yield return new WaitForSeconds(5f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            Debug.Log("Hit -> HP: " + HP);
            Hit(5);
        }
    }

    void SummonTracingBullet()
    {
        Instantiate(tracingBullet, transform.position + new Vector3(1.2f, 5, -15), transform.rotation);
    }

    void SummonMonster()
    {
        Instantiate(Monster, transform.position + new Vector3(4.2f, 0, -5f), transform.rotation);
        Instantiate(Monster, transform.position + new Vector3(-2.8f, 0, -5f), transform.rotation);
    }
}
