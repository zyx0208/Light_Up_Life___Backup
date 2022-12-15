using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public GameObject controll_audio;
    public void OnClickStart()
    {
        controll_audio.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("2_Prologue");
    }

    public void OnClickExit()
    {
        controll_audio.GetComponent<AudioSource>().Play();
        Application.Quit();
    }

}
