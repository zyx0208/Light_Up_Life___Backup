using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyBullet : MonoBehaviour
{
    public float E_disappear_time = 2; //총알이 발사된 후 최대 존재 시간
    public float E_speed = 30f; //총알의 속도
    private double E_timer = 0.0;
    Material mat;

    void Start()
    {
        E_timer = E_disappear_time;
    }


    void Update()
    {
        Vector3 angle = transform.forward;
        transform.position += angle * E_speed * Time.deltaTime;
        if (E_timer > 0)
        {
            E_timer -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {

            Destroy(this.gameObject);

        }

        if (other.tag == "Walls")
        {
            Destroy(this.gameObject);
        }
    }
}
