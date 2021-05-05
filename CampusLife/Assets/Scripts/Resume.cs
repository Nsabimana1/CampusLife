using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class Resume : MonoBehaviour
{
    public TextAsset ResumeText;
    //We store the competencies the player has
    private int[] c;
    //headers for the resume
    private string[] ResumeHeaders = new string[] { "Skills:","Experience:"};
    //array representing the resume, might change to a list
    List<string> theResume = new List<string>();
    // a huge array of all possible string. First [] is competencies, second [] is the level of competency
    private string[][] possibleString;

    private List<string> competances = new List<string>();
    private List<string> skills = new List<string>();
    private List<string> experiences = new List<string>();

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
            //theResume[i] = possibleString[i][c[i]];
        }
    }

    public void updateIntern()
    {
        //Also check to see if new string is in the string, otherwise we don't update
        if (GameManager.Instance.getPlayer().getInternship() && !inString(6, possibleString[6][1]))
        {
            //update string to include stuff about internship
            //theResume[6] = theResume[6].ToString() + " ";
        }
    }
    public void updateClub()
    {
        //Also check to see if new string is in the string, otherwise we don't update
        if (GameManager.Instance.getPlayer().getClub() && !inString(7, possibleString[7][1]))
        {
            //update string to include stuff about club
            //theResume[7] = theResume[7].ToString() + " ";
        }
    }
    public bool inString(int index, string s)
    {
        return true; //theResume[index] == s;
    }
    public string getResume()
    {
        string wholeResume = " ";
        if (theResume.Count != 0)
        {
            for (int i = 0; i < theResume.Count; i++)
            {
                if (i == 0)
                {
                    wholeResume = wholeResume + ResumeHeaders[0] + "\n";
                }
                else if (i == 6)
                {
                    wholeResume = wholeResume + ResumeHeaders[1] + "\n";
                }
                wholeResume = wholeResume + theResume[i] + "\n";
            }
        }
        else
        {
            for (int i = 0; i < 7; i++)
            {
                if (i == 0)
                {
                    wholeResume = wholeResume + ResumeHeaders[0] + "\n";
                }
                else if (i == 6)
                {
                    wholeResume = wholeResume + ResumeHeaders[1] + "\n";
                    continue;
                }
                else if (i % 2 == 0)
                {
                    wholeResume = wholeResume + "\n";
                }
            }
        }
        return wholeResume;
    }

    public void addCareerCompentance(string competance)
    {
        if (!this.competances.Contains(competance))
        {
            this.competances.Add(competance);
        }
    }
    public void addSkill(string skill) 
    {
        if (!this.skills.Contains(skill))
        {
            this.skills.Add(skill);
        }
    }

    public void addExperience(string experience) 
    {
        if (!this.skills.Contains(experience))
        {
            this.skills.Add(experience);
        }
    }

    public string constructResume()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("      ");
        sb.Append("\n");
        sb.Append("Career Competencies:");
        sb.Append("\n");
        this.competances.ForEach(s => sb.Append(" - " + s + "\n"));
        sb.Append("      ");
        sb.Append("\n");
        sb.Append("Experiences:");
        sb.Append("\n");
        this.skills.ForEach(s => sb.Append(" - " + s + "\n"));
        sb.Append("      ");
        sb.Append("\n");
        //sb.Append("Experiences:");
        //sb.Append("\n");
        //this.experiences.ForEach(s => sb.Append(" - " + s + "\n"));
        return sb.ToString();
    }
}
