using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChannelChange : MonoBehaviour
{
    GameObject document;
    GameObject animation;
    GameObject drama;

    public GameObject ui;

    bool flag = false;

    //크기조절
    private Vector3 sizeFourty, sizeFifty;
    public string nowChannel = "ANI";
    public string nowSize = "40";
    TvChange tvchange;

    // Start is called before the first frame update
    void Start()
    {
        tvchange = GameObject.Find("TVs").GetComponent<TvChange>();

        document = transform.GetChild(0).gameObject;
        animation = transform.GetChild(1).gameObject;
        drama = transform.GetChild(2).gameObject;

        //채널 하나만 보이게
        document.SetActive(false);
        animation.SetActive(false);

        //인치별 크기조절
        sizeFourty = new Vector3(8.0f, 8.0f, 8.0f);
        sizeFifty = new Vector3(10.0f, 10.0f, 10.0f);

        //기본 크기
        drama.transform.localScale = sizeFourty;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            ui.SetActive(true);
        }
    }
    public void changeChannel(string name)
    {
        for(int i=0;i<3;i++){
            GameObject temp = transform.GetChild(i).gameObject;
            if(name==temp.name){
                temp.SetActive(true);
                nowChannel = temp.name;
                if (nowSize == "40")
                {
                    temp.transform.localScale = sizeFourty;
                }else if (nowSize == "50")
                {
                    temp.transform.localScale = sizeFifty;
                }
            }else{
                temp.SetActive(false);
            }
        }
        flag = true;
    }

    public void resize(string size)
    {
        GameObject channelName = transform.Find(nowChannel).gameObject;
        if (size == "40")
        {
            channelName.transform.localScale=sizeFourty;
            nowSize = "40";
        }
        else if(size == "50")
        {
            channelName.transform.localScale=sizeFifty;
            nowSize = "50";
        }
    }
}
