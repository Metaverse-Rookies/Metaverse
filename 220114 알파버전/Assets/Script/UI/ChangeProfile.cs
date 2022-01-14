using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeProfile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (ChangeScene.genderButton == "Male")
            gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Img/male profile");
        else if (ChangeScene.genderButton == "Female")
            gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Img/imageUnityOk02");        
    }
}
