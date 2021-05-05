using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TextAsset allText;

    //variables determining which choices effect what competencies.
    [Range(0, 5)]
    public int effect1;
    [Range(0, 5)]
    public int effect2;

    private int i = 0;
    private bool choiceMade = true;
    private bool makeAChoice = false;

    private string[] Dialog;
    private string[] curDialog;

    // Start is called before the first frame update
    void Start()
    {
        Dialog = allText.ToString().Split('*');
        curDialog = Dialog;
        Speak();
    }

    // Update is called once per frame
    // Since each part of the dialogue is in an array,
    // pressing the button should bring you to the next
    // part of the dialogue.
    void Update()
    {
        if(GameManager.Instance.getIndex() >= curDialog.Length-1 && !makeAChoice)
        {
            GameManager.Instance.enableChoice();
            makeAChoice = true;
        }
        if (Input.GetMouseButtonDown(0) && choiceMade)
        {
            Speak();
            if (makeAChoice)
            {
                choiceMade = false;
            }
        }
    }

    public void switchChoiceMade(bool val)
    {
        choiceMade = val;
    }


    //Calls an instance of gamemanager and gives the i element
    //in the dialog array to the method StartDialog
    public void Speak()
    {
        Debug.Log("hi" + i);
        GameManager.Instance.StartDialog(curDialog);
        i++;
    }

    public void Choice1()
    {
        choiceMade = true;
        GameManager.Instance.increaseComp(effect1);
        GameManager.Instance.setIndex(0);
    }
    public void Choice2()
    {
        choiceMade = true;
        GameManager.Instance.increaseComp(effect2);
        GameManager.Instance.setIndex(0);
    }
}
