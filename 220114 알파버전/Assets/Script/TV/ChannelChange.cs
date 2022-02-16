using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ChannelChange : MonoBehaviour
{
    public static GameObject document;
    public static GameObject ani;
    public static GameObject drama;

    public GameObject ui;

    // bool flag = false;

    //크기조절
    private Vector3 sizeFourty, sizeFifty, sizeSeventy, sizeEighty;
    private Vector3 positionWall, positionStand;
    public string nowChannel = "";
    public string nowSize = "40";
    public string nowType = "";

    public VideoPlayer videoPlayer;

    private MeshRenderer MeshRendererMode;
    
    public string commonUrl = "https://ktds-rookies-metaverse.s3.ap-northeast-2.amazonaws.com/Video/";

    public string videoUrl;


    TvChange tvchange;

    // Start is called before the first frame update
    void Start()
    {
        tvchange = GameObject.Find("TVs").GetComponent<TvChange>();

        document = transform.GetChild(0).gameObject;
        ani = transform.GetChild(1).gameObject;
        drama = transform.GetChild(2).gameObject;

        //처음엔 TV 꺼져있게
        document.SetActive(false);
        ani.SetActive(false);
        drama.SetActive(false);

        //인치별 크기조절
        sizeFourty = new Vector3(8.6f, 4.8f, 1.0f);
        sizeFifty = new Vector3(10.5f, 5.9f, 1.0f);
        sizeSeventy = new Vector3(13.60311f, 7.371057f, 1.0f);
        sizeEighty = new Vector3(17.49583f, 9.764557f, 1.0f);

        positionWall = new Vector3(24.27f, 4.86f, 10.59f);
        positionStand = new Vector3(24.27f, 2.87f, 9.6f);

    }

    public void changeChannel(string name)
    {
        nowType = tvchange.nowType;
        nowSize = tvchange.nowSize;

        // Debug.Log("현재"+nowType);
        for(int i=0;i<3;i++){
            GameObject temp = transform.GetChild(i).gameObject;
            if(name==temp.name)
            {
                videoPlay(temp);
                temp.SetActive(true);
                nowChannel = temp.name;

                //사이즈조절
                if (nowSize == "40")
                {
                    temp.transform.localScale = sizeFourty;
                }else if (nowSize == "50")
                {
                    temp.transform.localScale = sizeFifty;
                }else if (nowSize =="70")
                {
                    temp.transform.localScale = sizeSeventy;
                }else if (nowSize =="80")
                {
                    temp.transform.localScale = sizeEighty;
                }

                //위치조절
                if (nowType == "Stand")
                {
                    temp.transform.localPosition = positionStand;
                    if(nowSize=="70"){
                        temp.transform.localPosition += new Vector3(0.0f, 1.0f, 0.0f);
                    }else if(nowSize=="80"){
                        temp.transform.localPosition += new Vector3(0.0f, 2.3f, 0.0f);
                    }else{
                        
                    }
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
        for(int i=0;i<3;i++){
            GameObject channel = transform.GetChild(i).gameObject;
            if(nowChannel==channel.name){
                if (size == "40")
                {
                    channel.transform.localScale=sizeFourty;
                }
                else if(size == "50")
                {
                    channel.transform.localScale=sizeFifty;
                }else if (size =="70")
                {
                    channel.transform.localScale = sizeSeventy;
                }else if (size =="80")
                {
                    channel.transform.localScale = sizeEighty;
                }
                nowSize = size;
            }


            //위치조절
            if (nowType == "Stand")
            {
                channel.transform.localPosition = positionStand;
                if(nowSize=="70"){
                    channel.transform.localPosition += new Vector3(0.0f, 1.0f, 0.0f);
                }else if(nowSize=="80"){
                    channel.transform.localPosition += new Vector3(0.0f, 2.3f, 0.0f);
                }else{
                    
                }
            }
            else
            {
                channel.transform.localPosition = positionWall;
            }

        }
        
    }

    public void videoPlay(GameObject channel){
        videoUrl = commonUrl + channel.name + ".mp4";
        videoPlayer.url = videoUrl;
        MeshRendererMode = channel.GetComponent<MeshRenderer>();
        videoPlayer.targetMaterialRenderer = MeshRendererMode;
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.EnableAudioTrack (0, true);
        videoPlayer.Prepare ();
    }
}
