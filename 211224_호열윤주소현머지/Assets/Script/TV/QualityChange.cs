using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityChange : MonoBehaviour
{
    GameObject fhd;
    GameObject qhd;
    GameObject uhd;

    TvChange tvchange;
    public string nowSize = "";
    public string nowType = "";
    private Vector3 sizeFourty, sizeFifty;

    private Vector3 positionWall, positionStand;

    void Start()
    {
        tvchange = GameObject.Find("TVs").GetComponent<TvChange>();

        fhd = transform.GetChild(0).gameObject;
        qhd = transform.GetChild(1).gameObject;
        uhd = transform.GetChild(2).gameObject;

        sizeFourty = new Vector3(8.6f, 4.8f, 0.01f);
        sizeFifty = new Vector3(10.5f, 5.9f, 0.01f);

        // positionWall = new Vector3(-33.15f, 5.47f, 102f);
        // positionStand = new Vector3(24.27f, 2.87f, 9.6f);
        positionWall = new Vector3(0.54f, 2.2f, 0.94f);
        positionStand = new Vector3(0.54f, -0.16f, 0.94f);

        fhd.SetActive(false);
        uhd.SetActive(false);
        
        qhd.transform.localScale = sizeFourty;

        // qhd.transform.position = positionWall;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeQuality(string name)
    {
        nowType = tvchange.nowType;
        nowSize = tvchange.nowSize;

        for(int i=0;i<3;i++){
            GameObject temp = transform.GetChild(i).gameObject;
           
            if(name==temp.name){
                //Debug.Log(temp.name);
                temp.SetActive(true);
            }else{
                temp.SetActive(false);
            }


            //사이즈조절
            if (nowSize == "40")
            {
                temp.transform.localScale = sizeFourty;

            }else if (nowSize == "50")
            {
                temp.transform.localScale = sizeFifty;
            }

            //위치조절
            if (nowType == "Stand")
            {
                temp.transform.localPosition = positionStand;
            }
            else
            {
                temp.transform.localPosition = positionWall;
            }
        }
    }

    public void resize(string size)
    {
        if (size == "40")
        {
            //blur.transform.localScale=sizeFourty;
        }
        else if(size == "50")
        {
            //blur.transform.localScale=sizeFifty;
        }
    }
}
