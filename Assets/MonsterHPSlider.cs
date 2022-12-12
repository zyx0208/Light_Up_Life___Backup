using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHPSlider : MonoBehaviour
{
    Slider slHP;
    float fSliderBarTime;
    void Start()
    {
        slHP = GetComponent<Slider>();
    }

    void Update()
    {
        if (slHP.value <= 0)
            transform.Find("Fill Area").gameObject.SetActive(false);
        else
            transform.Find("Fill Area").gameObject.SetActive(true);
    }
}
