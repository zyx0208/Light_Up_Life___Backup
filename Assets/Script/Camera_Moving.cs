using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Moving : MonoBehaviour
{
    public Transform GP_target; //따라다닐 오브젝트의 위치
    private Transform GP_target_me; //카메라 자신의 위치
    public GameObject player;
    void Start()
    {
        player.GetComponent<Transform>();
        this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 15f, player.transform.position.z + 15f); //위치 초기화
        this.transform.rotation = Quaternion.Euler(45, 180, 0); //각도 초기화
        GP_target_me = GetComponent<Transform>(); //스크립트가 적용된 객체의 위치에 접근
    }

    void Update()
    {
        GP_target_me.position = new Vector3(GP_target.position.x, 15f, GP_target.position.z + 15f); //target의 위치에서 z값이 -10인 지점에 카메라가 따라다님
    }
}
