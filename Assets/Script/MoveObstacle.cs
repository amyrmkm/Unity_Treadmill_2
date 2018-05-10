using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObstacle : MonoBehaviour {
	public int obdynamicpred = 1;
	public Vector3 startpos;
	public Vector3 parentpos;
	private Vector3 startpos_continue;
	//private Vector3 endpos;
	private Vector3 endpos_continue;
	private float correctpos;
    private float speed = 0;
    private float treadmillspeed;
    private bool hasStarted = false;

    // Use this for initialization
    void Start () 
	{
		obdynamicpred = PlayerPrefs.GetInt("ObDynamicPred");
        treadmillspeed = PlayerPrefs.GetFloat("TreadmillInput") / 2.23694f;

        if (obdynamicpred == 1) 
		{
            speed = 0;
		}

		else if (obdynamicpred == 2) 
		{
            speed = treadmillspeed * 1.1f;
		}

		else if (obdynamicpred == 3) 
		{
            speed = treadmillspeed * 1.1f;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{		
		//startpos_continue = new Vector3(startpos.x - parentpos.x, startpos.y - parentpos.y, startpos.z - parentpos.z);
		//endpos_continue = new Vector3 (startpos_continue.x + 0.5f, startpos_continue.y, startpos_continue.z);		
        transform.Translate(Vector2.right * Time.deltaTime * speed);
        Debug.Log(Time.deltaTime);
        
    }
}

