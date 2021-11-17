using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImgTest : MonoBehaviour
{
    [SerializeField] public GameObject tv;
    // Start is called before the first frame update
    void Start()
    {
        CreateImg();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CreateImg()
    {
        float tveSize = tv.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        for(int i = 0; i < 5; i++)
            for(int j= 0;j<5;j++)
            {
                GameObject newTv = Instantiate(tv);
                newTv.transform.position = new Vector3(tveSize * i, tveSize * j, 0);
            }
    }
}
