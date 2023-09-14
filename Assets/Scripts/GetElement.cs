using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetElement : MonoBehaviour
{
    public bool Pyro = false;
    public bool Hydro = false;
    public bool Anemo = false;
    public bool Electro = false;
    public bool Dendero = false;
    public bool Cryo = false;
    public bool Geo = false;
    public string SetElement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Pyro)
        {
            SetElement = "Pyro";
        }
        else if (Hydro)
        {
            SetElement = "Hydro";
        }
        else if (Anemo)
        {
            SetElement = "Anemo";
        }
        else if (Electro)
        {
            SetElement = "Electro";
        }
        else if (Dendero)
        {
            SetElement = "Dendero";
        }
        else if (Cryo)
        {
            SetElement = "Cryo";
        }
        else if (Geo)
        {
            SetElement = "Geo";
        }
        else
        {
            SetElement = "NaN";
        }
    }
}
