using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOnClick : MonoBehaviour
{
    public GameObject popup;
    // Start is called before the first frame update
    void Start()
    {
        popup.SetActive(false);
    }

    void OnMouseDown() {
        popup.SetActive(true);
    }
}
