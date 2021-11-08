using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvChange : MonoBehaviour
{
    //OptionSelect optionSelect;
    OptionSelect standSelect;
    OptionSelect hangingSelect;
    GameObject stand;
    GameObject hanging;
    public GameObject ui;
    bool showStand = true;
    bool flag = false;
    void Start()
    {
        
        //TestScript tests = GameObject.Find("Canvas").GetComponent<TestScript>();
        standSelect = GameObject.Find("Stand").GetComponent<OptionSelect>();
        hangingSelect = GameObject.Find("Hanging").GetComponent<OptionSelect>();
        //test = GameObject.Find("Canvas").GetComponent<TestScript>();
        //optionSelect = GameObject.Find("Stand").GetComponent<OptionSelect>();
        stand = transform.GetChild(0).gameObject;
        hanging = transform.GetChild(1).gameObject;

        //스탠드 안보이게
        //Color currentColor = hanging.GetComponent<MeshRenderer>().material.color;
        //currentColor.a = 0;
        stand.SetActive(false);

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

        }
        else if (name == "Hanging")
        {
            hanging.SetActive(true);
            stand.SetActive(false);
            ui.SetActive(true);
        }
        flag = true;
    }
}
