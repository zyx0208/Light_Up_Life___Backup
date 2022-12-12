using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public GameObject monsterPrefab;
    public GameObject lightPrefab;
    private double timer;
    public double SpawnCooldown;
    
    int MaxHP;
    int CurHP;

    // Start is called before the first frame update
    void Start()
    {
        MaxHP = 5;
        CurHP = MaxHP;
        SpawnCooldown = 5.0;
        timer = SpawnCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if(timer < 0)
        {
            timer = 0;
        }

        if (timer == 0)
        {
            Vector3 RandVector = new Vector3(Random.Range(0.5f, 2f), 0, Random.Range(0.5f, 2f));
            Instantiate(monsterPrefab, transform.position +  RandVector, Quaternion.identity);
            timer = SpawnCooldown;
        }

        if (CurHP <= 0)
        {
            DIe();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet") 
        {
            Damage(1);
        }
    }

    private void DIe()
    {
        Instantiate(lightPrefab);
        Destroy(this.gameObject);
    }

    public void Damage(int damage)
    {
        CurHP -= damage;
        Debug.Log("스포너 체력: " + CurHP );
    }
}
