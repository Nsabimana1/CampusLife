using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour
{
    //All the dialogue in the scene.
    public TextAsset allText;

    //variables determining which choices effect what competencies.
    [Range(0,5)]
    public int effect1;
    [Range(0,5)]
    public int effect2;
    
    //variable that temporarily stores all choices
    private string[] choices;

    //dialog that show immediate effects of choice
    private string[] text1;
    private string[] text2;

    //pointer to current element needed. 
    private int i = 0;
    private bool choiceMade = false;

    //pointer to what is the current dialog we need right now.
    //honestly, kind of a hacky thing I have made.
    private string[] curDialog;

    // Start is called before the first frame update
    void Start()
    {
        choices = allText.ToString().Split('|');
        text1 = choices[0].Split('*');
        text2 = choices[1].Split('*');
    }

    // Update is called once per frame
    // Since each part of the dialogue is in an array,
    // pressing the button should bring you to the next
    // part of the dialogue.
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && choiceMade)
        {
            Speak(curDialog);
        }

    }

    //Calls an instance of gamemanager and gives the i element
    //in the dialog array to the method StartDialog
    public void Speak(string[] Dialog)
    {
        GameManager.Instance.StopDialog();
        GameManager.Instance.StartDialog(Dialog[i]);
        i++;
    }

    public void Choice1()
    {
        choiceMade = true;
        GameManager.Instance.increaseComp(effect1);
        curDialog = text1;
        i = 0;
        Speak(curDialog);
    }
    public void Choice2()
    {
        choiceMade = true;
        GameManager.Instance.increaseComp(effect2);
        curDialog = text2;
        i = 0;
        Speak(curDialog);
    }
}
