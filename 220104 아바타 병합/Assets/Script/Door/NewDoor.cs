using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDoor : MonoBehaviour
{
    private Animator animator; //  ִϸ    ͸  ȣ         

    // 1.  Ÿ                  Ʈ    
    public GameObject door1;
    private GameObject avatar1;
    float objectDistance;

    private bool doorOpen;

    void Start() //     
    {
        doorOpen = false; //                   ·   ʱ ȭ

        //  ִϸ              ִϸ            Ʈ    Ҵ  Ѵ .
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        avatar1 = GameObject.Find(ChangeScene.playerType);
        Debug.Log(avatar1.name+"이다");
        Vector3 doorPos = door1.transform.position;
        Vector3 avatPos = avatar1.transform.position;

        float width = doorPos.x - avatPos.x;
        float height = doorPos.z - avatPos.z;

        float distance = width * width + height * height;
        distance = Mathf.Sqrt(distance);

        if (distance <= 10 && !doorOpen)
        {
            doorOpen = true;
            Doors("Open");
        }
        else if (distance > 10 && doorOpen)
        {
            doorOpen = false;
            Doors("Close"); // Close  Ķ   ͷ  Trigger       
        }
    }

    void Doors(string direction)
    {
        animator.SetTrigger(direction);
        Debug.Log("열려");
    }
}