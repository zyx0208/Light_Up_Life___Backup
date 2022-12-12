using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDamageBarr : MonoBehaviour
{
    public GameObject hpBarPrefab;
    public Vector3 hpBarOffset = new Vector3(0, 2.2f, 0);

    private float hp = 100.0f;
    private Canvas uiCanvas;
    private Image hpBarImage;

    void Start()
    {
        SetHpBar();
    }
    void SetHpBar()
    {
        uiCanvas = GameObject.Find("UI Canvas").GetComponent<Canvas>(); 
        GameObject hpBar = Instantiate<GameObject>(hpBarPrefab, uiCanvas.transform);
        hpBarImage = hpBar.GetComponentsInChildren<Image>()[1];

        var _hpbar = hpBar.GetComponent<EnemyHpBar>();
        _hpbar.targetTr = this.gameObject.transform;
        _hpbar.offset = hpBarOffset;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            //hpBarImage.fillAmount = hp / initHp;  
            Debug.Log("에너미 총알맞는즁 ㅋㅋ");
            if (hp <= 0.0f)
            {
                hpBarImage.GetComponentsInParent<Image>()[1].color = Color.clear;
            }
        }

    }
}

