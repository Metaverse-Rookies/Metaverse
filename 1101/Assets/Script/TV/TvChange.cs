using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvChange : MonoBehaviour
{
    OptionSelect standSelect;
    OptionSelect hangingSelect;
    GameObject stand;
    GameObject hanging;
    public GameObject ui;
    string nowType = "Hanging";
    string nowSize = "Fourty";
    bool flag = false;

    //크기조절
    private Vector3 sizeFourty, sizeFifty;

    void Start()
    {
        standSelect = GameObject.Find("Stand").GetComponent<OptionSelect>();
        hangingSelect = GameObject.Find("Hanging").GetComponent<OptionSelect>();
        stand = transform.GetChild(0).gameObject;
        hanging = transform.GetChild(1).gameObject;

        //스탠드 안보이게
        stand.SetActive(false);

        //인치별 크기조절
        sizeFourty = new Vector3(4.0f, 4.0f, 4.0f);
        sizeFifty = new Vector3(5.0f, 5.0f, 5.0f);

        //기본 크기
        hanging.transform.localScale = sizeFourty;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag)
        {
            ui.SetActive(true);
        }
    }

    public void change(string name)
    {

        if (name=="Stand")
        {
            stand.SetActive(true);
            hanging.SetActive(false);
            nowType = "Stand";
            if (nowSize == "Fourty")
            {
                stand.transform.localScale = sizeFourty;
            }else if (nowSize == "Fifty")
            {
                stand.transform.localScale = sizeFifty;
            }
        }
        else if (name == "Hanging")
        {
            hanging.SetActive(true);
            stand.SetActive(false);
            //ui.SetActive(true);
            nowType = "Hanging";
            if (nowSize == "Fourty")
            {
                hanging.transform.localScale = sizeFourty;
            }
            else if (nowSize == "Fifty")
            {
                hanging.transform.localScale = sizeFifty;
            }
        }
        flag = true;
    }

    public void resize(string size)
    {
        if (size == "Fourty")
        {
            if (nowType == "Stand")
            {
                //스탠드 40인치로 조절
                stand.transform.localScale = sizeFourty;
            }
            else
            {
                //벽걸이 40인치로 조절
                hanging.transform.localScale = sizeFourty;
            }
            nowSize = "Fourty";
        }
        else if(size == "Fifty")
        {
            if (nowType == "Stand")
            {
                //스탠드 50인치로 조절
                stand.transform.localScale = sizeFifty;
            }
            else
            {
                //벽걸이 50인치로 조절
                hanging.transform.localScale = sizeFifty;
            }
            nowSize = "Fifty";
        }
    }
}
