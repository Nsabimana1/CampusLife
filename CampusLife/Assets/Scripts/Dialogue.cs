using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TextAsset allText;

    private int i = 0;

    private string[] Dialog;

    // Start is called before the first frame update
    void Start()
    {
        Dialog = allText.ToString().Split('*');
        Speak();
    }

    // Update is called once per frame
    // Since each part of the dialogue is in an array,
    // pressing the button should bring you to the next
    // part of the dialogue.
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Speak();
        }
        
    }

    //Calls an instance of gamemanager and gives the i element
    //in the dialog array to the method StartDialog
    public void Speak()
    {
        GameManager.Instance.StopDialog();
        GameManager.Instance.StartDialog(Dialog[i]);
        i++;
    }    
}
