using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;

public class Mid_talking : MonoBehaviour
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
    public GameObject Click_sound;

    // Start is called before the first frame update
    void Start()
    {
        portraitImg = characterImg.GetComponent<Image>();
        // 스크립트 작성하는 곳
        names.Add("주인공");
        names.Add("나레이션");
        names.Add("나레이션");
        names.Add("[쪽지]");

        portraits.Add("Images/Hero_question");
        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Portrait_empty");

        scripts.Add("잠깐… 아래 이 사진은 뭐지?");
        scripts.Add("바닥에서 일부가 검게 그을린 사진을 발견했다. 사진속에는 화목한 가족의 모습이 담겨있다.");
        scripts.Add("뒷편에는 짧은 쪽지가 적혀있다.");
        scripts.Add("아마 나는 여기까지 인 것같다. 소중한 나의 가족들아.. 평범한 일상을 되찾아 주지 못해 미안하다. 부디 이 쪽지가 누군가에게 발견되길.. 그리고 꼭 마녀를 물리쳐 온 세상이 빛으로 가득한 평범한 날들을 되찾길…");

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
            if (checkScriptLine == 3)
            {
                Invoke("showNextBtn", 6.0f);
            }
            else
            {
                Invoke("showNextBtn", 2.5f);
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
