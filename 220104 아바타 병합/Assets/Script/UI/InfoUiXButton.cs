using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoUiXButton : MonoBehaviour
{
    public GameObject popup;
    bool popup_flag;

    public void BtnOnClick()
    {
        popup_flag = popup.GetComponent<Canvas>().enabled;

        if(popup_flag)
        {
            popup.GetComponent<Canvas>().enabled = false;
        }
    }
}
