using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{

    GameObject player;
    Animator anim;
    public GameObject chair;
    public string stance1;

    // Start is called before the first frame update
    void Start()
    {
        string avatarPrefabName = ChangeScene.playerType;
        anim = GameObject.Find(avatarPrefabName).GetComponent<Animator>();
        // Debug.Log("anim"+anim.name);
        player = GameObject.FindGameObjectWithTag("Player");
        stance1 = CharacterMainController.stance;
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject.Find("Player").GetComponent<CharacterMainController>().;
    }
   
    
    public void OnMouseDown()
    {
        // C �Է� and ���� stand => �ɱ�
        if (stance1 == "stand")
        {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;

        //if (Physics.Raycast(ray, out hit))
        //{
        chair.GetComponent<BoxCollider>().enabled = false;
        anim.SetTrigger("Sit");
        player.transform.position = Vector3.Lerp(player.transform.position, chair.transform.position, 1f);
        GameObject.Find("FP Root").transform.eulerAngles = new Vector3(0, 90, 0);
        Debug.Log(stance1);

        CharacterMainController.stance = "sit";
        }
    }
}
/*
void Update()
    {
        // 사용자의 입력에따라 물체를 회전하고 싶다. 
        // 1. 사용자의 입력에따라
        float h = Input.GetAxis("Mouse X");
        float v = Input.GetAxis("Mouse Y");
        // P = P0 + vt
        mx += h * rotSpeed * Time.deltaTime;
        my += v * rotSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, -90, 90);
        // 2. 방향이 필요
        Vector3 dir = new Vector3(-my, mx, 0);
        // 3. 물체를 회전하고 싶다.
        transform.eulerAngles = dir;

    }
    */
