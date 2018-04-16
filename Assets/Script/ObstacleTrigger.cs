using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour {

    public int Score = 0;    
    public AudioClip failedClip;
    public AudioClip SuccessClip;
	public GameObject obmanager;

    private AudioSource audioSource;    
    private Randomplace randpl;
    private GameObject obstacles;
    private GameObject targets;
    private int Nums;
    private GameObject go;
	private int i = 1;

    static int touched_child = 0;
    static int touched_child_target = 0;
    static bool played_sound = false;

	public Vector3 Obposition;
    private float obstacleheights = 0.14f;
	private int obheighttoggle = 1;
    private int obwidth = 1;
    private float obwidthvar = 1;
    private int obcolor = 1;
    private int obappearancepred = 1;
    private int obstyle = 1;
	private int obdepth = 1;

    private float obwidthposition;
    private float obheights;
	private float obdepths;
	private float obdepths_target;
	private float obheights_target;
	private float timer;
	private float timer_destroy;
	public float speed;
	public float movetime;    

    private Color altColor =  new Color(1f, 1f, 1f, 1);
	private Color altColor_target = new Color(1f, 1f, 1f, 1);
	private float grayscale;

    private ArrayList Obheight = new ArrayList();
	private ArrayList Obwidth = new ArrayList();
	private ArrayList ObOrder_ori = new ArrayList();
	private ArrayList ObOrder = new ArrayList();
    private Color[] Obcolor;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        randpl = obmanager.GetComponent<Randomplace>();

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
        obappearancepred = PlayerPrefs.GetInt("ObAppearancePred");
        obstyle = PlayerPrefs.GetInt("ObStyle");
        speed = PlayerPrefs.GetFloat("TreadmillInput") / 2.23694f;

		// step over only ---------------------------------------------------

        if (obstyle == 1)
        {
            obdepths = 0.1f;

            // obstacle height manipulation
            if (obheighttoggle == 1)
            {
                for (int i = 1; i < Nums + 1; i++)
                {
                    obheights = obstacleheights;
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

		// step on only ---------------------------------------------------------

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

		// step over or step on mixed --------------------------------------------

        else if (obstyle == 3)
        {

			for (int i = 0; i < Nums; i++) {
				ObOrder_ori [i] = i;			
			}

			for (int i = 0; i < Nums; i++) {
				int temp = (int)ObOrder_ori[i];
				int randomIndex = Random.Range(i, Nums);
				ObOrder[i] = ObOrder[randomIndex];
				ObOrder[randomIndex] = temp;
			}

			obheights_target = 0.01f;
            obdepths = 0.1f;
            altColor = new Color(1, 0, 0, 1);
            altColor_target = altColor_target;

            // obstacle height manipulation
            if (obheighttoggle == 1)
            {
                for (int i = 1; i < Nums + 1; i++)
                {
                    obheights = obstacleheights;
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

		// general variables regardless of negotiation style ------------------------

		// obstacle width manipulation
		if (obwidth == 1)
		{
			for (int i = 1; i < Nums + 1; i++)
			{
				obwidthposition = (Random.Range(0.94f, 1.94f));
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
			timer = 0.0f;
			timer_destroy = speed*20f;
		}

		else if (obappearancepred == 2)
		{
			timer = speed * (4f / speed);
			timer_destroy = speed*20f;
		}

		else if (obappearancepred == 3)
		{
			timer = 0f;
			timer_destroy = speed * (3f / speed);
		}
    }
    

	// When trackers get into the trigger (obstacle or target) --------------------

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "obstacle")
        {            
            if (played_sound == false)
            {
				audioSource.clip = failedClip;
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
            if (played_sound == false)
            {
				audioSource.clip = SuccessClip;
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


	// When trackers get out of the trigger (obstacle or target) ------------------

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

			if (obstyle == 1 || obstyle == 2) 
			{
				if (i < Nums) {
					StartCoroutine (PlaceObstacle (timer, timer_destroy));
					i++;
				}
			}

			else if (obstyle == 3)
			{
				for (int i = 0; i < Nums; i++) 
				{
					int oborderint = (int)ObOrder [i];
					if (oborderint % 2 == 0) 
					{
						StartCoroutine (PlaceObstacle (timer, timer_destroy));
						i++;
					} 
					else if (oborderint % 2 == 1) 
					{
						StartCoroutine(PlaceTarget(timer, timer_destroy));
						i++;
					}
				}
			}
        }

        if (touched_child >= 2 && played_sound == true)
        {
            played_sound = false;
            touched_child = 0;

			if (obstyle == 1 || obstyle == 2) 
			{
				if (i < Nums) {
					StartCoroutine (PlaceObstacle (timer, timer_destroy));
					i++;
				}
			}

			else if (obstyle == 3)
			{
				for (int i = 0; i < Nums; i++) 
				{
					int oborderint = (int)ObOrder [i];
					if (oborderint % 2 == 0) 
					{
						StartCoroutine (PlaceObstacle (timer, timer_destroy));
						i++;
					} 
					else if (oborderint % 2 == 1) 
					{
						StartCoroutine(PlaceTarget(timer, timer_destroy));
						i++;
					}
				}
			}
        }

        if (touched_child_target >= 2 && played_sound == false)
        {
            audioSource.clip = failedClip;
            audioSource.Play();
            touched_child_target = 0;

			if (obstyle == 1 || obstyle == 2) 
			{
				if (i < Nums) {
					StartCoroutine(PlaceTarget(timer, timer_destroy));
					i++;
				}
			}

			else if (obstyle == 3)
			{
				for (int i = 0; i < Nums; i++) 
				{
					int oborderint = (int)ObOrder [i];
					if (oborderint % 2 == 0) 
					{
						StartCoroutine (PlaceObstacle (timer, timer_destroy));
						i++;
					} 
					else if (oborderint % 2 == 1) 
					{
						StartCoroutine(PlaceTarget(timer, timer_destroy));
						i++;
					}
				}
			}
        }

        if (touched_child_target >= 2 && played_sound == true)
        {
            played_sound = false;
            touched_child_target = 0;

			if (obstyle == 1 || obstyle == 2) 
			{
				if (i < Nums) {
					StartCoroutine(PlaceTarget(timer, timer_destroy));
					i++;
				}
			}

			else if (obstyle == 3)
			{
				for (int i = 0; i < Nums; i++) 
				{
					int oborderint = (int)ObOrder [i];
					if (oborderint % 2 == 0) 
					{
						StartCoroutine (PlaceObstacle (timer, timer_destroy));
						i++;
					} 
					else if (oborderint % 2 == 1) 
					{
						StartCoroutine(PlaceTarget(timer, timer_destroy));
						i++;
					}
				}
			}
        }
    }



	// function to create obstacles 

	IEnumerator PlaceObstacle(float waitTime, float destroytime)
	{
		yield return new WaitForSeconds (waitTime);
        
		// assign variables
		float obheightvariable = (float)Obheight [i];
		float obwidthvariable = (float)Obwidth [i];
		float position = (Random.Range (-10.0f, -5.1f));
		Vector3 Obposition = new Vector3 (position, obheightvariable / 2f, obwidthvariable);

		// instantiate obstacles            
		GameObject go = Instantiate (obstacles, Obposition, Quaternion.identity) as GameObject;
		go.GetComponent<MoveObstacle> ().startpos = Obposition;

		// change color
		MeshRenderer gameObjectRenderer = go.GetComponent<MeshRenderer> ();
		Material newMaterial = new Material (Shader.Find ("Legacy Shaders/Diffuse"));
		newMaterial.color = Obcolor [i];
		gameObjectRenderer.material = newMaterial;

		// scale obstacles
		Vector3 scale = go.transform.localScale;
		scale.Set (0.1f, obheightvariable, obwidthvar);
		go.transform.localScale = scale;

		// put it under the parent object
		go.transform.parent = GameObject.Find ("Objects").transform;
		go.GetComponent<MoveObstacle> ().parentpos = go.transform.parent.position;

		// destory the object after a certain time
		yield return new WaitForSeconds (destroytime);
		if (go != null) {			
			go.GetComponent<MeshRenderer> ().enabled = false; 
		}
	}


	// function to create targets

	IEnumerator PlaceTarget(float waitTime, float destroytime)
	{
		yield return new WaitForSeconds (waitTime);        

		// assign variables                
		float obwidthvariable = (float)Obwidth [i];
		float position = (Random.Range (-10.0f, -5.1f));
		Vector3 Obposition = new Vector3 (position, 0.02f / 2, obwidthvariable);

		// instantiate obstacles                
		GameObject go = Instantiate (targets, Obposition, Quaternion.identity) as GameObject;
		go.GetComponent<MoveObstacle> ().startpos = Obposition;

		// change color
		MeshRenderer gameObjectRenderer = go.GetComponent<MeshRenderer> ();
		Material newMaterial = new Material (Shader.Find ("Legacy Shaders/Diffuse"));
		newMaterial.color = Obcolor [i];
		gameObjectRenderer.material = newMaterial;

		// scale obstacles
		Vector3 scale = go.transform.localScale;
		scale.Set (obdepths_target, 0.02f, obwidthvar);
		go.transform.localScale = scale;

		// put it under the parent object
		go.transform.parent = GameObject.Find ("Objects").transform;
		go.GetComponent<MoveObstacle> ().parentpos = go.transform.parent.position;

		// destory the object after a certain time
		yield return new WaitForSeconds (destroytime);
		if (go != null) {			
			go.GetComponent<MeshRenderer> ().enabled = false;
		}
	}
}
