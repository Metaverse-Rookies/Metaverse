using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateAvatar : MonoBehaviour
{
    string      avatarGender;
    string      avatarName;
    GameObject  avatarManager;
    public GameObject  avatar;

    // 씬 이동 저장을 위한 변수
    public string prevScene;
    public string thisScene;

    
    void Update(){
        // 씬 전환
        string newScene = SceneManager.GetActiveScene().name;

        if(thisScene != newScene){
            prevScene = thisScene;
            thisScene = newScene;
         
            if(prevScene == "Apartment" && thisScene == "MainScene")
            {
                GameObject target = GameObject.Find("TargetPosition1");
                this.transform.position = target.transform.position;
            }
            else if(prevScene == "40Apartment" && thisScene == "MainScene")
            {
                GameObject target = GameObject.Find("TargetPosition2");
                this.transform.position = target.transform.position;
            }
            else {
                if(thisScene != "LoginScene"){
                    GameObject target = GameObject.Find("StartPoint");
                    this.transform.position = target.transform.position;
                }
            }
        }
    }
}