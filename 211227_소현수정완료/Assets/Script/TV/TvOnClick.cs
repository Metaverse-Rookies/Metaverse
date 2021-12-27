using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvOnClick : MonoBehaviour
{
    // Ŭ�� �̺�Ʈ�� ������ ��ü
    public GameObject popup;
    // public Camera testCam;
    Camera testCam;

    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        popup.SetActive(false);
        testCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        testCam = Camera.main;
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log(testCam.name);
            Ray ray = testCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if(true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))
            {
                //Debug.Log("����");
                popup.SetActive(true);
            }
        }
    }

}
