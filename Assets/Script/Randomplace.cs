using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomplace : MonoBehaviour {

    public GameObject prefab;
    public int NumberOfObstacles;
    public ArrayList ObArray = new ArrayList();
    private float obstacleheights;

    // Use this for initialization
    void Start () {
        //ObArray = new ArrayList();
        NumberOfObstacles = PlayerPrefs.GetInt("NumbOb");
        obstacleheights = PlayerPrefs.GetFloat("ObHeight");

        for (int i = 1; i < NumberOfObstacles+1; i++)
        {
            float position = (Random.Range(-10.0f, -5.1f));
            ObArray.Add(position);

            //Vector3 Obposition = new Vector3(position, 0.01f, 1.37f);
            //GameObject go = Instantiate(prefab, Obposition, Quaternion.identity) as GameObject;
            //go.transform.parent = GameObject.Find("Objects").transform;

        }

        for (int i = 0; i < 2; i++)
        {
            float position = (float)ObArray[i] + i*10;
            Vector3 Obposition = new Vector3(position, obstacleheights/2f, 1.37f);
            GameObject go = Instantiate(prefab, Obposition, Quaternion.identity) as GameObject;
            go.transform.parent = GameObject.Find("Objects").transform;
        }


    }
	
	// Update is called once per frame
	void Update()
    {
        
    }

    public ArrayList get()
    {
        return ObArray;
    }
        
}
