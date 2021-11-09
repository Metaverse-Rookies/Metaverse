using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvOnClick : MonoBehaviour
{
    // 클릭 이벤트로 생성될 객체
    public GameObject popup;
    public Camera testCam;

    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        popup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = testCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if(true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))
            {
                //Debug.Log("여기");
                popup.SetActive(true);
            }
        }
    }

}
