using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Script : MonoBehaviour
{
    int MaxHP;
    int CurHP;

    AudioSource bulletSound;
    Animator animator;

    public GameObject bullet;   
    public float speed = 5f; //플레이어블 캐릭터의 이동속도

    public double AttackCooldown = 0.5; //총알 발사 딜레이
    private readonly double DamagedCooltime = 0.5; //피격 무적시간
    public Rigidbody rigidbody_; //"rigidbody"라는 이름이 시스템에서 다른 용도로 사용 중이라서 언더바 추가
    private double timer = 0.0;

    public Slider PlayerHpSlider;

    private double damage_timer; //무적타임을 위한

    void Awake() //총알발사 사운드 
    {
        bulletSound = GetComponent<AudioSource>();
    }

    void Start()
    {
        MaxHP = 10;
        CurHP = MaxHP;
        
        // this.transform.position = new Vector3(0, 1, 0); //시작점 설정
        this.transform.rotation = Quaternion.Euler(0, 0, 0); //시작 각도 설정(웬만하면 0, 0, 0으로)
        this.GetComponent<Transform>();
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        //이동관련
        if (Input.GetKey(KeyCode.A)) //왼쪽 이동
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World); //cpu마다의 성능 격차를 해소하기 위해 Time.deltaTime를 곱해서 사용 // Space.World : 절대좌표
            animator.SetFloat("IsMoving", 1f);
        }
        if (Input.GetKey(KeyCode.D)) //오른쪽 이동
        {
            transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
            animator.SetFloat("IsMoving", 1f);
        }
        if (Input.GetKey(KeyCode.W)) //위쪽 이동
        {
            transform.Translate(0, 0, speed * Time.deltaTime, Space.World);
            animator.SetFloat("IsMoving", 1f);
        }
        if (Input.GetKey(KeyCode.S)) //아래쪽 이동
        {
            transform.Translate(0, 0, -speed * Time.deltaTime, Space.World);
            animator.SetFloat("IsMoving", 1f);
        }
        if ((!Input.GetKey(KeyCode.A)) && (!Input.GetKey(KeyCode.D)) && (!Input.GetKey(KeyCode.W)) && (!Input.GetKey(KeyCode.S))) //움직이지 않을 때
        {
            animator.SetFloat("IsMoving", 0f);
        }

        //시점관련
        Vector3 mPosition = Camera.main.WorldToScreenPoint(this.transform.position); //메인카메라의 위치 정보를 mPosition에 저장
        this.transform.LookAt(new Vector3(-(-Input.mousePosition.x + mPosition.x), 0, -(-Input.mousePosition.y + mPosition.y))); //메인카메라의 위치와 마우스의 위치를 이용하여 마우스 방향을 쳐다보게 설정
        
        if (timer > 0) //타이머가 0초보다 크면 매 프레임마다 타이머가 줄어듦
        {
            timer -= Time.deltaTime;
        }
        else //타이머가 0초보다 낮을 때, 마우스 클릭을 하면 바라보는 방향으로 총알 발사
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(bullet, this.transform.position, this.transform.rotation);
                bulletSound.Play();
                timer = AttackCooldown;
            }
        }

        if (damage_timer > 0) //타이머가 0초보다 크면 매 프레임마다 타이머가 줄어듦
        {
            damage_timer -= Time.deltaTime;
        }
        else if (damage_timer < 0)
        {
            damage_timer = 0;
        }

        if(CurHP < 0)
        {
            Die();
        }
    }

    public void Damage(int damage)
    {
        CurHP -= damage;
        PlayerHpSlider.value = (float)CurHP / (float)MaxHP * 10;
    }

    public void Die()
    {
        SceneManager.LoadScene("EnemyScene");
    }

    void OnCollisionStay(Collision other)
    {
        
        if (other.collider.tag == "Enemy")
        {
            if (damage_timer == 0)
            {
                Damage(1);
                Debug.Log("HP " + CurHP);
                damage_timer = DamagedCooltime;
            }
            
        }
    }
}
