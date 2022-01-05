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

    void Start() {
        popup = GameObject.Find("AvatarInfoUI");
        popup_flag = popup.GetComponent<Canvas>().enabled;
    }

    void OnMouseDown() {
        if (!popup_flag)
        {
            popup.GetComponent<Canvas>().enabled = true;
            name = avatarName.GetComponent<TextMesh>().text;
            print(name);
            id.GetComponent<Text>().text = name;
        }
    }
}
