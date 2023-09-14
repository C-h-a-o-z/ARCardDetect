using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplyColor : MonoBehaviour
{
    GameObject UIControler;
    // Start is called before the first frame update
    void Start()
    {
        UIControler = GameObject.FindGameObjectWithTag("UIController");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Image>().color = UIControler.GetComponent<UITheme>().GetThemeColor();
    }
}
