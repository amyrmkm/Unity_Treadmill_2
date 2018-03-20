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
    private ArrayList obpos;
    private GameObject obstacles;
    private int Nums;
    private GameObject go;
    static int touched_child = 0;
    static bool played_sound = false;
    private int i;
    private float obstacleheights;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        randpl = obmanager.GetComponent<Randomplace>();

        obpos = randpl.get();
        obstacles = randpl.prefab;
        Nums = randpl.NumberOfObstacles;
        obstacleheights = PlayerPrefs.GetFloat("ObHeight");
        i = 2;
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
            Destroy(other.gameObject.transform.parent.gameObject, 2.0f);
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
                float position = (float)obpos[i];
                Vector3 Obposition = new Vector3(position, obstacleheights/2f, 1.37f);
                //Debug.Log(Obposition); //position coordinates are correct, but the object is placed relative to the position of the tracker

                GameObject go = Instantiate(obstacles, Obposition, Quaternion.identity) as GameObject;
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

                float position = (float)obpos[i];
                Vector3 Obposition = new Vector3(position, obstacleheights/2f, 1.37f);
                //Debug.Log(Obposition); //position coordinates are correct, but the object is placed relative to the position of the tracker

                GameObject go = Instantiate(obstacles, Obposition, Quaternion.identity) as GameObject;
                go.transform.parent = GameObject.Find("Objects").transform;
                i++;

            }
        }

        
    }
}
