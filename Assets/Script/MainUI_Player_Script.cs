using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI_Player_Script : MonoBehaviour
{
    public float speed = 5f; //플레이어블 캐릭터의 이동속도
    Animator animator;
    public GameObject Front_Block;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Transform>();
        animator = this.GetComponent<Animator>();
        Front_Block.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1);
    }

    // Update is called once per frame
    void Update()
    {
        //이동관련
        if (Input.GetKey(KeyCode.A)) //왼쪽 이동
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0, Space.World); //cpu마다의 성능 격차를 해소하기 위해 Time.deltaTime를 곱해서 사용 // Space.World : 절대좌표
            animator.SetFloat("IsMoving", 1f);
            if (Input.GetKey(KeyCode.W))
            {
                Front_Block.transform.position = new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z + 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Front_Block.transform.position = new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z - 1);
            }
            else
            {
                Front_Block.transform.position = new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.D)) //오른쪽 이동
        {
            transform.Translate(speed * Time.deltaTime, 0, 0, Space.World);
            animator.SetFloat("IsMoving", 1f);
            if (Input.GetKey(KeyCode.W))
            {
                Front_Block.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z + 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                Front_Block.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z - 1);
            }
            else
            {
                Front_Block.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z);
            }
        }
        if (Input.GetKey(KeyCode.W)) //위쪽 이동
        {
            transform.Translate(0, 0, speed * Time.deltaTime, Space.World);
            animator.SetFloat("IsMoving", 1f);
            if (Input.GetKey(KeyCode.A))
            {
                Front_Block.transform.position = new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z + 1);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Front_Block.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z + 1);
            }
            else
            {
                Front_Block.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 1);
            }
        }
        if (Input.GetKey(KeyCode.S)) //아래쪽 이동
        {
            transform.Translate(0, 0, -speed * Time.deltaTime, Space.World);
            animator.SetFloat("IsMoving", 1f);
            if (Input.GetKey(KeyCode.A))
            {
                Front_Block.transform.position = new Vector3(this.transform.position.x - 1, this.transform.position.y, this.transform.position.z - 1);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Front_Block.transform.position = new Vector3(this.transform.position.x + 1, this.transform.position.y, this.transform.position.z - 1);
            }
            else
            {
                Front_Block.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1);
            }
        }
        if ((!Input.GetKey(KeyCode.A)) && (!Input.GetKey(KeyCode.D)) && (!Input.GetKey(KeyCode.W)) && (!Input.GetKey(KeyCode.S))) //움직이지 않을 때
        {
            animator.SetFloat("IsMoving", 0f);
        }

        //시점관련
        this.transform.LookAt(Front_Block.transform);

    }
}
