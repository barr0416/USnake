﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class PlayerController : MonoBehaviour {

	private Vector2 directionToMove = Vector2.right;

	private List<Transform> trail = new List<Transform>();

	private enum MoveDirection {
		up,
		down,
		left,
		right
	}

	private MoveDirection moveDir;

	private bool collectedPickup = false;

	[SerializeField]
	private GameObject trailObject;
	public GameObject m_TrailObject {
		get { return trailObject; }
		set { trailObject = value; }
	}

	// Use this for initialization
	void Start () {
		InvokeRepeating("Move", 0.1f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.UpArrow)) {
			directionToMove = Vector2.up;
		}
		else if(Input.GetKey(KeyCode.DownArrow)) {
			directionToMove = Vector2.down;
		}
		else if(Input.GetKey(KeyCode.LeftArrow)) {
			directionToMove = Vector2.left;
		}
		else if(Input.GetKey(KeyCode.RightArrow)) {
			directionToMove = Vector2.right;
		}
		else {
			//No direction chosen, remain the same
		}

		//this.Move();
	}

	private void Move() {

		//Save the current position
		Vector2 currentPos = transform.position;

		//Move in the direction chosen
		transform.Translate(directionToMove);

		if(collectedPickup) {
			//Create a new trail object
			GameObject newTrail = (GameObject)Instantiate(m_TrailObject, currentPos, Quaternion.identity);

			//Add to the list
			trail.Insert(0, newTrail.transform);

			//Reset pickup
			collectedPickup = false;
		}
		//Check for trailing objects
		else if(trail.Count > 0) {
			//Move the trail
			trail.Last().position = currentPos;

			//Add to the front, moving the list back, FIFO
			trail.Insert(0, trail.Last());
			trail.RemoveAt(trail.Count-1);
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.tag == "Pickup") {
			collectedPickup = true;

			Destroy(collider.gameObject);
		}
		else {
			//Hit a wall
		}
	}

} 
