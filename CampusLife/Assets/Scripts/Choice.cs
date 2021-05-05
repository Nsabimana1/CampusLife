using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour
{

    public string toScene;
    public string otherScene;
    public string choice1text;
    public string choice2text;
    public string other1text;
    public string other2text;
    public string character;
    public string othercharacter;
    public string comp;
    public string experience;

    // Start is called before the first frame update
    private void Start()
    {

        GameManager.Instance.setChoices(toScene, otherScene, choice1text, choice2text, other1text, other2text, character, othercharacter);
        GameManager.Instance.updateComp(comp);
        GameManager.Instance.addExperince(experience);
    }

}
