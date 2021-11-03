using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewDoor : MonoBehaviour
{
    private Animator animator; // 애니메이터를 호출할 변수

    // 1. 거리를 구할 두 오브젝트 얻기
    public GameObject door1;
    public GameObject avatar1;
    float objectDistance;

    private bool doorOpen;

    void Start() // 시작
    {
        doorOpen = false; // 문 열리지 않은 상태로 초기화

        // 애니메이터 변수에 애니메이터 컴포넌트를 할당한다.
        animator = GetComponent<Animator>();
        Debug.Log("start");
    }

    void Update()
    {
        // 2. 각 오브젝트의 좌표 구하기
        Vector3 doorPos = door1.transform.position;
        Vector3 avatPos = avatar1.transform.position;

        // 3. 거리 계산
        float width = doorPos.x - avatPos.x;
        float height = doorPos.z - avatPos.z;

        float distance = width * width + height * height;
        distance = Mathf.Sqrt(distance);
        // Debug.Log("거리: " + distance);

        if (distance <= 9 && !doorOpen)
        {
            Debug.Log("open");
            doorOpen = true;
            Doors("Open");
        }
        else if (distance > 9 && doorOpen)
        {
            Debug.Log("close");
            doorOpen = false;
            Doors("Close"); // Close 파라미터로 Trigger를 실행
        }
    }

    void Doors(string direction)
    {
        animator.SetTrigger(direction);
    }
}