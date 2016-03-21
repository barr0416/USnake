using UnityEngine;
using System;
using System.Collections;

public class PickupSpawner : MonoBehaviour {

	#region Prefab
	//Pickup Prefab
	[SerializeField]
	private GameObject pickupObject;

	public GameObject m_Pickup {
		get { return pickupObject; }
		set { pickupObject = value; }
	}
	#endregion

	#region Walls
	//Walls
	[SerializeField]
	private GameObject topWall;
	[SerializeField]
	private GameObject bottomWall;
	[SerializeField]
	private GameObject leftWall;
	[SerializeField]
	private GameObject rightWall;

	public GameObject m_TopWall {
		get { return topWall; }
		set { topWall = value; }
	}
	public GameObject m_BottomWall {
		get { return bottomWall; }
		set { bottomWall = value; }
	}
	public GameObject m_LeftWall {
		get { return leftWall; }
		set { leftWall = value; }
	}
	public GameObject m_RightWall {
		get { return rightWall; }
		set { rightWall = value; }
	}
	#endregion
		
	void Start () {
		//Start spawning objects every set seconds
		InvokeRepeating("Spawn", 3, 2);
	}

	void Spawn() {
		//Get a location between borders
		int x = (int)UnityEngine.Random.Range(m_LeftWall.transform.position.x, m_RightWall.transform.position.x);

		//Get a location between borders
		int y = (int)UnityEngine.Random.Range(m_BottomWall.transform.position.y, m_TopWall.transform.position.y);

		//Spawn a new object
		Instantiate(m_Pickup, new Vector2(x, y), Quaternion.identity);
	}
}
