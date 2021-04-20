using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool internship = false;
    public bool club = false;
    public int energy = 4;
    private int[] comp = { 0, 0, 0, 0, 0, 0 };
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void increaseComp(int competency)
    {
        this.comp[competency]++;
    }
    public void resetEnergy(int ener)
    {
        this.energy = ener;
    }
    public void useEnergy()
    {
        this.energy--;
    }
    public int[] giveComp()
    {
        return comp;
    }
    public void joinsClub()
    {
        club = true;
    }
    public void hasInternship()
    {
        internship = true;
    }
    public bool getClub()
    {
        return club;
    }
    public bool getInternship()
    {
        return internship;
    }
}
