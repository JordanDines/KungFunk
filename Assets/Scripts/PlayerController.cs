using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Color initialColour;
    public Color selectedColour;
    private Material mat;

    void Start ()
    {
        mat = GetComponent<Renderer>().material;
    }

    void OnTouchDown ()
    {
        mat.color = selectedColour;
    }
    void OnTouchUp()
    {
        mat.color = initialColour;
    }
    void OnTouchStay()
    {
        mat.color = selectedColour;
    }
    void OnTouchExit()
    {
        mat.color = initialColour;
    }
}
