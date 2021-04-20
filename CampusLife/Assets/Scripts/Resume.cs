using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    public TextAsset ResumeText;
    private int[] c;
    private string[] theResume;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        c = getComp();
    }

    public int[] getComp()
    {
        return GameManager.Instance.getPlayer().giveComp();
    }

    public void updateResume()
    {
        //function that updates resume based off of the current compentencies in the text.
        //Some things like "Work in group enviornments or created website"
        //Maybe we get different string based on the choices players make.
    }

    public void updateIntern()
    {
        //Also check to see if new string is in the string, otherwise we don't update
        if (GameManager.Instance.getPlayer().getInternship())
        {
            //update string to include stuff about internship
        }
    }
    public void updateClub()
    {
        //Also check to see if new string is in the string, otherwise we don't update
        if (GameManager.Instance.getPlayer().getClub())
        {
            //update string to include stuff about club
        }
    }
}
