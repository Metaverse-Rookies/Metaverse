using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnOnClick : MonoBehaviour
{
    public GameObject popup;
    public GameObject recommendPopup;
    public Button btn;
    private GameObject[] buttons;
    public bool isClicked = false;


    void Start(){
        buttons = new GameObject[4];
        buttons[0] = GameObject.Find("Type");
        buttons[1] = GameObject.Find("Size");
        buttons[2] = GameObject.Find("Channel");
        buttons[3] = GameObject.Find("Quality");
    }

    public void ButtonClick(){
        isClicked = true;
        Debug.Log(isClicked);

        if(isClicked){
            if(this.transform.parent.name == "PopupUi"){
                for(int i = 0; i < buttons.Length; i++){
                    for(int j = 1; j < buttons[i].transform.childCount; j++){
                        buttons[i].transform.GetChild(j).GetComponent<Image>().color = new Color(255/255f, 255/255f, 255/255f);
                    }
                }
            }
            popup.SetActive(false);
            Debug.Log("window Close");
            isClicked = false;
            ChannelChange.document.SetActive(false);
            ChannelChange.ani.SetActive(false);
            ChannelChange.drama.SetActive(false);
        }
    }

    public void RecommendButtonClick()
    {
        isClicked = true;
        Debug.Log(isClicked);

        if (isClicked)
        {
            recommendPopup.SetActive(true);
            popup.GetComponent<Canvas>().enabled = false;
            Debug.Log("TV Recommend window Open");
            isClicked = false;
        }
    }

    public void RecommendOutButtton()
    {
        isClicked  = true;
        Debug.Log(isClicked);

        if (isClicked)
        {
            for(int i = 0; i < buttons.Length; i++){
                for(int j = 1; j < buttons[i].transform.childCount; j++){
                    buttons[i].transform.GetChild(j).GetComponent<Image>().color = new Color(255/255f, 255/255f, 255/255f);
                }
            }
            OptionSelect.type = "";
            OptionSelect.size = "";
            OptionSelect.channel = "";
            OptionSelect.quality = "";

            recommendPopup.SetActive(false);
            popup.GetComponent<Canvas>().enabled = true;
            Debug.Log("TV Recommend window Close");

            isClicked = false;
            ChannelChange.document.SetActive(false);
            ChannelChange.ani.SetActive(false);
            ChannelChange.drama.SetActive(false);
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
