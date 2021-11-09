using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnOnClick : MonoBehaviour
{
    // 클릭 이벤트로 생성될 객체
    public GameObject popup;
    public Camera testCam;

<<<<<<< Updated upstream
    private RaycastHit hit;
   
    void ButtonClick()
=======
    // Update is called once per frame
    void Update()
>>>>>>> Stashed changes
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = testCam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if (true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))
            {
                popup.SetActive(true);
            }
        }

    }
}