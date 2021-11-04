using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnOnClick : MonoBehaviour
{
    // Å¬¸¯ ÀÌº¥Æ®·Î »ý¼ºµÉ °´Ã¼
    public GameObject popup;
    public Button btn;

    /*
    void Start()
    {
        btn = this.transform.GetComponent<Button>();
        btn.onClick.AddListener(fClick);
    }

    public void fClick()
    {
        popup.SetActive(false);
        Debug.Log("´ÝÈû");
    }
    */

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            popup.SetActive(false);
        }
    }

}
