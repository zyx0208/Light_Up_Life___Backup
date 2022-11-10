using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startbutton_UI_Script : MonoBehaviour
{
    public Camera starting_ui_camera;
    public Camera other_camera_1;
    public GameObject player;

    void Start()
    {
        starting_ui_camera.enabled = true;
        other_camera_1.enabled = false;
        player.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 p = Input.mousePosition;
            Ray cast = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if ((Physics.Raycast(cast, out hit))&&(hit.collider.tag == "Button"))
            {
                starting_ui_camera.enabled = false;
                other_camera_1.enabled = true;
                player.SetActive(true);
            }
        }
    }
}
