using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualityChange : MonoBehaviour
{
    GameObject fhd;
    GameObject qhd;
    GameObject uhd;


    private Vector3 sizeFourty, sizeFifty;

    void Start()
    {
        fhd = transform.GetChild(0).gameObject;
        qhd = transform.GetChild(1).gameObject;
        uhd = transform.GetChild(2).gameObject;

        sizeFourty = new Vector3(8.0f, 8.0f, 8.0f);
        sizeFifty = new Vector3(10.0f, 10.0f, 10.0f);

        fhd.SetActive(false);
        uhd.SetActive(false);
        
        qhd.transform.localScale = sizeFourty;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeQuality(string name)
    {
        for(int i=0;i<3;i++){
            GameObject temp = transform.GetChild(i).gameObject;
           
            if(name==temp.name){
                Debug.Log(temp.name);
                temp.SetActive(true);
            }else{
                temp.SetActive(false);
            }
        }
    }

    public void resize(string size)
    {
        if (size == "Fourty")
        {
            //blur.transform.localScale=sizeFourty;
        }
        else if(size == "Fifty")
        {
            //blur.transform.localScale=sizeFifty;
        }
    }
}
