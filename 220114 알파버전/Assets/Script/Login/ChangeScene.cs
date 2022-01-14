using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ChangeScene : MonoBehaviour
{
    public string nowButton;
    public static string genderButton;
    public string name;
    public TMP_InputField nameInputField;
    public GameObject maleAvatar;
    public GameObject femaleAvatar;
    

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(GameObject.Find("AvatarInfoUI"));
        DontDestroyOnLoad(GameObject.Find("PotalUI"));
    }

    private void Start()
    {
        nameInputField.onEndEdit.AddListener(ValueChanged);
    }
    public void ButtonClick()
    {
        // 현재 게임오브젝트의 이름을 저장한다
        genderButton = EventSystem.current.currentSelectedGameObject.name;
        if (genderButton == "Male")
        {
            Debug.Log("남자");
            maleAvatar.SetActive(true);
            femaleAvatar.SetActive(false);
            DontDestroyOnLoad(GameObject.Find("PlayerArmatureMale"));
        }
        else if (genderButton == "Female")
        {
            Debug.Log("여자");
            femaleAvatar.SetActive(true);
            maleAvatar.SetActive(false);
            DontDestroyOnLoad(GameObject.Find("PlayerArmature"));
        }
    }
    // Update is called once per frame
    /*public void SceneChange()
    {
        nowButton = EventSystem.current.currentSelectedGameObject.name;
        if (nowButton == "Login")
        {
            Debug.Log("아바타생성");
            SceneManager.LoadScene("MainScene");
        }
    }*/

    public void ValueChanged(string text)
	{
        name = text;
		Debug.Log (name);
	}
}
