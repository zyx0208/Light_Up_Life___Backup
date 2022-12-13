using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Under_room_For_next_Scene_script : MonoBehaviour
{
    public GameObject script2;
    public GameObject script3;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if ((enemy.activeSelf == false)&&(script2.activeSelf == true))
        {
            script2.SetActive(false);
            script3.SetActive(true);

        }
    }
}
