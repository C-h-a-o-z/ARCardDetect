using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UITheme : MonoBehaviour
{
    string CurrElement;
    [SerializeField] Sprite[] elements;
    [SerializeField] GameObject imgHost;

    Color32[] ThemeColors = new Color32[]
    {
        new Color32(254, 146, 94, 255),
        new Color32(33, 225, 235, 255),
        new Color32(114, 225, 195, 255),
        new Color32(168, 88, 201, 255),
        new Color32(35, 191, 137, 255),
        new Color32(160, 232, 229, 255),
        new Color32(225, 179, 64, 255)
    };

    Color32 SetColor;
    //Color a = Color.black;
    int selectedElement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Element");
        foreach (GameObject go in gos)
        {
            CurrElement = go.GetComponent<GetElement>().SetElement;
        }

        if (CurrElement == "Pyro")
        {
            selectedElement = 0;
        }
        else if (CurrElement == "Hydro")
        {
            selectedElement = 1;
        }
        else if (CurrElement == "Anemo")
        {
            selectedElement = 2;
        }
        else if (CurrElement == "Electro")
        {
            selectedElement = 3;
        }
        else if (CurrElement == "Dendero")
        {
            selectedElement = 4;
        }
        else if (CurrElement == "Cryo")
        {
            selectedElement = 5;
        }
        else if (CurrElement == "Geo")
        {
            selectedElement = 6;
        }
        else
        {
            CurrElement = "NaN";
        }
        
        if (CurrElement == "NaN")
        {
            imgHost.SetActive(false);
            SetColor = new Color32(0, 0, 0, 255);
        }
        else
        {
            imgHost.SetActive(true);
            imgHost.GetComponent<Image>().sprite = elements[selectedElement];
            SetColor = ThemeColors[selectedElement];
        }

    }
    public Color32 GetThemeColor()
    {
        return SetColor;
    }
}
