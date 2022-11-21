using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 몬스터체력바 입니다
public class EnemyHp : MonoBehaviour
{
    [SerializeField] GameObject m_goPrefab = null;

    List<Transform> m_objectList = new List<Transform>();
    List<GameObject> m_hpBarList = new List<GameObject>();

    Camera m_cam = null;

    void Start()
    {
        m_cam = Camera.main;

        GameObject[] t_objects = GameObject.FindGameObjectsWithTag("Enemy");
        for(int i = 0; i < t_objects.Length; i++)
        {
            m_objectList.Add(t_objects[i].transform);
            GameObject t_hpbar = Instantiate(m_goPrefab, t_objects[i].transform.position, Quaternion.identity,transform);
            m_hpBarList.Add(t_hpbar);   
        }
    }


    void Update()
    {
        for(int i = 0; i<m_objectList.Count; i++)
        {
            m_hpBarList[i].transform.position = m_cam.WorldToScreenPoint(m_objectList[i].position + new Vector3(0, 1.15f, 0));
        }
    }
}
