using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour
{

    public string toScene;
    public string choice1text;
    public string choice2text;

    // Start is called before the first frame update
    private void Start()
    {
        GameManager.Instance.setChoices(toScene, choice1text, choice2text);
    }

    // Update is called once per frame
    // Since each part of the dialogue is in an array,
    // pressing the button should bring you to the next
    // part of the dialogue.
    void Update()
    {

    }

}
