using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Color initialColour;
    public Color selectedColour;
    public float speed;
    private Material material;

    public GameObject player;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        material.color = initialColour;

    }

    void OnTouchDown()
    {
        material.color = selectedColour;
        
    }
    void OnTouchUp()
    {
        material.color = initialColour;
    }
    void OnTouchStay()
    {
        material.color = selectedColour;
        player.transform.position = Vector3.Lerp(player.transform.position, transform.position, speed);
    }
    void OnTouchExit()
    {
        material.color = initialColour;
    }
}
