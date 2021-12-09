using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSelect : MonoBehaviour
{
    //public GameObject obj;
    public bool isClicked = false;
    
    public static string type = "";
    public static string size = "";
    public static string channel = "";
    public static string quailty = "";
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
        isClicked = true;
        string name = this.gameObject.name;
        string parent = transform.parent.gameObject.name;

        if (parent.Equals("Type"))
        {
            type = name;
            tvchange.changeTV(type);
        }else if (parent.Equals("Size"))
        {
            size = name;
            tvchange.resize(size);
            channelChange.resize(size);
        }else if (parent.Equals("Channel"))
        {
            channel = name;
            channelChange.changeChannel(channel);
        }
        else if (parent.Equals("Quality")){
            quailty = name;
            qualityChange.changeQuality(quailty);
        }
            
    }
}