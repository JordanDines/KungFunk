using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Vector2 oldPosition;
    public Vector2 movingPosition;
    public Vector2 newPosition;
    public float angle;


    private Camera cam;

    void Start ()
    {
        cam = FindObjectOfType<Camera>();
        angle = 0;
    }

    void Update()
    {
        GetSwipeDirection();
    }
    void OnTouchDown ()
    {
       
    }
    void OnTouchUp()
    {
       
    }
    void OnTouchStay()
    {
       
    }
    void OnTouchExit()
    {
        
    }


    void GetSwipeDirection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            oldPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        //When pressing down, get the first position
        if (Input.GetMouseButton(0))
        {
            movingPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        //When letting go, get the final position
        if (Input.GetMouseButtonUp(0))
        {
            newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            
            
        }
        //Get the angle between the two position
        angle = Vector2.Angle(oldPosition, newPosition);

        //Loop through each enemy, check the angle between their position and your position
        //against swipe angle. return the ones that that are within a threshold using MathfDeltaAngle(eulerAngle1, eulerAngle2)

        //if two are on the same angle, get the closest one using vector3.distance

        //If the angle goes beyond 180, make the angle minus from 360
        Vector3 cross = Vector3.Cross(newPosition, oldPosition);
        if (cross.z < 0)
        {
            angle = 360 - angle;
        }


        Debug.DrawLine(oldPosition, movingPosition);


    }
}
