using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 5.0f;
    private float gravityValue = -9.81f;
    private Animator anim;
    Animator animator;
    public static bool is_script_time;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        is_script_time = true;
    }


    // Update is called once per frame
    void Update()
    {
        if (is_script_time == false)
        {
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            Vector3 move = new Vector3(-Input.GetAxisRaw("Horizontal"), 0, -Input.GetAxisRaw("Vertical"));
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero) anim.SetBool("isWalk", true);
            else anim.SetBool("isWalk", false);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);

            //시점관련
            Vector3 mPosition = Camera.main.WorldToScreenPoint(this.transform.position); //메인카메라의 위치 정보를 mPosition에 저장
            this.transform.LookAt(new Vector3(-Input.mousePosition.x + mPosition.x, 0, -Input.mousePosition.y + mPosition.y)); //메인카메라의 위치와 마우스의 위치를 이용하여 마우스 방향을 쳐다보게 설정
        }
    }
}
