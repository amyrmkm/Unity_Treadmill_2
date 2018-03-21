using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{

    // toggle game objects
    public Toggle Heightlevel1;
    public Toggle Heightlevel2;
    public Toggle Heightlevel3;
    public Toggle Widthlevel1;
    public Toggle Widthlevel2;
    public Toggle Widthlevel3;
    public Toggle Shapelevel1;
    public Toggle Shapelevel2;
    public Toggle Shapelevel3;
    public Toggle Colorlevel1;
    public Toggle Colorlevel2;
    public Toggle Colorlevel3;
    public Toggle Predlevel1;
    public Toggle Predlevel2;
    public Toggle Predlevel3;
    public Toggle Stylelevel1;
    public Toggle Stylelevel2;
    public Toggle Stylelevel3;
    public Toggle Wavelevel1;
    public Toggle Wavelevel2;
    public Toggle Wavelevel3;
    public GameObject scenemanager;
    private GameObject obstacles;
    public InputField speed;
    public static float treadmillspeed;
    public InputField numbOb;
    public static int numbObInput;
    public InputField height;
    public static float obstacleheight;
    public ArrayList heightArray = new ArrayList();
    public ArrayList widthposArray = new ArrayList();
    //private GameObject go;

    void Start()
    {
        
    }

    public void Setspeed()
    {
        treadmillspeed = float.Parse(speed.text);
        PlayerPrefs.SetFloat("TreadmillInput", treadmillspeed);
    }

    public void SetNumber()
    {
        numbObInput = int.Parse(numbOb.text);
        PlayerPrefs.SetInt("NumbOb", numbObInput);
    }
    public void SetHeight()
    {
        obstacleheight = float.Parse(height.text);        
    }

    public void ActiveToggle()
    {
        
        // height toggle
        if (Heightlevel1.isOn)
        {
            PlayerPrefs.SetInt("ObHeight", 1);
            PlayerPrefs.SetFloat("ObHeightnum", obstacleheight);
        }
        else if (Heightlevel2.isOn)
        {
            PlayerPrefs.SetInt("ObHeight", 2);
            PlayerPrefs.SetFloat("ObHeightnum", obstacleheight);
        }
        else if (Heightlevel3.isOn)
        {
            PlayerPrefs.SetInt("ObHeight", 3);
            PlayerPrefs.SetFloat("ObHeightnum", obstacleheight);
        }

        // width toggle
        if (Widthlevel1.isOn)
        {
            PlayerPrefs.SetInt("ObWidth", 1);
            PlayerPrefs.SetFloat("ObWidthVar", 0.8f);
        }
        else if (Widthlevel2.isOn)
        {
            PlayerPrefs.SetInt("ObWidth", 2);
            PlayerPrefs.SetFloat("ObWidthVar", 1.5f);
        }

        else if (Widthlevel3.isOn)
        {
            PlayerPrefs.SetInt("ObWidth", 3);
            PlayerPrefs.SetFloat("ObWidthVar", 3f);
        }

        // shape toggle
        if (Shapelevel1.isOn)
        {
            PlayerPrefs.SetInt("ObShape", 1);
        }
        else if (Shapelevel2.isOn)
        {
            PlayerPrefs.SetInt("ObShape", 2);            
        }
        else if (Shapelevel3.isOn)
        {
            PlayerPrefs.SetInt("ObShape", 3);            
        }

        // color toggle
        if (Colorlevel1.isOn)
        {
            PlayerPrefs.SetInt("ObColor", 1);
        }
        else if (Colorlevel2.isOn)
        {
            PlayerPrefs.SetInt("ObColor", 2);
        }
        else if (Colorlevel3.isOn)
        {
            PlayerPrefs.SetInt("ObColor", 3);
        }

        // predictability toggle
        if (Predlevel1.isOn)
        {
            PlayerPrefs.SetInt("ObPred", 1);
        }
        else if (Predlevel2.isOn)
        {
            PlayerPrefs.SetInt("ObPred", 2);
        }
        else if (Predlevel3.isOn)
        {
            PlayerPrefs.SetInt("ObPred", 3);
        }

        // negotiation style toggle
        if (Stylelevel1.isOn)
        {
            PlayerPrefs.SetInt("ObStyle", 1);
        }
        else if (Stylelevel2.isOn)
        {
            PlayerPrefs.SetInt("ObStyle", 2);
        }
        else if (Stylelevel3.isOn)
        {
            PlayerPrefs.SetInt("ObStyle", 3);
        }

        // Wave toggle
        if (Wavelevel1.isOn)
        {
            PlayerPrefs.SetInt("ObWave", 1);
        }
        else if (Wavelevel2.isOn)
        {
            PlayerPrefs.SetInt("ObWave", 2);
        }
        else if (Wavelevel3.isOn)
        {
            PlayerPrefs.SetInt("ObWave", 3);
        }
    }

    public void OnSubmit()
    {
        
        Setspeed();
        SetNumber();
        SetHeight();
        ActiveToggle();

    }

}