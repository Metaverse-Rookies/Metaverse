using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionSelect : MonoBehaviour
{
    public GameObject obj;
    public bool isClicked = false;

    void Start()
    {

    }
    void Update()
    {
        Cursor.visible = true;

    }

    public void ButtonClick()
    {
        isClicked = true;
        string name = this.gameObject.name;
        Debug.Log(name+"Å¬¸¯");
        

    }

}
