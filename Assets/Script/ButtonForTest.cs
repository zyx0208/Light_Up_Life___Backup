using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonForTest : MonoBehaviour
{
    public LichController Lich;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActiveButton()
    {
        Debug.Log("BUTTON");
        Lich.Attack1();
    }
}
