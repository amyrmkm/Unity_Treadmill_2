using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour {
	public int obdynamicpred = 1;
	float timer = 0;
	public ArrayList movetime = new ArrayList();
	public Vector3 startpos;
	public Vector3 parentpos;
	private Vector3 startpos_continue;
	//private Vector3 endpos;
	private Vector3 endpos_continue;
	private float movetimer;
	private float correctpos;
	// Use this for initialization
	void Start () 
	{
		obdynamicpred = PlayerPrefs.GetInt("ObDynamicPred");

		if (obdynamicpred == 2) 
		{
			for (int i = 1; i < 10; i++) 
			{
				timer = 1f;
				movetime.Add (timer);
			}
		}

		else if (obdynamicpred == 3) 
		{
			for (int i = 1; i < 10; i++) 
			{
				timer = Random.Range (0f, 1f);
				movetime.Add (timer);
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		startpos_continue = new Vector3(startpos.x - parentpos.x, startpos.y, startpos.z);
		endpos_continue = new Vector3 (startpos_continue.x + 0.5f, startpos_continue.y, startpos_continue.z);

		int j = 0;
		movetimer = (float)movetime [j];
		transform.localPosition = Vector3.Lerp (startpos_continue, endpos_continue, Mathf.PingPong (Time.time * movetimer, 1));
	}
}

