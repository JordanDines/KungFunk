using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int speed = 1;

    private Camera cam;

    // Use this for initialization
    void Start () {
        cam = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        //for (var i = 0; i < Input.touchCount; ++i)
        //{
        //    if (Input.GetTouch(i).phase == TouchPhase.Began)
        //    {
        //        RaycastHit hit;
        //        // Construct a ray from the current touch coordinates
        //        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
        //        Debug.Log("yeahhh");
        //        transform.position = ray.origin.
        //        // Create a particle if hit
        //        if (Physics.Raycast(ray, out hit))
        //        { }
        //        //transform.position;
        //    }
        //}
        for (int i = 0; i < Input.touchCount; ++i)
        {

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
               
                // Construct a ray from the current touch coordinates
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                Debug.Log(ray + "help");
                // Works up to here
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    if (hit.collider.tag == "Enemy")
                    {
                        Debug.Log("Yay");
                        Vector2.Lerp(transform.position, hit.transform.position, speed);
                    }
                    
                }
            }
        }

    }
}
