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
    public GameObject Click_sound;

    // Start is called before the first frame update
    void Start()
    {
        background = backgroundImg.GetComponent<Image>();

        scripts.Add("그렇게 주인공은 마녀를 물리치는데 성공하고,");
        scripts.Add("온 세상은 아무일 없었다는 듯 다시 밝게 빛나기 시작했습니다.");
        scripts.Add("아네모네는 감사를 전하며 다른 왕국들을 살펴보고 오겠다며 떠났습니다.");
        scripts.Add("시간이 지나고...");
        scripts.Add("만다린 왕국에서 살아가던 어느 날, 한 소녀가 주인공을 찾아왔습니다.");
        scripts.Add("\"저기...\"");
        scripts.Add("주인공은 순간 놀라 말을 잇지 못했습니다.");
        scripts.Add("동굴 속 액자에서 봤던 그 소녀가 주인공의 눈 앞에 서있었기 때문입니다.");
        scripts.Add("\"당신이 아버지의 뜻을 이뤄주셨군요...\"");
        scripts.Add("\"우리 가족, 아니 이 세상 모든 사람의 삶을 다시 밝게 만들어 주셔서 감사해요.\"");
        scripts.Add("[ LIGHT UP LIFE ]");

        images.Add("Images/the_hero");
        images.Add("Images/Story_0_02_Background");
        images.Add("Images/yojeong");
        images.Add("Images/Story_0_06_Background");
        images.Add("Images/girl");
        images.Add("Images/girl");
        images.Add("Images/girl");
        images.Add("Images/girl");
        images.Add("Images/girl");
        images.Add("Images/girl");
        images.Add("Images/Ending");

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
        if (checkScriptLine < 10)
        {
            Click_sound.GetComponent<AudioSource>().Play();
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
            Click_sound.GetComponent<AudioSource>().Play();
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
