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
    public string genderButton;
    public string name;
    public TMP_InputField nameInputField;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
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
            Debug.Log("남자");
        else if (genderButton == "Female")
            Debug.Log("여자");
    }
    // Update is called once per frame
    public void SceneChange()
    {
        nowButton = EventSystem.current.currentSelectedGameObject.name;
        if (nowButton == "Login")
        {
            Debug.Log("아바타생성");
            SceneManager.LoadScene("MainScene");
        }
    }

    public void ValueChanged(string text)
	{
        name = text;
		Debug.Log (name);
	}
}
