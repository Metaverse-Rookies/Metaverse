using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ChangeScene : MonoBehaviour
{
    public string nowButton;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    public void SceneChange()
    {
        // 현재 게임오브젝트의 이름을 저장한다
        nowButton = EventSystem.current.currentSelectedGameObject.name;
        /*if (nowButton == "CreateAvatar")
            Debug.Log("같다");
        else
            Debug.Log("다르다");*/
        SceneManager.LoadScene("SampleScene");
    }
}
