using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvChange : MonoBehaviour
{
    OptionSelect standSelect;
    OptionSelect hangingSelect;
    // GameObject stand;
    GameObject tv;
    GameObject stand;

    public GameObject ui;
    public string nowType = "Hanging";
    public string nowSize = "40";
    bool flag = false;

    //크기조절
    private Vector3 sizeFourty, sizeFifty;

    private Vector3 positionWall, positionStand;

    void Start()
    {
        standSelect = GameObject.Find("Stand").GetComponent<OptionSelect>();
        hangingSelect = GameObject.Find("Hanging").GetComponent<OptionSelect>();
        tv = transform.GetChild(0).gameObject;
        stand = transform.GetChild(1).gameObject;
        // hanging = transform.GetChild(1).gameObject;
        

        //스탠드 안보이게
        stand.SetActive(false);

        //인치별 크기조절
        sizeFourty = new Vector3(5.9f, 5.5f, 2.0f);
        sizeFifty = new Vector3(7.3f, 6.7f, 2.0f);

        positionWall = new Vector3(22.0f, -3.0f, 14.0f);
        positionStand = new Vector3(22.0f, -5.0f, 13.0f);

        //기본 크기
        tv.transform.localScale = sizeFourty;

        //기본 위치
        tv.transform.localPosition = positionWall;
        
    }

    void Update()
    {

    }

    public void changeTV(string name)
    {
        if (name=="Stand")
        {
            // Debug.Log("stand 활성화");
            stand.SetActive(true);
            tv.transform.localPosition = positionStand;
            if (nowSize == "40")
            {
                tv.transform.localScale = sizeFourty;
            }else if (nowSize == "50")
            {
                tv.transform.localScale = sizeFifty;
            }
            nowType = "Stand";

        }
        else if (name == "Hanging")
        {
            // Debug.Log("stand 비활성화");
            stand.SetActive(false);
            tv.transform.localPosition = positionWall;
            if (nowSize == "40")
            {
                tv.transform.localScale = sizeFourty;
            }
            else if (nowSize == "50")
            {
                tv.transform.localScale = sizeFifty;
            }
            nowType = "Hanging";
        }
        flag = true;
    }

    public void resize(string size)
    {
        if (size == "40")
        {
            tv.transform.localScale = sizeFourty;
            if (nowType == "Stand")
            {
                //스탠드 40인치로 조절
                tv.transform.localPosition = positionStand;
            }
            else
            {
                //벽걸이 40인치로 조절
                tv.transform.localPosition = positionWall;
            }
            nowSize = "40";
        }
        else if(size == "50")
        {
            tv.transform.localScale = sizeFifty;
            if (nowType == "Stand")
            {
                //스탠드 50인치로 조절
                tv.transform.localPosition = positionStand;
            }
            else
            {
                //벽걸이 50인치로 조절
                tv.transform.localPosition = positionWall;
            }
            nowSize = "50";
        }
    }

    

}
