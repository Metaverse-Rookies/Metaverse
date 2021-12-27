using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnOnClick : MonoBehaviour
{
    public GameObject popup;
    public Button btn;
    
    public bool isClicked = false;

    public void ButtonClick(){
        isClicked = true;
        //Debug.Log(isClicked);

        if(isClicked){
            popup.SetActive(false);
            //Debug.Log("Close");
        }
    }

    /*
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = testCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))
            {
                popup.SetActive(true);
            }
        }
    }
    */
}
