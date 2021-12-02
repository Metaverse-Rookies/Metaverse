using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImgTest : MonoBehaviour
{
    [SerializeField] public GameObject tv;
    public TextAsset textAsset;
    // Start is called before the first frame update
    void Start()
    {
        CreateImg();
        textAsset = Resources.Load<TextAsset>("text");
    }

    private void CreateImg()
    {
        float tveSize = tv.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        for(int i = 0; i < 5; i++)
            for(int j= 0;j<5;j++)
            {
                //tv = Instantiate(Resources.Load("Img/samsung.jpg",typeof(GameObject))) as GameObject;
                tv = Resources.Load<GameObject>("Img/samsung");Instantiate(tv);
                /*GameObject newTv = Instantiate(tv);
                newTv.transform.position = new Vector3(tveSize * i, tveSize * j, 0);*/
            }
    }
}
