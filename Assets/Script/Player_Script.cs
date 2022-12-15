using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Script : MonoBehaviour
{
    public void Damage(int damage)
    {
        CurHP -= damage;
        PlayerHpSlider.value = (float)CurHP / (float)MaxHP * 10;
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    int MaxHP;
    int CurHP;
    public int stage;
    public int reverse_WASD; //카메라 시점에 따라 좌우반전(만약 반대로 움직이면 -1 곱해서 쓰면 됨)

    AudioSource bulletSound;
    Animator animator;

    public GameObject bullet;
    public float playerSpeed = 5f; //플레이어블 캐릭터의 이동속도
    private float gravityValue = -9.81f;
    private CharacterController controller;

    public double AttackCooldown = 0.5; //총알 발사 딜레이
    public double DamagedCooltime = 1; //피격 무적시간
    public Rigidbody rigidbody_; //"rigidbody"라는 이름이 시스템에서 다른 용도로 사용 중이라서 언더바 추가
    private double timer = 0.0;

    public Slider PlayerHpSlider;

    private double damage_timer; //무적타임을 위한
    public static bool is_script_time;

    private bool groundedPlayer;
    private Vector3 playerVelocity;


    void Awake() //총알발사 사운드 
    {
        bulletSound = GetComponent<AudioSource>();
    }

    void Start()
    {
        MaxHP = 20;
        CurHP = MaxHP;

        // this.transform.position = new Vector3(0, 1, 0); //시작점 설정
        this.transform.rotation = Quaternion.Euler(0, 0, 0); //시작 각도 설정(웬만하면 0, 0, 0으로)
        this.GetComponent<Transform>();
        animator = this.GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        is_script_time = true;
    }

    void Update()
    {
        //이동관련
        if (is_script_time == false)
        {
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            Vector3 move = new Vector3(reverse_WASD * - Input.GetAxisRaw("Horizontal"), 0, reverse_WASD * - Input.GetAxisRaw("Vertical"));
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero) animator.SetBool("isWalk", true);
            else animator.SetBool("isWalk", false);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Vector3 vector;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                vector= new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
                transform.forward = vector;
            }

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    vector = new Vector3(hit.point.x, transform.position.y, hit.point.z) - transform.position;
                    transform.forward = vector;
                }

            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);


            //시점관련
            //Vector3 mPosition = Camera.main.WorldToScreenPoint(this.transform.position); //메인카메라의 위치 정보를 mPosition에 저장
            //this.transform.LookAt(new Vector3(reverse_WASD * (-Input.mousePosition.x + mPosition.x), 0, reverse_WASD * (-Input.mousePosition.y + mPosition.y))); //메인카메라의 위치와 마우스의 위치를 이용하여 마우스 방향을 쳐다보게 설정

            

            if (timer > 0) //타이머가 0초보다 크면 매 프레임마다 타이머가 줄어듦
            {
                timer -= Time.deltaTime;
            }
            else //타이머가 0초보다 낮을 때, 마우스 클릭을 하면 바라보는 방향으로 총알 발사
            {
                if (Input.GetMouseButton(0))
                {
                    
                    Instantiate(bullet, new Vector3(this.transform.position.x, this.transform.position.y + 0.5f, this.transform.position.z), this.transform.rotation);
                    //bulletSound.Play();
                    timer = AttackCooldown;
                }
            }

            if (damage_timer > 0) //타이머가 0초보다 크면 매 프레임마다 타이머가 줄어듦
            {
                damage_timer -= Time.deltaTime;
            }

            if (CurHP < 0)
            {
                Die();
            }
        }

        

        
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (damage_timer <= 0)
            {
                Damage(1);
                Debug.Log("Player HP : " + CurHP);
                damage_timer = DamagedCooltime;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        //대미지 판정
        if (other.tag == "Enemy_Bullet")
        {
            Debug.Log("총알에 맞고있어!");
            if (damage_timer <= 0)
            {
                Damage(5);
                Debug.Log("HP " + CurHP);
                damage_timer = DamagedCooltime;
            }

        }
    }
}

/*
 * 
 * 
 * 
*/