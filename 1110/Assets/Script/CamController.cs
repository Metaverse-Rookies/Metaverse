using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera overheadCamera;
    public bool one = false;
    void Update()
    {
        //스페이스바 누르면 전환
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (one)
            {
                ShowOverheadView();
                one = false;
            }
            else
            {
                ShowFirstPersonView();
                one = true;
            }
        
        }

    }


    public void ShowOverheadView()
    {
        mainCamera.enabled = false;
        overheadCamera.enabled = true;
    }

    public void ShowFirstPersonView()
    {
        mainCamera.enabled = true;
        overheadCamera.enabled = false;
    }
}