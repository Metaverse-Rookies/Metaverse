using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
 
public class OnlineVideoLoader : MonoBehaviour
{
     
    public VideoPlayer videoPlayer;
    public string videoUrl = "https://ktds-rookies-metaverse.s3.ap-northeast-2.amazonaws.com/Video/Drama.mp4";
     
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.url = videoUrl;
        videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
        videoPlayer.EnableAudioTrack (0, true);
        videoPlayer.Prepare ();
    }
 
    // Update is called once per frame
    void Update()
    {
         
    }
}