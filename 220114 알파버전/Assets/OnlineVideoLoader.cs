using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
 
public class OnlineVideoLoader : MonoBehaviour
{
    public GameObject _Channels; 
    public VideoPlayer videoPlayer;
    public string videoCommonUrl = "https://ktds-rookies-metaverse.s3.ap-northeast-2.amazonaws.com/Video/";
    private string videoUrl;
    private MeshRenderer MeshRendererMode;
    // Start is called before the first frame update
    void Start()
    {
        GameObject tempObject;

        videoUrl = "Animation.mp4";
        if (videoUrl.Contains("Drama"))
        {
            tempObject = _Channels.transform.GetChild(2).gameObject;
            MeshRendererMode = tempObject.GetComponent<MeshRenderer>();
        }
        else if (videoUrl.Contains("Document"))
        {
            tempObject = _Channels.transform.GetChild(0).gameObject;
            MeshRendererMode = tempObject.GetComponent<MeshRenderer>();
        }
        else
        {
            tempObject = _Channels.transform.GetChild(1).gameObject;
            MeshRendererMode = tempObject.GetComponent<MeshRenderer>();
        }
        
        videoPlayer.targetMaterialRenderer = MeshRendererMode;
        videoPlayer.url = videoCommonUrl + videoUrl;
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.EnableAudioTrack (0, true);
        videoPlayer.Prepare ();
    }
 
    // Update is called once per frame
    void Update()
    {
         
    }
}