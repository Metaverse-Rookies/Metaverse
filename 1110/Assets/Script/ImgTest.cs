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
        Instantiate(tv);
    }
}
