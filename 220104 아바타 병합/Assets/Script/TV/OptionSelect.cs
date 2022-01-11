using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionSelect : MonoBehaviour
{
    int cnt = 1;
    public static string type = "";
    public static string size = "";
    public static string channel = "";
    public static string quality = "";
    TvChange tvchange;
    ChannelChange channelChange;
    QualityChange qualityChange;

    void Start()
    {
        tvchange = GameObject.Find("TVs").GetComponent<TvChange>();
        channelChange = GameObject.Find("Channels").GetComponent<ChannelChange>();
        qualityChange = GameObject.Find("Blurs").GetComponent<QualityChange>();
    }

    void Update()
    {
        Cursor.visible = true;
    }

    public void ButtonClick()
    {
        // isClicked = true;
        // 부모의 자식들을 다 원래색으로 바꿔주고 
        for(int i = 1; i < gameObject.transform.parent.childCount; i++){
            gameObject.transform.parent.GetChild(i).GetComponent<Image>().color = new Color(255/255f, 255/255f, 255/255f);
        }
        // 나만 어두운색으로 바꿈
        gameObject.GetComponent<Image>().color = new Color(103/255f, 154/255f, 195/255f);
        string name = this.gameObject.name;
        string parent = transform.parent.gameObject.name;

        if (parent.Equals("Type"))
        {
            type = name;
            //obj = GameObject.Find("Category");
            // quality = qualityChange.nowQuality;
            tvchange.changeTV(type);
            channelChange.changeChannel(channel);
            qualityChange.changeQuality(quality);

        }else if (parent.Equals("Size"))
        {
            size = name;
            tvchange.resize(size);
            channelChange.resize(size);
            qualityChange.resize(size);
        }else if (parent.Equals("Channel"))
        {
            channel = name;
            channelChange.changeChannel(channel);
        }
        else if (parent.Equals("Quality")){
            quality = name;
            qualityChange.changeQuality(quality);
        }
            
        cnt = 3;
    }
    
}