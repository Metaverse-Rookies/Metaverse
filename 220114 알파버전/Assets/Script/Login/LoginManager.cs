using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class LoginManager : MonoBehaviour
{
    public TMP_InputField   id;
    public TMP_InputField   password;
    public TMP_Text         notify;
    GameObject       avatarName;

    void Start()
    {
        notify.text = "";
    }

    //아이디와 패스워드 저장함수
    public void SaveUserData()
    {
        // 둘중 하나 입력 안하면
        if (!CheckInput(id.text, password.text))
            return ;
        PlayerPrefs.SetString(id.text, password.text);
        //아이디 중복검사
        if (!PlayerPrefs.HasKey(id.text))   //동일한 키가 존재하는지 확인하기 위해 HasKey()
        {
            PlayerPrefs.SetString(id.text, password.text);
            notify.text = "아이디 생성이 완료됐습니다";
        }
        else
        {
            notify.text = "이미 존재하는 아이디입니다";
        }
    }
    
    // 로그인 함수
    public void CheckUserData()
    {
        // 유효성 검사
        if (!CheckInput(id.text, password.text))
            return ;
        // 사용자가 입력한 아이디를 키로 사용해 시스템에 저장된 값을 불러옴.
        string pass = PlayerPrefs.GetString(id.text);
        if (ChangeScene.genderButton == "Male")
            avatarName = GameObject.Find("NAME");
        else if (ChangeScene.genderButton == "Female")
            avatarName = GameObject.Find("Name");
        avatarName.GetComponent<TextMesh>().text = id.text;
        avatarName.GetComponent<TextMesh>().characterSize = .5f;
        Debug.Log("아바타생성");
        SceneManager.LoadScene("MainScene");
        GameObject.Find("PotalUI").GetComponent<Canvas>().enabled = false;
        /*if (password.text != pass)
        {
            notify.text = "입력하신 아이디와 패스워드가 일치하지 않습니다";
        }
        else
        {
            Debug.Log("아바타생성");
            SceneManager.LoadScene("MainScene");
        }*/
    }
    
    //아이디와 비번 안쓴거 있는지 확인
    bool CheckInput(string id, string pwd)
    {
        if (id == "" || pwd == "")
        {
            notify.text = "아이디 또는 패스워드를 입력해주세요";
            return false;
        }
        else
            return true;
    }
}
