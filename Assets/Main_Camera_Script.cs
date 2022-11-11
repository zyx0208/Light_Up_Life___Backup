using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Camera_Script : MonoBehaviour
{
    public Transform target; //따라다닐 오브젝트의 위치
    private Transform target_me; //카메라 자신의 위치
    
    void Start()
    {
        this.transform.position = new Vector3(0, 10, -10); //위치 초기화
        this.transform.rotation = Quaternion.Euler(45, 0, 0); //각도 초기화
        target_me = GetComponent<Transform>(); //스크립트가 적용된 객체의 위치에 접근
    }

    void Update()
    {
        target_me.position = new Vector3(target.position.x, target.position.y+10, target.position.z-10); //target의 위치에서 z값이 -10인 지점에 카메라가 따라다님
    }
}
