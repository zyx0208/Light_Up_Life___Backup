using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Script : MonoBehaviour
{
    private float disappear_time = 2;
    public float speed = 30f;
    private double timer = 0.0;

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

            other.gameObject.SetActive(false);
            Destroy(this.gameObject);

        }

        if (other.tag == "Walls")
        {
            Destroy(this.gameObject);
        }
    }
}