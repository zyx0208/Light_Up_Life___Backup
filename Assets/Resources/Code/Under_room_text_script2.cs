using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;

public class Under_room_text_script2 : MonoBehaviour
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

    public GameObject Lamp_light;
    public GameObject Player_Flash_light;
    public GameObject Player_Lamp_light;

    // Start is called before the first frame update
    void Start()
    {
        portraitImg = characterImg.GetComponent<Image>();
        // 스크립트 작성하는 곳
        names.Add("???");
        names.Add("주인공");
        names.Add("아네모네");
        names.Add("주인공");
        names.Add("아네모네");
        names.Add("아네모네");
        names.Add("주인공");
        names.Add("나레이션");

        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Hero_help");
        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Hero_common");
        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Hero_common");
        portraits.Add("Images/Portrait_empty");

        scripts.Add("사람… 아니 요정 살려! 여기 요정 있어요!");
        scripts.Add("뭐야! 여기엔 나밖에 없는데… 설마 귀신?");
        scripts.Add("네 앞에 안보여? 나야 나, 아네모네! 지금 밖에 빛의 가호가 많이 약해졌지?");
        scripts.Add("무… 무슨! 너는 누구고 이 사태에 대해서 어떻게 알고 있는거야?");
        scripts.Add("난 빛의 요정 아네모네, 날 여기서 내보내 주면 이 사태에 대해서 자세하게 알려줄게!");
        scripts.Add("일단 내 힘을 빌려줄 테니 우선 내 주변의 몬스터를 없애 줘!");
        scripts.Add("그… 그래, 일단 꺼내 줄게…");
        scripts.Add("(좌클릭을 통해 공격을 할 수 있습니다.)");

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
        if (checkScriptLine < 7)
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
            Player_Script.is_script_time = false;
            Lamp_light.SetActive(false);
            Player_Flash_light.SetActive(true);
            Player_Lamp_light.SetActive(true);
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
