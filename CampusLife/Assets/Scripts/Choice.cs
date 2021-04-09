using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour
{
    public TextAsset allText;
    private string dialog;
    private string[] choices;
    private string[] text1;
    private string[] text2;
    private int len;

    // Start is called before the first frame update
    void Start()
    {
        dialog = allText.ToString();
        choices = dialog.Split('|');
        text1 = choices[0].Split('*');
        text2 = choices[1].Split('*');
        len = System.Math.Min(text1.Length, text2.Length);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < len; i++)
        {
            Debug.Log(text1[i]);
            Debug.Log(text2[i]);
        }
    }

    public void Choice1()
    {

    }
    public void Choice2()
    {

    }
}
