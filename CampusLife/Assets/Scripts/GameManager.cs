using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject events;
    public GameObject canvas;
    public static GameManager Instance { get; private set; }

    public GameObject dialogBox;
    public GameObject dialogText;

    private Coroutine dialogCo;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(events);
            DontDestroyOnLoad(canvas);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
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
