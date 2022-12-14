using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Enemy : MonoBehaviour
{
    int MaxHP;
    int CurHP;
    public float damage;
    public Transform target; //따라갈 대상
    public GameObject lightPrefab;

    NavMeshAgent nav;


    void Update()
    {
        nav.SetDestination(target.position);
        if(CurHP <= 0)
        {
            Die();
        }
    }

    void Start()
    {
        target = GameObject.Find("Player").transform;
        MaxHP = 2;
        CurHP = MaxHP;
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = true; //네비켜기
        
    }

    void OnTriggerEnter(Collider other)
    {
        //대미지 판정
        if (other.tag == "Bullet")
        {
            Debug.Log("남은 체력 = " + CurHP);
            Damage(1);
        }
    }

    public void SetHP(int hp)
    {
        this.MaxHP = hp;
    }

    void Die()
    {
        Instantiate(lightPrefab, new Vector3(this.transform.position.x, this.transform.position.y + 2f, this.transform.position.z), transform.rotation);
        Destroy(this.gameObject);
    }

   public void Damage(int damage)
   {
        CurHP -= damage;

   }

}