using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Runtime.InteropServices;

public class Donggul2_Start : MonoBehaviour
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
    public GameObject monster;
    public GameObject Click_sound;

    // Start is called before the first frame update
    void Start()
    {
        portraitImg = characterImg.GetComponent<Image>();
        // 스크립트 작성하는 곳
        names.Add("아네모네");
        names.Add("주인공");
        names.Add("주인공");
        names.Add("아네모네");
        names.Add("주인공");
        names.Add("아네모네");

        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Hero_help");
        portraits.Add("Images/Hero_help");
        portraits.Add("Images/Portrait_empty");
        portraits.Add("Images/Hero_common");
        portraits.Add("Images/Portrait_empty");

        scripts.Add("앗… 여긴 더 강력한 몬스터가 있어! 어둠의 마녀… 꽤 힘을 썼는걸?");
        scripts.Add("저 몬스터는 뭐야? 책에서도 한 번도 보지 못 한거 같은데…");
        scripts.Add("그리고 이 동굴, 예전에 한 번도 보지 못한 동굴인데 이렇게 깊다고?");
        scripts.Add("여튼, 저 몬스터는 아까 층의 동굴 몬스터보다 더 높은 내구도를 가지고 있어! 처리하는데 많은 시간이 걸릴 거야.");
        scripts.Add("걱정 마, 근성이야말로 내 자랑거리니까!");
        scripts.Add("좋아! 그리고 저 물 근처는 오염된거 같아... 조심해!");

        // 일반 코드
        nextBtn.onClick.AddListener(nextScript);

        checkScriptLine = 0;
        scriptObj.text = "";
        StartCoroutine(Typing(scripts[checkScriptLine]));
        nameObj.text = names[checkScriptLine];
        portraitImg.GetComponent<Image>().sprite = Resources.Load<Sprite>(portraits[checkScriptLine].ToString());
        nextStoryBtn.SetActive(false);
        Invoke("showNextBtn", 2.5f);
        monster.SetActive(false);
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
            if (checkScriptLine == 3)
            {
                Invoke("showNextBtn", 3.5f);
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
            monster.SetActive(true);
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
