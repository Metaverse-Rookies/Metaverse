using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        // 부모의 자식들을 다 원래색으로 바꿔주고 
        for(int i = 1; i < gameObject.transform.parent.childCount; i++){
            gameObject.transform.parent.GetChild(i).GetComponent<Image>().color = new Color(255/255f, 255/255f, 255/255f);
        }
        // 나만 어두운색으로 바꿈
        gameObject.GetComponent<Image>().color = new Color(103/255f, 154/255f, 195/255f);

        mat = Resources.Load<Material>(this.gameObject.name);
        plane.GetComponent<Renderer>().material = mat;
    }
}
