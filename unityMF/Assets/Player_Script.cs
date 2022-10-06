using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Script : MonoBehaviour
{
    AudioSource bulletSound; 

    public GameObject bullet;
    public float speed = 5f; //ĳ������ �̵��ӵ�

    public double AttackCooldown = 0.5;
    public Rigidbody rigidbody;
    private double timer = 0.0;

    void Awake() //총알발사 사운드 
    {
        bulletSound = GetComponent<AudioSource>();
    }

    void Start()
    {
        this.transform.position = new Vector3(0, 3, 0); //��ġ �ʱ�ȭ
        this.transform.rotation = Quaternion.Euler(0, 0, 0); //���� �ʱ�ȭ
        this.GetComponent<Transform>();
    }

    void Update()
    {
        //�̵�����
        if ((Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.A))) //���� �̵�
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World); //cpu ���ɿ� ���� �ӵ� ���� ��ȭ�� ���� Time.deltaTime�� ���� // Space.World : ������ǥ
        }
        if ((Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.D))) //������ �̵�
        {
            transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
        }
        if ((Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.W))) //���� �̵�
        {
            transform.Translate(0, 0, speed * Time.deltaTime, Space.World);
        }
        if ((Input.GetKey(KeyCode.DownArrow)) || (Input.GetKey(KeyCode.S))) //�Ʒ��� �̵�
        {
            transform.Translate(0, 0, -speed * Time.deltaTime, Space.World);
        }

        //�������
        Vector3 mPosition = Camera.main.WorldToScreenPoint(this.transform.position); //ī�޶� ���� ���� �������� ���콺����Ʈ ��ǥ�� mPosition�� ����
        this.transform.LookAt(new Vector3(-(-Input.mousePosition.x + mPosition.x), 0, -(-Input.mousePosition.y + mPosition.y))); //�÷��̾�� ���콺�� ��ġ�� ���Ͽ� ���콺�� �ٶ󺸵��� ����
    }

    private void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                timer = 0;
                Instantiate(bullet, this.transform.position, this.transform.rotation);
                bulletSound.Play();
                timer = AttackCooldown;
                //Destroy(gameObject,2f);
            }
        }
    }
}
