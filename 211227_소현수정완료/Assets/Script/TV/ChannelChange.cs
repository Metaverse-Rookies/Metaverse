using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChannelChange : MonoBehaviour
{
    GameObject document;
    GameObject animation;
    GameObject drama;

    public GameObject ui;

    // bool flag = false;

    //크기조절
    private Vector3 sizeFourty, sizeFifty;
    private Vector3 positionWall, positionStand;
    public string nowChannel = "";
    public string nowSize = "40";
    public string nowType = "";

    TvChange tvchange;

    // Start is called before the first frame update
    void Start()
    {
        tvchange = GameObject.Find("TVs").GetComponent<TvChange>();

        document = transform.GetChild(0).gameObject;
        animation = transform.GetChild(1).gameObject;
        drama = transform.GetChild(2).gameObject;

        //처음엔 TV 꺼져있게
        document.SetActive(false);
        animation.SetActive(false);
        drama.SetActive(false);

        //인치별 크기조절
        sizeFourty = new Vector3(8.6f, 4.8f, 1.0f);
        sizeFifty = new Vector3(10.5f, 5.9f, 1.0f);

        positionWall = new Vector3(24.27f, 4.86f, 10.59f);
        positionStand = new Vector3(24.27f, 2.87f, 9.6f);

        //기본 크기
        drama.transform.localScale = sizeFourty;

        //기본 위치
        drama.transform.localPosition = positionWall;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void changeChannel(string name)
    {
        nowType = tvchange.nowType;
        nowSize = tvchange.nowSize;

        // Debug.Log("현재"+nowType);
        for(int i=0;i<3;i++){
            GameObject temp = transform.GetChild(i).gameObject;
            if(name==temp.name){
                temp.SetActive(true);
                nowChannel = temp.name;

                //사이즈조절
                if (nowSize == "40")
                {
                    temp.transform.localScale = sizeFourty;

                }else if (nowSize == "50")
                {
                    temp.transform.localScale = sizeFifty;
                }

                //위치조절
                if (nowType == "Stand")
                {
                    temp.transform.localPosition = positionStand;
                }
                else
                {
                    temp.transform.localPosition = positionWall;
                }
            }else{
                temp.SetActive(false);
            }
        }
        // flag = true;
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
