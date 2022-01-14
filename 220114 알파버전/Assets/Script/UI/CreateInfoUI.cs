using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CreateInfoUI : MonoBehaviour
{
    GameObject popup;
    bool popup_flag;
    string name;
    public GameObject avatarName;
    // public TMP_Text avatarName; 
    public GameObject id;
    public GameObject gender;
    void Start() {
        popup = GameObject.Find("AvatarInfoUI");
        // popup_flag = popup.GetComponent<Canvas>().enabled;
        popup.SetActive(false);
    }

    void OnMouseDown() {
        if(!GameObject.FindGameObjectWithTag("Canvas") && GameObject.Find("PotalUI").GetComponent<Canvas>().enabled == false)
        {
            // popup.GetComponent<Canvas>().enabled = true;
            popup.SetActive(true);
            name = avatarName.GetComponent<TextMesh>().text;
            id.GetComponent<Text>().text = name;
            gender.GetComponent<Text>().text = ChangeScene.genderButton;
        }
        /*
        if (!popup_flag)
        {
            popup_flag = true;
            popup.GetComponent<Canvas>().enabled = true;
            name = avatarName.GetComponent<TextMesh>().text;
            id.GetComponent<Text>().text = name;
            gender.GetComponent<Text>().text = ChangeScene.genderButton;
        }
        */
    }
}
