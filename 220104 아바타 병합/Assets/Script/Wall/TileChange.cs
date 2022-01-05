using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChange : MonoBehaviour
{
    private Material mat;
    
    private GameObject plane;
    void Start()
    {
        plane = GameObject.Find("Plane");
    }

    // Update is called once per frame
    public void BtnOnClick()
    {
        mat = Resources.Load<Material>(this.gameObject.name);
        plane.GetComponent<Renderer>().material = mat;
    }
}
