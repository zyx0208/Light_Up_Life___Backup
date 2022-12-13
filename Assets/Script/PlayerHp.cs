using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHp : MonoBehaviour
{
    public Slider PlayerHpSlider;
    public float Damage;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerHpSlider.value <= 0)
        {
            // 이거 리로드씬으로 바꾸기
            //SceneManager.LoadScene("피 다 닳았어");
        }
    }
}
// 이거 h누르면 하는거라 쓸모없어서 삭제할듯. moving AI에서 피관리할듯 근접