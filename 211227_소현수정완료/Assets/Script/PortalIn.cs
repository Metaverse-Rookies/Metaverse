// 로비로 나가기
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalIn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(this.gameObject.name == "Portal" && other.gameObject.tag == "Player"){
            // 플레이어가 포탈에 접근하면
            SceneManager.LoadScene("MainScene");
            }
    
        else if(this.gameObject.name == "Portal1" && other.gameObject.tag == "Player"){
            
            DontDestroyOnLoad(GameObject.Find("PlayerArmature"));
            SceneManager.LoadScene("Apartment");
        }
        else if(this.gameObject.name == "Portal2" && other.gameObject.tag == "Player"){
            SceneManager.LoadScene("40Apartment");
        }
    }
}
