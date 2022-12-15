using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;

public class Boss_Start : MonoBehaviour
{
    // Start is called before the first frame update
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
    public GameObject Click_sound;

    // Start is called before the first frame update
    void Start()
    {
        portraitImg = characterImg.GetComponent<Image>();
        // 스크립트 작성하는 곳
        names.Add("나레이션");
        names.Add("주인공");
        names.Add("아네모네");
        names.Add("주인공");
        names.Add("아네모네");
        names.Add("주인공");

        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Hero_help");
        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Hero_help");
        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Hero_common");

        scripts.Add("수많은 시체가 뒤덮인 검은 산이 주인공 일행을 반겨주었다.");
        scripts.Add("아니… 도대체 이게 무슨 일이 일어난거지?");
        scripts.Add("수많은 사람들이 빛의 가호를 되찾기 위해 이 곳에 왔다는 사실은 알고 있었지만 이정도로 많은 사람들이 희생되었을거라곤…");
        scripts.Add("나도… 결국은 이렇게 되는걸까?");
        scripts.Add("아니야, 너라면 마녀를 쓰러뜨릴 수 있어! 우리 지금까지 잘 극복해 왔잖아!");
        scripts.Add("그래, 우선은 부딪쳐 보자!");

        // 일반 코드
        nextBtn.onClick.AddListener(nextScript);

        checkScriptLine = 0;
        scriptObj.text = "";
        StartCoroutine(Typing(scripts[checkScriptLine]));
        nameObj.text = names[checkScriptLine];
        portraitImg.GetComponent<Image>().sprite = Resources.Load<Sprite>(portraits[checkScriptLine].ToString());
        nextStoryBtn.SetActive(false);
        Invoke("showNextBtn", 2.5f);
    }

    void nextScript()
    {
        if (checkScriptLine < 5)
        {
            Click_sound.GetComponent<AudioSource>().Play();
            ++checkScriptLine;
            scriptObj.text = "";
            StartCoroutine(Typing(scripts[checkScriptLine]));
            nameObj.text = names[checkScriptLine];
            portraitImg.GetComponent<Image>().sprite = Resources.Load<Sprite>(portraits[checkScriptLine]);

            Debug.Log("Show Next Script");
            nextStoryBtn.SetActive(false);
            if (checkScriptLine == 2)
            {
                Invoke("showNextBtn", 4.0f);
            }
            else
            {
                Invoke("showNextBtn", 3.0f);
            }
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
