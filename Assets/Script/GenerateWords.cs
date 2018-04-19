using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWords : MonoBehaviour
{

    public TextAsset textFile;
    string[] ListofWords;    
    List<string> Task = new List<string>();
    private ArrayList order = new ArrayList();

    // Use this for initialization
    void Start()
    {
        if (textFile != null)
        {
            ListofWords = (textFile.text.Split('\n'));

            for (int i = 1; i < 5; i++)
            {
                int randomIndex = Random.Range(0, 20);
                order.Add(randomIndex);
                if (order.Contains(randomIndex))
                {
                    Debug.Log(i);
                    i -= 1;
                    Debug.Log(i);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                int listorder = (int)order[i];
                string dialog = ListofWords[listorder];
                Task.Add(dialog);
            }
        }
    }

    public void OnGUI()
    {
        for (int i = 0; i < Task.Count; i++)
        {
            GUI.Label(new Rect(100, 100 + (i * 30), 200, 30), Task[i]);
        }
    }
}
