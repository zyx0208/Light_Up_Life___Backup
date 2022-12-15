using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;

public class Donggul3_Start : MonoBehaviour
{
    public Text scriptObj;
    public Text nameObj;
    List<string> scripts = new List<string>();
    List<string> names = new List<string>();
    List<string> portraits = new List<string>();
    int checkScriptLine;
    public GameObject nextStoryBtn;
    public Button nextBtn;
    public GameObject backgroundImg;
    public GameObject characterImg;
    public Image portraitImg;
    public GameObject monster1;
    public GameObject monster2;
    public GameObject monster3;
    public GameObject Click_sound;


    // Start is called before the first frame update
    void Start()
    {
        portraitImg = characterImg.GetComponent<Image>();
        // 스크립트 작성하는 곳
        names.Add("아네모네");
        names.Add("주인공");
        names.Add("아네모네");
        names.Add("주인공");

        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Hero_question");
        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Hero_common");

        scripts.Add("점점 어둠의 기운이 강해지는 거 같아...");
        scripts.Add("근데 넌 왜 안싸워?");
        scripts.Add("다 물리친 다음에 위쪽으로 가면 될 것 같아!");
        scripts.Add("(무시당했다...)");

        // 일반 코드
        nextBtn.onClick.AddListener(nextScript);

        checkScriptLine = 0;
        scriptObj.text = "";
        StartCoroutine(Typing(scripts[checkScriptLine]));
        nameObj.text = names[checkScriptLine];
        portraitImg.GetComponent<Image>().sprite = Resources.Load<Sprite>(portraits[checkScriptLine].ToString());
        nextStoryBtn.SetActive(false);
        Invoke("showNextBtn", 2.5f);

        monster1.SetActive(false);
        monster2.SetActive(false);
        monster3.SetActive(false);

    }

    void nextScript()
    {
        if (checkScriptLine < 3)
        {
            Click_sound.GetComponent<AudioSource>().Play();
            ++checkScriptLine;
            scriptObj.text = "";
            StartCoroutine(Typing(scripts[checkScriptLine]));
            nameObj.text = names[checkScriptLine];
            portraitImg.GetComponent<Image>().sprite = Resources.Load<Sprite>(portraits[checkScriptLine]);

            Debug.Log("Show Next Script");
            nextStoryBtn.SetActive(false);
            Invoke("showNextBtn", 2.5f);
        }
        else
        {
            Click_sound.GetComponent<AudioSource>().Play();
            backgroundImg.SetActive(false);
            characterImg.SetActive(false);
            nameObj.gameObject.SetActive(false);
            scriptObj.gameObject.SetActive(false);
            nextStoryBtn.SetActive(false);
            Player_Script.is_script_time = false;
            monster1.SetActive(true);
            monster2.SetActive(true);
            monster3.SetActive(true);
        }
    }

    void showNextBtn()
    {
        nextStoryBtn.SetActive(true);
    }

    IEnumerator Typing(string text)
    {
        foreach (char letter in text.ToCharArray())
        {
            scriptObj.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
