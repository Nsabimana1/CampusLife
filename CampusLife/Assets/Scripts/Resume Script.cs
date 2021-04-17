using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeScript : MonoBehaviour
{
    public TextAsset ResumeText;
    private int[] c;
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
}
