using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour {
	public int setting = 1;
	float timer = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		// move the object
		//if setting is 2
		//transform.position = Vector3.Lerp(new Vector3(0.5f,0,0),new Vector3(-0.5f,0,0),Mathf.PingPong(Time.time*movetime, 2.0f));
	 	//else if setting is 3 
		//random movement code
	}
}
