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
        anim = GameObject.Find("PlayerArmature").GetComponent<Animator>();
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
        // C 입력 and 상태 stand => 앉기
        if (stance1 == "stand")
        {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;

        //if (Physics.Raycast(ray, out hit))
        //{
        chair.GetComponent<BoxCollider>().enabled = false;
        anim.SetTrigger("Sit");
        player.transform.position = Vector3.Lerp(player.transform.position, chair.transform.position, 1f);
        Debug.Log(stance1);

        CharacterMainController.stance = "sit";
        }
    }
}
