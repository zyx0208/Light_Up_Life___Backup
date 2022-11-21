using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public Slider PlayerHpSlider;
    public float Damage;

    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKey(KeyCode.H))
        {
            //PlayerHealthBar.value -= 0.1f;
            PlayerHpSlider.value -= Damage;
        }
        
    }
}
// 이거 h누르면 하는거라 쓸모없어서 삭제할듯. moving AI에서 피관리할듯 근접