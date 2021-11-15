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

    // Start is called before the first frame update
    void Awake()
    {
        //다른 스크립트 파일의 변수 접근 법
        // GameObject.Find("다른 스크립트 파일이 들어있는 오브젝트")
        avatarManager = GameObject.Find("GameObject");
        avatarGender = avatarManager.GetComponent<ChangeScene>().genderButton;
        avatarName = avatarManager.GetComponent<ChangeScene>().name;
        Debug.Log(avatarName);
        GameObject childName = transform.Find("Name").gameObject;
        childName.GetComponent<TextMesh>().text = avatarName;
        childName.GetComponent<TextMesh>().characterSize = .5f;
    }

    // Update is called once per frame
    void Start()
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
}
