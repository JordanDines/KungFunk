using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int speed = 1;

	
	void Start () {
		
	}


    void Update()
    { 
        for(int i = 0; 0 < Input.touchCount; ++i)

            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Debug.Log("Yay");
                // Construct a ray from the current touch coordinates
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                Debug.Log(ray + "help");
                    // Create a particle if hit
                    if (Physics.Raycast(ray, out hit))
                    {
                    transform.position = Vector2.Lerp(transform.position, ray.direction, speed);
                    }
            }
        
    }
}
