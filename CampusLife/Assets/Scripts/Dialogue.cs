using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TextAsset allText;
    public TextAsset choiceText;

    //variables determining which choices effect what competencies.
    [Range(0, 5)]
    public int effect1;
    [Range(0, 5)]
    public int effect2;

    private string temp;
    private int i = 0;
    private bool choiceMade = true;

    //variable that temporarily stores all choices
    private string[] choices;

    private string[] Dialog;
    private string[] choice1;
    private string[] choice2;
    private string[] curDialog;

    // Start is called before the first frame update
    void Start()
    {
        Dialog = allText.ToString().Split('*');
        temp = choiceText.ToString();
        if (temp != "") 
        { 
            choices = temp.Split('|');
            choice1 = choices[0].Split('*');
            choice2 = choices[1].Split('*');
        }
        curDialog = Dialog;
        Debug.Log(i);
        Debug.Log(curDialog[i]);
        Speak();
    }

    // Update is called once per frame
    // Since each part of the dialogue is in an array,
    // pressing the button should bring you to the next
    // part of the dialogue.
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && choiceMade)
        {
            Speak();
        }
    }

    //Calls an instance of gamemanager and gives the i element
    //in the dialog array to the method StartDialog
    public void Speak(bool newDialog = false)
    {
        if (!newDialog)
        {
            GameManager.Instance.StartDialog(Dialog[i]);
        }
        else
        {
            GameManager.Instance.StartDialog(getDialog());
        }
        if (i == Dialog.Length)
        {
            choiceMade = false;
            GameManager.Instance.enableChoice();
        }
    }

    private string getDialog()
    {
        string dialog = Dialog[i];
        i++; 
        if (i == Dialog.Length)
        {
            choiceMade = false;
            GameManager.Instance.enableChoice();
        }
        return dialog;

    }

    public void Choice1()
    {
        choiceMade = true;
        GameManager.Instance.increaseComp(effect1);
        curDialog = choice1;
        i = 0;
        Speak();
    }
    public void Choice2()
    {
        choiceMade = true;
        GameManager.Instance.increaseComp(effect2);
        curDialog = choice2;
        i = 0;
        Speak();
    }
}
