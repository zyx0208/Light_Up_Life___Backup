using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lake_Script : MonoBehaviour
{
    void OnInvokeL()
    // 호수에 닿으면 3초뒤 익사하여 씬 리로드되는 코드
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            /*리로드 씬 */
            Debug.Log("익사합니다");
            Invoke("OnInvokeL", 3.0f);

        }
    }
}
