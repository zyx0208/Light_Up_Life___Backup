using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallManager : MonoBehaviour
{
    // Start is called before the first frame update
     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
