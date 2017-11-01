using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Color initialColour;
    public Color selectedColour;
    public float speed;
    private Material mat;

    public GameObject player;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    void OnTouchDown()
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
        player.transform.position = Vector3.Lerp(player.transform.position, transform.position, speed);
    }
    void OnTouchExit()
    {
        mat.color = initialColour;
    }
}
