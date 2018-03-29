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
    public Toggle Depthlevel1;
    public Toggle Depthlevel2;
    public Toggle Depthlevel3;
    public Toggle Colorlevel1;
    public Toggle Colorlevel2;
    public Toggle Colorlevel3;
    public Toggle DyPredlevel1;
    public Toggle DyPredlevel2;
    public Toggle DyPredlevel3;
    public Toggle ApPredlevel1;
    public Toggle ApPredlevel2;
    public Toggle ApPredlevel3;
    public Toggle Stylelevel1;
    public Toggle Stylelevel2;
    public Toggle Stylelevel3;
    public Toggle Lightinglevel1;
    public Toggle Lightinglevel2;
    public Toggle Lightinglevel3;
    public Toggle Duallevel1;
    public Toggle Duallevel2;
    public Toggle Duallevel3;
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
        if (Depthlevel1.isOn)
        {
            PlayerPrefs.SetInt("ObDepth", 1);
        }
        else if (Depthlevel2.isOn)
        {
            PlayerPrefs.SetInt("ObDepth", 2);            
        }
        else if (Depthlevel3.isOn)
        {
            PlayerPrefs.SetInt("ObDepth", 3);            
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

        // dynamic predictability toggle
        if (DyPredlevel1.isOn)
        {
            PlayerPrefs.SetInt("ObDynamicPred", 1);
        }
        else if (DyPredlevel2.isOn)
        {
            PlayerPrefs.SetInt("ObDynamicPred", 2);
        }
        else if (DyPredlevel3.isOn)
        {
            PlayerPrefs.SetInt("ObDynamicPred", 3);
        }

        // appearance predictability toggle
        if (ApPredlevel1.isOn)
        {
            PlayerPrefs.SetInt("ObAppearancePred", 1);
        }
        else if (ApPredlevel2.isOn)
        {
            PlayerPrefs.SetInt("ObAppearancePred", 2);
        }
        else if (ApPredlevel3.isOn)
        {
            PlayerPrefs.SetInt("ObAppearancePred", 3);
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

        // lighting toggle
        if (Lightinglevel1.isOn)
        {
            PlayerPrefs.SetInt("Lighting", 1);
        }
        else if (Lightinglevel2.isOn)
        {
            PlayerPrefs.SetInt("Lighting", 2);
        }
        else if (Lightinglevel2.isOn)
        {
            PlayerPrefs.SetInt("Lighting", 3);
        }

        // dual task toggle
        if (Duallevel1.isOn)
        {
            PlayerPrefs.SetInt("DualTask", 1);
        }
        else if (Duallevel2.isOn)
        {
            PlayerPrefs.SetInt("DualTask", 2);
        }
        else if (Duallevel2.isOn)
        {
            PlayerPrefs.SetInt("DualTask", 3);
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