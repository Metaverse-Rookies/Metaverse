using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityChange : MonoBehaviour
{
    GameObject fhd;
    GameObject qhd;
    GameObject uhd;
    GameObject qled;
    GameObject oled;

    TvChange tvchange;
    public string nowSize = "";
    public string nowType = "";
    public string nowQuality = "FHD";

    private Vector3 sizeFourty, sizeFifty, sizeSeventy, sizeEighty;

    private Vector3 positionWall, positionStand;

    void Start()
    {
        tvchange = GameObject.Find("TVs").GetComponent<TvChange>();

        fhd = transform.GetChild(0).gameObject;
        qhd = transform.GetChild(1).gameObject;
        uhd = transform.GetChild(2).gameObject;
        qled = transform.GetChild(3).gameObject;
        oled = transform.GetChild(4).gameObject;

        sizeFourty = new Vector3(10.08844f, 5.664787f, 0.01f);
        sizeFifty = new Vector3(12.6147f, 7.0033f, 0.01f);
        sizeSeventy = new Vector3(16.76295f, 9.865793f, 0.01f);
        sizeEighty = new Vector3(21.76495f, 12.50177f, 0.01f);
        
        positionWall = new Vector3(0.41f, 2.26f, 1.0f);
        positionStand = new Vector3(0.54f, -0.16f, 0.0f);

        fhd.SetActive(true);
        qhd.SetActive(false);
        uhd.SetActive(false);
        qled.SetActive(false);
        oled.SetActive(false);

        fhd.transform.localScale = sizeFourty;
        fhd.transform.localPosition = positionWall;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeQuality(string name)
    {
        nowType = tvchange.nowType;
        nowSize = tvchange.nowSize;

        for(int i=0;i<5;i++){
            GameObject temp = transform.GetChild(i).gameObject;
           
            if(name==temp.name){
                Debug.Log(temp.name+"으로");
                temp.SetActive(true);
                nowQuality = name;
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
            }else if (nowSize == "70")
            {
                temp.transform.localScale = sizeSeventy;
            }else if (nowSize == "80")
            {
                temp.transform.localScale = sizeEighty;
            }

            //위치조절
            if (nowType == "Stand")
            {
                temp.transform.localPosition = positionStand;
                if(nowSize=="70"){
                    temp.transform.localPosition += new Vector3(0.0f, 1.0f, 0.0f);
                }else if(nowSize=="80"){
                    temp.transform.localPosition += new Vector3(0.0f, 2.0f, 0.0f);
                }
            }
            else
            {
                temp.transform.localPosition = positionWall;
            }
        }
    }

    public void resize(string size)
    {
        for(int i=0;i<5;i++){
            GameObject blur = transform.GetChild(i).gameObject;
            if(nowQuality==blur.name){
                if (size == "40")
                {
                    blur.transform.localScale=sizeFourty;
                }
                else if(size == "50")
                {
                    blur.transform.localScale=sizeFifty;
                }
                else if(size == "70")
                {
                    blur.transform.localScale=sizeSeventy;
                }
                else if(size == "80")
                {
                    blur.transform.localScale=sizeEighty;
                }
                nowSize = size;
            }
        }


    }
}
