using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSelect : MonoBehaviour
{
    public GameObject obj;
    public bool isClicked = false;

    // 각 버튼의 그룹
    public string type = "";
    //public static string size = "";
    //public static string quailty = "";
    TvChange tvchange;

    void Start()
    {
        tvchange = GameObject.Find("TVs").GetComponent<TvChange>();
    }

    void Update()
    {
        Cursor.visible = true;

        //Debug.Log(type + ", " + size + ", " + quailty + " 선택 완료");

    }

    public void ButtonClick()
    {
        isClicked = true;
        string name = this.gameObject.name;
        string parent = transform.parent.gameObject.name;

        if (parent.Equals("Type"))
        {
            type = name;
            tvchange.change(type);
        }
            

        //else if (parent.Equals("Size"))
        //size = name;

        //else if (parent.Equals("Quality"))
        //quailty = name;


    }
}