using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LichController : MonoBehaviour
{
    public int HP = 100;
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
            anim.SetBool("isRaged", true);
        }
        
    }

    void Die()
    {
        anim.SetBool("isDead", true);
    }

    public void Attack1()
    {
        anim.SetTrigger("isAttacking");    
    }

    void SpacialAttack()
    {
        anim.SetTrigger("isAttacking");
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
            if (isRaged) pattern = 4;
            Debug.Log("pattern = " + pattern);

            if (pattern == 1)
                Attack1();
            else if (pattern == 2)
                Hit(3);
            else if (pattern == 3)
                Die();
            else if (pattern == 4)
                SpacialAttack();
            Debug.Log("HP = " + HP);
            yield return new WaitForSeconds(5f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            Debug.Log("SSEE");
            Hit(5);
        }
    }
}
