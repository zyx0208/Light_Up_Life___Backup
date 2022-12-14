using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Ending_Story : MonoBehaviour
{
    public Text scriptObj;
    List<string> scripts = new List<string>();
    List<string> images = new List<string>();
    int checkScriptLine;
    public GameObject nextStoryBtn;
    public GameObject backgroundImg;
    public Image background;
    public Button nextBtn;

    // Start is called before the first frame update
    void Start()
    {
        background = backgroundImg.GetComponent<Image>();

        scripts.Add("빛을 뺏어간 악당을 물리치자, 세상은 다시 빛으로 가득 채워졌습니다.");
        scripts.Add("그리고 주인공은 왕국 사람들에게 환호를 받았습니다.");
        scripts.Add("새로운 영웅의 탄생이었죠.");
        scripts.Add("그러던 어느날,");
        scripts.Add("치킨");
        scripts.Add("먹고");
        scripts.Add("싶은");
        scripts.Add("나");

        images.Add("Images/Story_0_02_Background");
        images.Add("Images/the_hero");
        images.Add("Images/the_hero");
        images.Add("Images/Story_0_06_Background");
        images.Add("Images/Story_0_06_Background");
        images.Add("Images/Story_0_06_Background");
        images.Add("Images/Story_0_06_Background");
        images.Add("Images/Story_0_06_Background");

        nextBtn.onClick.AddListener(nextScript);

        checkScriptLine = 0;
        scriptObj.text = "";
        StartCoroutine(Typing(scripts[checkScriptLine]));
        background.GetComponent<Image>().sprite = Resources.Load<Sprite>(images[checkScriptLine].ToString());
        nextStoryBtn.SetActive(false);
        Invoke("showNextBtn", 4.0f);
    }

    void nextScript()
    {
        if (checkScriptLine < 7)
        {
            ++checkScriptLine;
            scriptObj.text = "";
            StartCoroutine(Typing(scripts[checkScriptLine]));
            background.GetComponent<Image>().sprite = Resources.Load<Sprite>(images[checkScriptLine].ToString());
            Debug.Log("Show Next Script");
            nextStoryBtn.SetActive(false);
            Invoke("showNextBtn", 4.0f);
        }
        else
        {
            SceneManager.LoadScene("1_MainMenu");
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
