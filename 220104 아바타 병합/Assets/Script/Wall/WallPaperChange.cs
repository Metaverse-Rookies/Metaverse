using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPaperChange : MonoBehaviour
{
    private Material mat;
    
    private Transform parentWall;
    void Start()
    {
        parentWall = GameObject.Find("Wall").transform;
    }

    // Update is called once per frame
    public void BtnOnClick()
    {
        mat = Resources.Load<Material>(this.gameObject.name);
        for(int i = 0; i < parentWall.transform.childCount; i++){
            parentWall.GetChild(i).gameObject.GetComponent<Renderer>().material = mat;
        }
    }
}
