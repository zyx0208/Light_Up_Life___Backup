using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8.0f;
    Rigidbody rb;
    Vector3 playerPosition;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        playerPosition = this.transform.position;
        //이 물체를 움직이는 요소가 오로지 Rigidbody의 WASD 뿐만 아니라
        //Use gravity를 사용해서 중력이적용 되기 때문에
        //중력에 의한 변화도 갱신을 해둬야 하는 이유 때문에 실제 위치를 계속 적용해야함.

        if (Input.GetKey(KeyCode.W))
        {
            playerPosition += speed * Time.deltaTime * Vector3.forward;
            //물체의 위치가 갱신되면 그다음 Vector3.forward라는 세계좌표기준 '앞' 값과, 속도, 시간의 60분의1 을 곱해준 후 
            //playerPosition에 뎌해준다.

            rb.MovePosition(playerPosition);
            //이제 movePosition덕에 새로 갱신된 위치로 이동될 것임.
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerPosition += speed * Time.deltaTime * Vector3.left;

            rb.MovePosition(playerPosition);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerPosition -= speed * Time.deltaTime * Vector3.forward;

            rb.MovePosition(playerPosition);
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerPosition -= speed * Time.deltaTime * Vector3.left;

            rb.MovePosition(playerPosition);
        }

        if ((!Input.GetKey(KeyCode.A)) && (!Input.GetKey(KeyCode.D)) && (!Input.GetKey(KeyCode.W)) && (!Input.GetKey(KeyCode.S))) //움직이지 않을 때
        {
            animator.SetFloat("IsMoving", 0f);
        }
        else animator.SetFloat("IsMoving", 1f);

        /*rb.velocity = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = Vector3.forward * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = Vector3.left * speed;
        }
        if(Input.GetKey(KeyCode.S))
        {
            rb.velocity = Vector3.back * speed;
        }
        if( Input.GetKey(KeyCode.D))
        {
            rb.velocity = Vector3.right * speed;
        }
        */
        Vector3 mPosition = Camera.main.WorldToScreenPoint(this.transform.position);
        this.transform.LookAt(new Vector3(-(-Input.mousePosition.x + mPosition.x), 0, -(-Input.mousePosition.y + mPosition.y))); 
    }
}
