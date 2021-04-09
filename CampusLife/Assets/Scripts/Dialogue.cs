using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public TextAsset allText;

    public GameObject dialogBox;
    public GameObject dialogText;

    private Coroutine dialogCo;
    private int i = 0;

    private string text;
    private string[] Dialog;

    // Start is called before the first frame update
    void Start()
    {
        text = allText.ToString();
        Dialog = text.Split('*');
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

    public void Speak()
    {
        StartDialog(Dialog[i]);
        i++;
    }

    //Method to start dialog
    public void StartDialog(string text)
    {
        dialogBox.SetActive(true);
        dialogCo = StartCoroutine(TypeText(text));
    }
    public void HideDialog()
    {
        dialogBox.SetActive(false);
        StopCoroutine(dialogCo);
    }

    IEnumerator TypeText(string text)
    {
        dialogText.GetComponent<TextMeshProUGUI>().text = "";
        foreach (char c in text.ToCharArray())
        {
            dialogText.GetComponent<TextMeshProUGUI>().text += c;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
