using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCamHeight : MonoBehaviour
{   

    public GameObject MiniCam;
    float y;

    private void Start()
    {
        y = MiniCam.transform.position.y;
    }

    void Update()

    {
        if (y > 81)
        {
            print("NOOOOOOO");
            y = 80;
        }
    }
}
