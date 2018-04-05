﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomplace : MonoBehaviour {

    public GameObject prefab;
    public GameObject target;
    public GameObject pathob;
    public int NumberOfObstacles;    
    private int obheighttoggle;
    private float obstacleheights;
    private int obwidth;
    private float obwidthvar;
    private int obdepth;
    private int obcolor;
    private int obdynamicpred;
    private int obappearancepred;
    private int obstyle;
    private int oblight;
    private int pathwidth;
    private float obheights;
    private float obheights_target;
    private float obwidthposition;
    private float obdepths;
    private float obdepths_target;
    private Color altColor = new Color(1f, 1f, 1f, 1);
    private Color altColor_target = new Color(1f, 1f, 1f, 1);
    private float grayscale;
    private GameObject lightObject;
    private Light myLight;


    // Use this for initialization
    void Start () {
        
        NumberOfObstacles = PlayerPrefs.GetInt("NumbOb");
        obheighttoggle = PlayerPrefs.GetInt("ObHeight");
        obstacleheights = PlayerPrefs.GetInt("ObHeightnum");
        obstacleheights = obstacleheights * 0.01f;
        obwidth = PlayerPrefs.GetInt("ObWidth");
        obwidthvar = PlayerPrefs.GetFloat("ObWidthVar");
        obdepth = PlayerPrefs.GetInt("ObDepth");
        obcolor = PlayerPrefs.GetInt("ObColor");
        obdynamicpred = PlayerPrefs.GetInt("ObDynamicPred");
        obappearancepred = PlayerPrefs.GetInt("ObAppearancePred");
        obstyle = PlayerPrefs.GetInt("ObStyle");
        oblight = PlayerPrefs.GetInt("Lighting");
        lightObject = GameObject.Find("Directional light");
        Debug.Log(lightObject);
        myLight = lightObject.GetComponent<Light>();
        pathwidth = PlayerPrefs.GetInt("Pathwidth");

        // get obstacle negotiation style
        if (obstyle == 1)
        {
            obdepths = 0.1f;

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

            // get obstacle color
            if (obcolor == 1)
            {
                altColor = altColor;

            }
            else if (obcolor == 2)
            {
                grayscale = Random.Range(0f, 1f);
                altColor.r -= grayscale;
                altColor.g -= grayscale;
                altColor.b -= grayscale;
                altColor = new Color(altColor.r, altColor.g, altColor.b, 1);
            }
            else if (obcolor == 3)
            {
                altColor.r -= (Random.Range(0f, 1f));
                altColor.g -= (Random.Range(0f, 1f));
                altColor.b -= (Random.Range(0f, 1f));
                altColor = new Color(altColor.r, altColor.g, altColor.b, 1);
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

            // place path obstacle
            if (pathwidth == 2)
            {
                for (int i = 1; i < 30 + 1; i++)
                {
                    float path_positionx = (Random.Range(-10.0f, -5.1f)) - 10;                    
                    Vector3 pathposition1 = new Vector3(path_positionx, 0.75f, 2.5f);
                    Vector3 pathposition2 = new Vector3(path_positionx, 0.75f, 0.3f);
                    GameObject path1 = Instantiate(pathob, pathposition1, Quaternion.identity) as GameObject;
                    GameObject path2 = Instantiate(pathob, pathposition2, Quaternion.identity) as GameObject;
                }
            }
            else if (pathwidth == 3)
            {
                for (int i = 1; i < 30 + 1; i++)
                {
                    float path_positionx = (Random.Range(-10.0f, -5.1f)) - 10;
                    Vector3 pathposition1 = new Vector3(path_positionx, 0.75f, 2.1f);
                    Vector3 pathposition2 = new Vector3(path_positionx, 0.75f, 0.6f);
                    GameObject path1 = Instantiate(pathob, pathposition1, Quaternion.identity) as GameObject;
                    GameObject path2 = Instantiate(pathob, pathposition2, Quaternion.identity) as GameObject;
                }
            }

            // set position
            float position = (Random.Range(-10.0f, -5.1f)) - 10;
            Vector3 Obposition = new Vector3(position, obheights / 2f, obwidthposition);

            // instantiate obstacles
            GameObject go = Instantiate(prefab, Obposition, Quaternion.identity) as GameObject;

            // change color
            MeshRenderer gameObjectRenderer = go.GetComponent<MeshRenderer>();
            Material newMaterial = new Material(Shader.Find("Legacy Shaders/Diffuse"));
            newMaterial.color = altColor;
            gameObjectRenderer.material = newMaterial;

            // change scale
            Vector3 scale = go.transform.localScale;
            scale.Set(obdepths, obheights, obwidthvar);
            go.transform.localScale = scale;

            // put it under the parent object
            go.transform.parent = GameObject.Find("Objects").transform;

        }

        else if (obstyle == 2)
        {
            obheights = 0.01f;
            altColor_target = altColor_target;

            // get obstacle depth
            if (obdepth == 1)
            {
                obdepths_target = 0.5f;
            }
            else if (obdepth == 2)
            {
                obdepths_target = 0.3f;
            }
            else if (obdepth == 3)
            {
                obdepths_target = 0.1f;
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

            // get lighting position
            if (oblight == 1)
            {
                myLight.enabled = true;
            }
            else if (oblight == 2)
            {
                myLight.enabled = false;
            }
            else if (oblight == 3)
            {
                myLight.enabled = false;
            }

            if (oblight == 1)
            {
                myLight.enabled = true;
            }
            else if (oblight == 2)
            {
                myLight.enabled = false;
            }
            else if (oblight == 3)
            {
                myLight.enabled = false;
            }

            // place path obstacle
            if (pathwidth == 2)
            {
                for (int i = 1; i < 30 + 1; i++)
                {
                    float path_positionx = (Random.Range(-10.0f, -5.1f)) - 10;
                    Vector3 pathposition1 = new Vector3(path_positionx, 0.75f, 2.5f);
                    Vector3 pathposition2 = new Vector3(path_positionx, 0.75f, 0.3f);
                    GameObject path1 = Instantiate(pathob, pathposition1, Quaternion.identity) as GameObject;
                    GameObject path2 = Instantiate(pathob, pathposition2, Quaternion.identity) as GameObject;
                }
            }
            else if (pathwidth == 3)
            {
                for (int i = 1; i < 30 + 1; i++)
                {
                    float path_positionx = (Random.Range(-10.0f, -5.1f)) - 10;
                    Vector3 pathposition1 = new Vector3(path_positionx, 0.75f, 2.1f);
                    Vector3 pathposition2 = new Vector3(path_positionx, 0.75f, 0.6f);
                    GameObject path1 = Instantiate(pathob, pathposition1, Quaternion.identity) as GameObject;
                    GameObject path2 = Instantiate(pathob, pathposition2, Quaternion.identity) as GameObject;
                }
            }

            // set position
            float position = (Random.Range(-10.0f, -5.1f)) - 10;
            Vector3 Obposition = new Vector3(position, 0.02f/2, obwidthposition);

            // instantiate obstacles
            GameObject go = Instantiate(target, Obposition, Quaternion.identity) as GameObject;

            // change color
            MeshRenderer gameObjectRenderer = go.GetComponent<MeshRenderer>();
            Material newMaterial = new Material(Shader.Find("Legacy Shaders/Diffuse"));
            newMaterial.color = altColor;
            gameObjectRenderer.material = newMaterial;

            // change scale
            Vector3 scale = go.transform.localScale;
            scale.Set(obdepths_target, 0.02f, obwidthvar);
            go.transform.localScale = scale;

            // put it under the parent object
            go.transform.parent = GameObject.Find("Objects").transform;
        }

        else if (obstyle == 3)
        {
            obheights_target = 0.01f;
            obdepths = 0.1f;
            altColor = new Color(1, 0, 0, 1);
            altColor_target = altColor_target;

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

            // get obstacle depth
            if (obdepth == 1)
            {
                obdepths_target = 0.5f;
            }
            else if (obdepth == 2)
            {
                obdepths_target = 0.3f;
            }
            else if (obdepth == 3)
            {
                obdepths_target = 0.1f;
            }

            // place path obstacle
            if (pathwidth == 2)
            {
                for (int i = 1; i < 30 + 1; i++)
                {
                    float path_positionx = (Random.Range(-10.0f, -5.1f)) - 10;
                    Vector3 pathposition1 = new Vector3(path_positionx, 0.75f, 2.5f);
                    Vector3 pathposition2 = new Vector3(path_positionx, 0.75f, 0.3f);
                    GameObject path1 = Instantiate(pathob, pathposition1, Quaternion.identity) as GameObject;
                    GameObject path2 = Instantiate(pathob, pathposition2, Quaternion.identity) as GameObject;
                }
            }
            else if (pathwidth == 3)
            {
                for (int i = 1; i < 30 + 1; i++)
                {
                    float path_positionx = (Random.Range(-10.0f, -5.1f)) - 10;
                    Vector3 pathposition1 = new Vector3(path_positionx, 0.75f, 2.1f);
                    Vector3 pathposition2 = new Vector3(path_positionx, 0.75f, 0.6f);
                    GameObject path1 = Instantiate(pathob, pathposition1, Quaternion.identity) as GameObject;
                    GameObject path2 = Instantiate(pathob, pathposition2, Quaternion.identity) as GameObject;
                }
            }
        }        
    }
	
	// Update is called once per frame
	void Update()
    {

    }
            
}
