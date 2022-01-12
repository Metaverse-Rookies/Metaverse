using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PortalManager : MonoBehaviour
{
    public TMP_Text         notify;
    public GameObject       potal_ui;
    void Start()
    {
        notify.text = "";
    }

    public void MainPortal()
    {
        notify.text = "메인 로비로\n나가시겠습니까?";
        return ;
    }

    public void ApartmentPortal()
    {
        notify.text = "20평형 아파트로\n입장하시겠습니까?";
        return ;
    }

    public void BigApartmentPortal()
    {
        notify.text = "40평형 아파트로\n입장하시겠습니까?";
        return ;
    }

    public void ButtonClick()
    {
        string name = this.gameObject.name;
        // 만약 예스버튼을 누른다면
        // 메인씬으로 이동
        if (name == "Yes" && PortalIn.temp == "Portal2")
        {
            SceneManager.LoadScene("40Apartment");
        }
        else if (name == "Yes" && PortalIn.temp == "Portal1")
        {
            SceneManager.LoadScene("Apartment");
        }
        else if (name == "Yes" && PortalIn.temp == "Portal")
        {
            SceneManager.LoadScene("MainScene");
        }
        // 아니면 UI 창 닫기
        else
        {
            potal_ui.GetComponent<Canvas>().enabled = false;
        }
    }
}
