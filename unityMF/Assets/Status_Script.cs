using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status_Script : MonoBehaviour
{
    public float startTime;
    public float minX, maxX;

    [Range(1, 100)]
    public float moveSpeed;

    private int sign = -1;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= startTime)
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime * sign, 0, 0);

            if (transform.position.x <= minX || transform.position.x >= maxX)
            {
                sign *= -1;
            }
        }
    }


}
