using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABC : MonoBehaviour
{
    private Animator anim;
    private Rigidbody rBody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SitandStand();
    }


    public GameObject Chair;
    private string stance = "stand";
    public void SitandStand()
    {
        
        // C 입력 and 상태 stand => 앉기
        if (Input.GetMouseButtonDown(0) && stance == "stand")
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                anim.SetTrigger("Sit");
                //transform.position = Vector3.Lerp(transform.position, Chair.transform.position, 1f);
                //Chair.GetComponent<BoxCollider>().enabled = false;
                Debug.Log(stance);
                stance = "sit";
                print(stance);
           }
        }
        // 
        // C 입력 and 상태 sit => 일어서기
        else if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.S) | Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.W) && stance == "sit") 
        {
            anim.SetTrigger("Stand");
            //Chair.GetComponent<BoxCollider>().enabled = true;

            transform.position = rBody.position;
            
            Debug.Log(stance);
            stance = "stand";
            print(stance);
        }

    }

}
