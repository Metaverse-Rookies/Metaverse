using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnOnClick : MonoBehaviour
{
    public GameObject popup;
    public GameObject recommendPopup;
    public Button btn;
    
    public bool isClicked = false;

    public void ButtonClick(){
        isClicked = true;
        Debug.Log(isClicked);

        if(isClicked){
            popup.SetActive(false);
            Debug.Log("Tv Popup window Close");
        }
    }

    public void RecommendButtonClick()
    {
        isClicked = true;
        Debug.Log(isClicked);

        if (isClicked)
        {
            recommendPopup.SetActive(true);
            Debug.Log("TV Recommend window Open");
        }
    }

    public void RecommendOutButtton()
    {
        isClicked  = true;
        Debug.Log(isClicked);

        if (isClicked)
        {
            recommendPopup.SetActive(false);
            Debug.Log("TV Recommend window Close");
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
