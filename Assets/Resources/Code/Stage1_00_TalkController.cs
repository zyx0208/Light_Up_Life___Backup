using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;

public class Stage1_00_TalkController : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        portraitImg = characterImg.GetComponent<Image>();
        // 스크립트 작성하는 곳
        names.Add("나레이션");
        names.Add("주인공");
        names.Add("나레이션");
        names.Add("주인공");
        names.Add("주민들");
        names.Add("주인공");

        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Hero_common");
        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Hero_help");
        portraits.Add("Images/Citizen_surprise");
        portraits.Add("Images/Hero_question");

        scripts.Add("빛을 잃기 하루 전, 주인공이 사는 마을의 게시판에는 공지가 붙었습니다.");
        scripts.Add("아니... 빛의 가호가 점점 줄어든다니... 이게 무슨...");
        scripts.Add("하루가 지나고, 주인공은 마을에 어둠이 내린 것을 목격하게 되었습니다.");
        scripts.Add("이럴 수가... 어제만해도 밝았는데, 공지가 사실이었어?");
        scripts.Add("저길 봐! 저기에서 빛이 새어나오고 있어!");
        scripts.Add("어... 어디! 어라? 저긴 우리 집 지하실 입구인데...");


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
            backgroundImg.SetActive(false);
            characterImg.SetActive(false);
            nameObj.gameObject.SetActive(false);
            scriptObj.gameObject.SetActive(false);
            nextStoryBtn.SetActive(false);
            PlayerController.is_script_time = false;
        }
    }

    void showNextBtn()
    {
        nextStoryBtn.SetActive(true);
    }

    IEnumerator Typing(string text)
    {
        foreach(char letter in text.ToCharArray())
        {
            scriptObj.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
