using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public void OnClickStart()
    {
        //SceneManager.LoadScene("SampleScene");
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

}
