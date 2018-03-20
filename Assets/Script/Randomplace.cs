using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomplace : MonoBehaviour {

    public GameObject prefab;
    public int NumberOfObstacles;    
    private float obheighttoggle;
    private float obstacleheights;
    private float obwidth;
    private float obwidthvar;
    private float obshape;
    private float obcolor;
    private float obpred;
    private float obstyle;
    private float obwave;
    private float obheights;
    private float obwidthposition;


    // Use this for initialization
    void Start () {
        //ObArray = new ArrayList();

        NumberOfObstacles = PlayerPrefs.GetInt("NumbOb");
        obheighttoggle = PlayerPrefs.GetInt("ObHeight");
        obstacleheights = PlayerPrefs.GetFloat("ObHeightnum");
        obwidth = PlayerPrefs.GetInt("ObWidth");
        obwidthvar = PlayerPrefs.GetFloat("ObWidthVar");
        obshape = PlayerPrefs.GetInt("ObShape");
        obcolor = PlayerPrefs.GetInt("ObColor");
        obpred = PlayerPrefs.GetInt("ObPred");
        obstyle = PlayerPrefs.GetInt("ObStyle");
        obwave = PlayerPrefs.GetInt("ObWave");

        //for (int i = 1; i < NumberOfObstacles+1; i++)
        //{
        //    float position = (Random.Range(-10.0f, -5.1f));
        //    ObArray.Add(position);

        //Vector3 Obposition = new Vector3(position, 0.01f, 1.37f);
        //GameObject go = Instantiate(prefab, Obposition, Quaternion.identity) as GameObject;
        //go.transform.parent = GameObject.Find("Objects").transform;

        //}

        // get obstacle height
        if (obheighttoggle == 1)
        {
            obheights = obstacleheights;
        }
        else if (obheighttoggle == 2)
        {
            obheights = (Random.Range(obstacleheights - 0.03f, obstacleheights + 0.03f));
        }
        else if (obheighttoggle == 3)
        {
            obheights = (Random.Range(obstacleheights - 0.05f, obstacleheights + 0.05f));
        }

        // get obstacle width
        if (obwidth == 1)
        {   
            obwidthposition = (Random.Range(0.64f, 2.14f));
        }
        else if (obwidth == 2)
        {
            obwidthposition = (Random.Range(0.94f, 1.94f));
        }
        else if (obwidth == 3)
        {
            obwidthposition = 1.37f;
        }
                
        //float position = (float)ObArray[i] + i*10;
        float position = (Random.Range(-10.0f, -5.1f)) - 10;
        Vector3 Obposition = new Vector3(position, obheights / 2f, obwidthposition);
        GameObject go = Instantiate(prefab, Obposition, Quaternion.identity) as GameObject;
        Vector3 scale = go.transform.localScale;
        scale.Set(0.1f, obheights, obwidthvar);
        go.transform.localScale = scale;
        go.transform.parent = GameObject.Find("Objects").transform;

    }
	
	// Update is called once per frame
	void Update()
    {
        
    }

    //public ArrayList get()
    //{
    //    return ObArray;
    //}
        
}
