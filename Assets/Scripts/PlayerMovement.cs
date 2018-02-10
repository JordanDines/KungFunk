using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed = 10f;

    public Vector3 startPosition;
    public Vector3 letGoPosition;
	public GameObject endPosition;
	public Vector3 draggingPosition;

	public GameObject enemyToMoveTo;
	public bool isMoving = false;
	public float minDistance = 1;

    public Camera cam;
	public GameObject[] enemies;


	public GameObject[] triggerList;
	// Use this for initialization
	void Start () {
		
        cam = FindObjectOfType<Camera>();
		GetComponent<CapsuleCollider> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(0))
        {
			GetComponent<CapsuleCollider> ().enabled = true;
			startPosition = cam.ScreenToWorldPoint (Input.mousePosition);
			Debug.DrawLine (startPosition, draggingPosition);
        }

		if (Input.GetMouseButton (0)) {
			draggingPosition = cam.ScreenToWorldPoint (Input.mousePosition);
			Debug.DrawLine (startPosition, draggingPosition, Color.blue);
		}

		if (Input.GetMouseButtonUp (0)) {
			draggingPosition = cam.ScreenToWorldPoint (Input.mousePosition);

			//Get the angle between the points
			float angle = AngleBetweenTwoPoints(startPosition, draggingPosition);

			transform.rotation =  Quaternion.Euler (new Vector3(0f,0f,(angle + 90f)));
			Invoke ("TurnOffMovingTrigger", .2f);
		}
		if (isMoving) {
			MoveToEnemy();
		}

	}
		

	//called when something enters the trigger
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy") {
			enemyToMoveTo = other.gameObject;
			print (other.gameObject.tag);
			isMoving = true;
		}

		//enemies = GameObject.FindGameObjectsWithTag("Enemy");

		//GameObject closestEnemy = null;
		//float distanceToClosestEnemy = Mathf.Infinity;
		//foreach (GameObject enemy in enemies) 
		//{
		//	float distanceToEnemy = Vector3.Distance(endPosition.transform.position, enemy.transform.position);
		//	if (distanceToEnemy < distanceToClosestEnemy) 
		//	{
		//		closestEnemy = enemy;
		//		distanceToClosestEnemy = distanceToEnemy;
		//	}
		//}
		//transform.position = closestEnemy.transform.position;
		//print (closestEnemy);
	}
		

	void TurnOffMovingTrigger(){
		GetComponent<CapsuleCollider> ().enabled = false;
	}

	void MoveToEnemy (){
		transform.position = Vector3.Lerp (transform.position, enemyToMoveTo.transform.position, speed);
		if (Vector3.Distance (transform.position, enemyToMoveTo.transform.position) < minDistance) {
			isMoving = false;
		}
	}
		
	float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
	
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}

	//void GetClosestEnemy(){
	//	GameObject closestEnemy = null;
	//	float distanceToClosestEnemy = Mathf.Infinity;
	//	foreach (GameObject enemy in enemies) 
	//	{
	//		float distanceToEnemy = Vector3.Distance(endPosition.transform.position, enemy.transform.position);
	//		if (distanceToEnemy < distanceToClosestEnemy) 
	//		{
	//			closestEnemy = enemy;
	//			distanceToClosestEnemy = distanceToEnemy;
	//		}
	//	}
	//	print (closestEnemy);
	//	transform.position = closestEnemy.transform.position;
	//}
}
