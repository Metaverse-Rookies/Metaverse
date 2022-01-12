// 로비로 나가기
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PortalIn : MonoBehaviour
{
    public static string temp;
    public GameObject script;
    public GameObject potal_ui;
    public string currentButton;

    private void OnTriggerEnter(Collider other) {
        temp = gameObject.name;
        script = GameObject.Find("Yes");
        potal_ui = GameObject.Find("PotalUI");
        // currentButton = EventSystem.current.currentSelectedGameObject.name;

        // 플레이어가 포탈에 접근하면
        if(temp == "Portal" && other.gameObject.tag == "Player"){
            script.GetComponent<PortalManager>().MainPortal();      
            potal_ui.GetComponent<Canvas>().enabled = true;
        }
    
        else if(temp == "Portal1" && other.gameObject.tag == "Player"){
            
            script.GetComponent<PortalManager>().ApartmentPortal();
            potal_ui.GetComponent<Canvas>().enabled = true;
        }
        else if(temp == "Portal2" && other.gameObject.tag == "Player"){
            script.GetComponent<PortalManager>().BigApartmentPortal();
            potal_ui.GetComponent<Canvas>().enabled = true;
        }
        else
            potal_ui.GetComponent<Canvas>().enabled = false;
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player"){
            if(GameObject.Find("PotalUI")){
                GameObject.Find("PotalUI").GetComponent<Canvas>().enabled = false;
            }
        }
    }
}
