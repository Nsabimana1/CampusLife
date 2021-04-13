using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour
{
    //All the dialogue in the scene.
    public TextAsset allText;

    //dialog that show immediate effects of choice
    private string[] text1;
    private string[] text2;

    //pointer to current element needed. 
    private int i = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    // Since each part of the dialogue is in an array,
    // pressing the button should bring you to the next
    // part of the dialogue.
    void Update()
    {

    }
}
