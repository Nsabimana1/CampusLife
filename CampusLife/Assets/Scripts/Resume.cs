using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume : MonoBehaviour
{
    public TextAsset ResumeText;
    private int[] c;
    private string[] ResumeHeaders = new string[] { "Skills:","Experience:"};
    private string[] theResume;
    private string[][] possibleString;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        c = GameManager.Instance.getPlayer().giveComp();
    }
    public void updateResume()
    {
        //function that updates resume based off of the current compentencies in the text.
        //Some things like "Work in group enviornments or created website"
        //Maybe we get different string based on the choices players make.
        for(int i = 0; i < c.Length; i++)
        {
            theResume[i] = possibleString[i][c[i]];
        }
    }

    public void updateIntern()
    {
        //Also check to see if new string is in the string, otherwise we don't update
        if (GameManager.Instance.getPlayer().getInternship() && !inString(6, possibleString[6][1]))
        {
            //update string to include stuff about internship
            theResume[6] = theResume[6].ToString() + " ";
        }
    }
    public void updateClub()
    {
        //Also check to see if new string is in the string, otherwise we don't update
        if (GameManager.Instance.getPlayer().getClub() && !inString(7, possibleString[7][1]))
        {
            //update string to include stuff about club
            theResume[7] = theResume[7].ToString() + " ";
        }
    }
    public bool inString(int index, string s)
    {
        return theResume[index] == s;
    }
    public string getResume()
    {
        string wholeResume = " ";
        for(int i = 0; i < theResume.Length; i++)
        {
            if(i == 0)
            {
                wholeResume = wholeResume + ResumeHeaders[i];
            }
            else if(i == 6)
            {
                wholeResume = wholeResume + ResumeHeaders[2];
            }
            wholeResume = wholeResume + theResume[i];
        }
        return wholeResume;
    }
}
