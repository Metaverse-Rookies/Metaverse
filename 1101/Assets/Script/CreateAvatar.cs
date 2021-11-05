using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateAvatar : MonoBehaviour
{
    string      avatarGender;
    GameObject  avatarManager;
    public GameObject  avatar;
    // Start is called before the first frame update
    void Start()
    {
        //다른 스크립트 파일의 변수 접근 법
        // GameObject.Find("다른 스크립트 파일이 들어있는 오브젝트")
        avatarManager = GameObject.Find("GameObject");
        avatarGender = avatarManager.GetComponent<ChangeScene>().nowButton;
    }

    // Update is called once per frame
    void Update()
    {
        if (avatarGender == "CreateAvatar")
        {
            Debug.Log("성공");
            avatar.SetActive(false);
        }
        else
        {
            Debug.Log("실패");
            avatar.SetActive(true);
        }
    }
}
