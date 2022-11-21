using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ButtonEventManager : MonoBehaviour
{
    public Button startBtn, exitBtn;

    void Start()
    {
        startBtn.onClick.AddListener(StartButtonDown);
        exitBtn.onClick.AddListener(ExitButtonDown);
    }

    void StartButtonDown()
    {
        Debug.Log("Start Button clicked.");
        SceneManager.LoadScene("Resources/Scenes/Chapter1_Story_Scene");
    }

    void ExitButtonDown()
    {
        Debug.Log("Exit Button clicked.");
        Application.Quit();
    }

}
