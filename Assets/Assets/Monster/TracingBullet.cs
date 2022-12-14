using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracingBullet : MonoBehaviour
{
    public GameObject target; //추적할 타켓
    public float speed = 5f; //총알의 속도
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < 0.5)
        {
            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
        }
        Vector3 direction = target.transform.position - rb.position;
        direction.Normalize();
        rb.angularVelocity = -Vector3.Cross(direction, transform.up) * 200f;

        rb.velocity = transform.up * speed;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            GetComponent<ParticleSystem>().Play();
            Die();
        }

        if (other.CompareTag("Player"))
        {
            GetComponent<ParticleSystem>().Play();
            target.GetComponent<Player_Script>().Damage(1);
            this.Die();
        }
    }


    void Die()
    {
        Destroy(gameObject);
    }
}
