using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    public float disappear_time = 10f; //총알이 발사된 후 최대 존재 시간
    public float speed = 30f; //총알의 속도
    private double timer = 0.0;
    Material mat;

    void Start()
    {
        timer = disappear_time;
    }


    void Update()
    {
        Vector3 angle = transform.forward;
        transform.position += angle * speed * Time.deltaTime;
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "Enemy")
        {
            Debug.Log("맞았당!!");
            //other.gameObject.SetActive(false);
            Destroy(this.gameObject);
           
        }

        if (other.tag == "Walls")
        {
            Destroy(this.gameObject);
        }
    }



}