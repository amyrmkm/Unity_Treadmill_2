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
    private int Nums;
    private GameObject go;
    static int touched_child = 0;
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

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        randpl = obmanager.GetComponent<Randomplace>();

        //obpos = randpl.get();
        obstacles = randpl.prefab;
        Nums = randpl.NumberOfObstacles;
        obheighttoggle = PlayerPrefs.GetInt("ObHeight");
        obstacleheights = PlayerPrefs.GetFloat("ObHeightnum");
        obwidth = PlayerPrefs.GetInt("ObWidth");
        obwidthvar = PlayerPrefs.GetFloat("ObWidthVar");
        obshape = PlayerPrefs.GetInt("ObShape");
        obcolor = PlayerPrefs.GetInt("ObColor");
        obdynamicpred = PlayerPrefs.GetInt("ObDynamicPred");
        obappearancepred = PlayerPrefs.GetInt("ObAppearancePred");
        obstyle = PlayerPrefs.GetInt("ObStyle");
        obwave = PlayerPrefs.GetInt("ObWave");
        i = 1;

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

        // obstacle color manipulation
        Obcolor = new Color[Nums+1];
        
        if (obcolor == 1)
        {
            for (int i = 1; i < Nums + 1; i++) {                 
                Obcolor[i] = altColor;
            }
        
        }
        else if (obcolor == 2)
        {
            for (int i = 1; i < Nums + 1; i++)
            {
                altColor.r = (Random.Range(0f, 0.2f));
                altColor.g = (Random.Range(0f, 0.2f));
                altColor.b = (Random.Range(0f, 0.2f));
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
    }

    void OnTriggerExit(Collider other)
    {
       // Debug.Log("Exit " + other.gameObject);
        if (other.tag == "obstacle")
        {
            Destroy(other.gameObject, 2.0f);
            //Debug.Log("HI");
        }

        if (other.tag == "indicator")
        {
            Destroy(other.gameObject, 2.0f);
            //Debug.Log("HI");
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
                scale.Set(0.1f, obheightvariable, obwidthvar);
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

        
    }
}
