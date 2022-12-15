using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;

public class Under_room_text_script3 : MonoBehaviour
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
        names.Add("아네모네");
        names.Add("나레이션");
        names.Add("주인공");
        names.Add("아네모네");
        names.Add("주인공");
        names.Add("아네모네");

        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Hero_common");
        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Hero_common");
        portraits.Add("Images/Portrait_empty");

        scripts.Add("대단한데? 내 힘을 이렇게나 잘 다루다니… 여튼, 내가 지금 이 상황을 설명해 줄게!");
        scripts.Add("그렇게 아네모네는 주인공에게 지금의 사태에 대해서 자세하게 설명해주었습니다.");
        scripts.Add("아니… 그렇다면 이 모든 게 어둠의 마녀가 일으킨 짓이라고?");
        scripts.Add("그래, 우리 둘이 힘을 합쳐 어둠의 마녀를 봉인시키면 예전처럼 돌아갈 수 있어!");
        scripts.Add("오케이, 나 노력해 볼게!");
        scripts.Add("좋았어! 일단 이 지하실에서 나가자… 먼지가 너무 날린다…");


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
