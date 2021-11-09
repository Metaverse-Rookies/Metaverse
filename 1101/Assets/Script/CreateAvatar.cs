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
        avatarGender = avatarManager.GetComponent<ChangeScene>().genderButton;
    }

    // Update is called once per frame
    void Update()
    {
        if (avatarGender == "Male")
        {
            Debug.Log("여자 캐릭터를 가린다");
            avatar.SetActive(false);
        }
        else if (avatarGender == "Female")
        {
            Debug.Log("남자 캐릭터를 가린다");
            avatar.SetActive(true);
        }

    }
/*
   void PressBtnB() {

	// B 버튼 눌렀을 때 A버튼의 onClick 이벤트 끊기.
	btnA.onClick.RemoveListener(DoSomething) ;

    }
    void PressBtnB() {

	// B 버튼 눌렀을 때 A버튼의 onClick 이벤트 끊기.
	btnA.onClick.RemoveListener(DoSomething) ;

    }*/
}
