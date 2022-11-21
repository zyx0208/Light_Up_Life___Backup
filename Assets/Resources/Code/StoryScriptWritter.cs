using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StoryScriptWritter : MonoBehaviour
{
    public Text scriptObj;
    List<string> scripts = new List<string>();
    int checkScriptLine;
    public GameObject nextStoryBtn;
    public Button nextBtn;

    // Start is called before the first frame update
    void Start()
    {
        scripts.Add("빛의 가호를 받으며 살아가는 '만다린 왕국'");
        scripts.Add("왕국은 빛을 사용한 마법으로 크게 번영하여 모두가 행복한 삶을 살았습니다.");
        scripts.Add("왕국은 빛의 마법을 담은 크리스탈을 왕국 곳곳에 두어 이 삶이 영원하길 바랐습니다.");
        scripts.Add("그러던 어느날, 알 수 없는 이유로 빛의 가호가 점점 약해지기 시작했고");
        scripts.Add("왕국 사람들은 빛을 잃어가는 크리스탈을 보고 불안해 했습니다.");
        scripts.Add("빛의 가호가 약해지고 하루 뒤,");
        scripts.Add("모든 빛이 사라지고 세상은 어둠으로 뒤덮이게 되었습니다.");
        scripts.Add("그러나, 단 한 집에서 약한 불빛이 보이고 있었는데...");

        nextBtn.onClick.AddListener(nextScript);

        checkScriptLine = 0;
        scriptObj.text = "";
        StartCoroutine(Typing(scripts[checkScriptLine]));
        nextStoryBtn.SetActive(false);
        Invoke("showNextBtn", 4.0f);
    }

    void nextScript()
    {
        if (checkScriptLine < 7) {
            ++checkScriptLine;
            scriptObj.text = "";
            StartCoroutine(Typing(scripts[checkScriptLine]));
            Debug.Log("Show Next Script");
            nextStoryBtn.SetActive(false);
            Invoke("showNextBtn", 4.0f);
        }
        else
        {
            SceneManager.LoadScene("Stage1_00_Scene");
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
