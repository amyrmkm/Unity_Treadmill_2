using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour {

    public int Score = 0;    
    public AudioClip failedClip;
    public AudioClip SuccessClip;
    private AudioSource audioSource;
    public GameObject obmanager;
    private Randomplace randpl;
    //private ArrayList obpos;
    private GameObject obstacles;
    private GameObject targets;
    private int Nums;
    private GameObject go;
    static int touched_child = 0;
    static int touched_child_target = 0;
    static bool played_sound = false;
    private int i;
    private float obstacleheights;
    private float obheighttoggle;
    private float obwidth;
    private float obwidthvar;
    private float obshape;
    private float obcolor;
    private float obdynamicpred;
    private float obappearancepred;
    private float obstyle;
    private float obwave;
    private float obwidthposition;
    private float obheights;
    private Color altColor =  new Color(1f, 1f, 1f, 1);
    public ArrayList Obheight = new ArrayList();
    public ArrayList Obwidth = new ArrayList();
    //public ArrayList Obcolor = new ArrayList();
    public Color[] Obcolor;
    private float grayscale;
    private Color altColor_target = new Color(1f, 1f, 1f, 1);
    private int obdepth;
    private float obdepths;
    private float obdepths_target;
    private float obheights_target;
    private int timer;
    

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        randpl = obmanager.GetComponent<Randomplace>();

        //obpos = randpl.get();
        obstacles = randpl.prefab;
        targets = randpl.target;
        Nums = randpl.NumberOfObstacles;
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
        
        i = 1;

        if (obstyle == 1)
        {
            obdepths = 0.1f;

            // obstacle height manipulation
            if (obheighttoggle == 1)
            {
                for (int i = 1; i < Nums + 1; i++)
                {
                    obheights = PlayerPrefs.GetFloat("ObHeightnum");
                    Obheight.Add(obheights);
                }
            }
            else if (obheighttoggle == 2)
            {
                for (int i = 1; i < Nums + 1; i++)
                {
                    obheights = (Random.Range(obstacleheights - 0.03f, obstacleheights + 0.03f));
                    Obheight.Add(obheights);
                }
            }
            else if (obheighttoggle == 3)
            {
                for (int i = 1; i < Nums + 1; i++)
                {
                    obheights = (Random.Range(obstacleheights - 0.05f, obstacleheights + 0.05f));
                    Obheight.Add(obheights);
                }
            }
            
            // obstacle color manipulation
            Obcolor = new Color[Nums + 1];

            if (obcolor == 1)
            {
                for (int i = 1; i < Nums + 1; i++)
                {
                    Obcolor[i] = altColor;
                }

            }
            else if (obcolor == 2)
            {
                for (int i = 1; i < Nums + 1; i++)
                {
                    grayscale = Random.Range(0f, 1f);
                    altColor.r -= grayscale;
                    altColor.g -= grayscale;
                    altColor.b -= grayscale;
                    altColor = new Color(altColor.r, altColor.g, altColor.b, 1);                    
                    Obcolor[i] = altColor;

                }
            }
            else if (obcolor == 3)
            {
                for (int i = 1; i < Nums + 1; i++)
                {
                    altColor.r = (Random.Range(0f, 1f));
                    altColor.g = (Random.Range(0f, 1f));
                    altColor.b = (Random.Range(0f, 1f));
                    altColor = new Color(altColor.r, altColor.g, altColor.b, 1);
                    Obcolor[i] = altColor;

                }
            }        
        }

        else if (obstyle == 2)
        {
            obheights = 0.01f;
            Obcolor = new Color[Nums + 1];

            for (int i = 1; i < Nums + 1; i++)
            {
                Obcolor[i] = altColor_target;
            }            

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

        }

        else if (obstyle == 3)
        {
            obheights_target = 0.01f;
            obdepths = 0.1f;
            altColor = new Color(1, 0, 0, 1);
            altColor_target = altColor_target;

            // obstacle height manipulation
            if (obheighttoggle == 1)
            {
                for (int i = 1; i < Nums + 1; i++)
                {
                    obheights = PlayerPrefs.GetFloat("ObHeightnum");
                    Obheight.Add(obheights);
                }
            }
            else if (obheighttoggle == 2)
            {
                for (int i = 1; i < Nums + 1; i++)
                {
                    obheights = (Random.Range(obstacleheights - 0.03f, obstacleheights + 0.03f));
                    Obheight.Add(obheights);
                }
            }
            else if (obheighttoggle == 3)
            {
                for (int i = 1; i < Nums + 1; i++)
                {
                    obheights = (Random.Range(obstacleheights - 0.05f, obstacleheights + 0.05f));
                    Obheight.Add(obheights);
                }
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

        }

        // obstacle width manipulation
        if (obwidth == 1)
        {
            for (int i = 1; i < Nums + 1; i++)
            {
                obwidthposition = (Random.Range(0.64f, 2.14f));
                Obwidth.Add(obwidthposition);
            }
        }
        else if (obwidth == 2)
        {
            for (int i = 1; i < Nums + 1; i++)
            {
                obwidthposition = (Random.Range(0.94f, 1.94f));
                Obwidth.Add(obwidthposition);
            }
        }
        else if (obwidth == 3)
        {
            for (int i = 1; i < Nums + 1; i++)
            {
                obwidthposition = 1.37f;
                Obwidth.Add(obwidthposition);
            }
        }

        // appearance predictability
        if (obappearancepred == 1)
        {
            timer = 0;
        }

        else if (obappearancepred == 2)
        {
            timer = 3;
        }

        else if (obappearancepred == 3)
        {
            timer = 3;
        }

    }
    
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "obstacle")
        {
            audioSource.clip = failedClip;
            if (played_sound == false)
            {
                audioSource.Play();
                played_sound = true;                
            }
            
        }        
        
        if (other.tag == "indicator")
        {
            touched_child += 1;
            
        }

        if (other.tag == "target")
        {
            audioSource.clip = SuccessClip;
            if (played_sound == false)
            {
                audioSource.Play();
                played_sound = true;
            }
            Score++;
        }

        if (other.tag == "indicator_target")
        {
            touched_child_target += 1;
        }

    }

    void OnTriggerExit(Collider other)
    {
       
        if (other.tag == "obstacle")
        {
            Destroy(other.gameObject, 2.0f);
        }

        if (other.tag == "target")
        {
            Destroy(other.gameObject, 2.0f);
        }

        if (other.tag == "indicator")
        {
            Destroy(other.gameObject, 2.0f);
        }

        if (other.tag == "indicator_target")
        {
            Destroy(other.gameObject, 2.0f);
        }

        if (touched_child >= 2 && played_sound == false)
        {
            audioSource.clip = SuccessClip;
            audioSource.Play();
            Score++;

            touched_child = 0;

            if (i < Nums)
            {
                //float position = (float)obpos[i];

                // assign variables
                float obheightvariable = (float)Obheight[i];
                float obwidthvariable = (float)Obwidth[i];
                float position = (Random.Range(-10.0f, -5.1f));
                Vector3 Obposition = new Vector3(position, obheightvariable / 2f, obwidthvariable);

                // instantiate obstacles
                
                GameObject go = Instantiate(obstacles, Obposition, Quaternion.identity) as GameObject;

                // change color
                MeshRenderer gameObjectRenderer = go.GetComponent<MeshRenderer>();
                Material newMaterial = new Material(Shader.Find("Legacy Shaders/Diffuse"));
                newMaterial.color = Obcolor[i];
                gameObjectRenderer.material = newMaterial;

                // scale obstacles
                Vector3 scale = go.transform.localScale;
                scale.Set(obdepths, obheightvariable, obwidthvar);
                go.transform.localScale = scale;

                // put it under the parent object
                go.transform.parent = GameObject.Find("Objects").transform;
                i++;
                
            }

        }

        if (touched_child >= 2 && played_sound == true)
        {
            played_sound = false;
            touched_child = 0;

            if (i < Nums)
            {
                //float position = (float)obpos[i];

                // assign variables
                float obheightvariable = (float)Obheight[i];
                float obwidthvariable = (float)Obwidth[i];
                float position = (Random.Range(-10.0f, -5.1f));
                Vector3 Obposition = new Vector3(position, obheightvariable / 2f, obwidthvariable);

                // instantiate obstacles
                GameObject go = Instantiate(obstacles, Obposition, Quaternion.identity) as GameObject;

                // change color
                MeshRenderer gameObjectRenderer = go.GetComponent<MeshRenderer>();
                Material newMaterial = new Material(Shader.Find("Legacy Shaders/Diffuse"));
                newMaterial.color = Obcolor[i];
                gameObjectRenderer.material = newMaterial;

                // scale obstacles
                Vector3 scale = go.transform.localScale;
                scale.Set(0.1f, obheightvariable, obwidthvar);
                go.transform.localScale = scale;

                // put it under the parent object
                go.transform.parent = GameObject.Find("Objects").transform;
                i++;

            }
        }

        if (touched_child_target >= 2 && played_sound == false)
        {
            audioSource.clip = failedClip;
            audioSource.Play();
            

            touched_child_target = 0;

            if (i < Nums)
            {
                //float position = (float)obpos[i];

                // assign variables
                float obwidthvariable = (float)Obwidth[i];
                float position = (Random.Range(-10.0f, -5.1f));
                Vector3 Obposition = new Vector3(position, 0.01f, obwidthvariable);

                // instantiate obstacles

                GameObject go = Instantiate(targets, Obposition, Quaternion.identity) as GameObject;

                // change color
                MeshRenderer gameObjectRenderer = go.GetComponent<MeshRenderer>();
                Material newMaterial = new Material(Shader.Find("Legacy Shaders/Diffuse"));
                newMaterial.color = Obcolor[i];
                gameObjectRenderer.material = newMaterial;

                // scale obstacles
                Vector3 scale = go.transform.localScale;
                scale.Set(obdepths_target, 0.02f, obwidthvar);
                go.transform.localScale = scale;

                // put it under the parent object
                go.transform.parent = GameObject.Find("Objects").transform;
                i++;

            }

        }

        if (touched_child_target >= 2 && played_sound == true)
        {
            played_sound = false;
            touched_child_target = 0;

            if (i < Nums)
            {
                //float position = (float)obpos[i];

                // assign variables                
                float obwidthvariable = (float)Obwidth[i];
                float position = (Random.Range(-10.0f, -5.1f));
                Vector3 Obposition = new Vector3(position, 0.01f, obwidthvariable);

                // instantiate obstacles
                GameObject go = Instantiate(targets, Obposition, Quaternion.identity) as GameObject;

                // change color
                MeshRenderer gameObjectRenderer = go.GetComponent<MeshRenderer>();
                Material newMaterial = new Material(Shader.Find("Legacy Shaders/Diffuse"));
                newMaterial.color = Obcolor[i];
                gameObjectRenderer.material = newMaterial;

                // scale obstacles
                Vector3 scale = go.transform.localScale;
                scale.Set(obdepths_target, 0.02f, obwidthvar);
                go.transform.localScale = scale;

                // put it under the parent object
                go.transform.parent = GameObject.Find("Objects").transform;
                i++;

            }
        }

    }
}
