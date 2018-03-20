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
    public GameObject obstacles;
    public InputField speed;
    public static float treadmillspeed;
    public InputField numbOb;
    public static int numbObInput;
    public InputField height;
    public static float obstacleheight;
    public ArrayList heightArray = new ArrayList();

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
        PlayerPrefs.SetFloat("ObHeight", obstacleheight);
    }

    public void ActiveToggle()
    {
        if (Heightlevel1.isOn)
        {
            obstacles.transform.localScale += new Vector3(0, obstacleheight, 0);
        }
        else if (Heightlevel2.isOn)
        {
            for (int i = 1; i < numbObInput + 1; i++)
            {
                float obheights = (Random.Range(obstacleheight - 0.14f - 0.03f, obstacleheight - 0.14f + 0.03f));
                obstacles.transform.localScale += new Vector3(0, obheights, 0);
            }
        }
        else if (Heightlevel3.isOn)
        {
            for (int i = 1; i < numbObInput + 1; i++)
            {
                float obheights = (Random.Range(obstacleheight - 0.14f - 0.05f, obstacleheight - 0.14f + 0.05f));
                obstacles.transform.localScale += new Vector3(0, obheights, 0);
            }
        }

        if (Widthlevel1.isOn)
        {
            obstacles.transform.localScale -= new Vector3(0, 0, -2f);
        }
        else if (Widthlevel2.isOn)
        {
            obstacles.transform.localScale -= new Vector3(0, 0, -1f);
        }
        else if (Widthlevel3.isOn)
        {
            obstacles.transform.localScale += new Vector3(0, 0, 0);
        }
    }

    public void OnSubmit()
    {
        ActiveToggle();
        Setspeed();
        SetNumber();
        SetHeight();
        
    }

}