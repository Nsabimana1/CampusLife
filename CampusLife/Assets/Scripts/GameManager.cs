using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Persistent elements")]
    public GameObject events;
    public GameObject canvas;
    public static GameManager Instance { get; private set; }

    [Header("UI Elements")]
    public GameObject dialogBox;
    public GameObject dialogText;
    public GameObject nameText;

    public GameObject Resume;
    public GameObject ShowResumeButton;
    public GameObject HideResumeButton;

    public GameObject Choice1;
    public GameObject Choice2;

    public GameObject startButton;
    public GameObject titleText;

    [Header("Backgrounds")]
    public GameObject menubackground;
    public GameObject sltc;
    public GameObject art;
    public GameObject bailey;
    public GameObject caf;
    public GameObject csoffice;
    public GameObject dwr;
    public GameObject ellis;
    public GameObject fausett;
    public GameObject martin;
    public GameObject mcr;
    public GameObject mills;
    public GameObject trieschmann;
    public GameObject wac;

    [Header("Images")]
    public GameObject tourguide;
    public GameObject bearman;
    public GameObject briefcasehead;
    public Image logo;

    [Header("Scene Transition Stuff")]
    public int energy = 4;

    [Header("Text Stuff")]
    public float speed = 0.1f;

    [Header("Music stuff")]
    public GameObject music;

    private Player player;
    private Resume resume;

    private TextMeshProUGUI DialogText;
    private TextMeshProUGUI ResumeText;
    private TextMeshProUGUI NameText;

    private Coroutine dialogCo;

    private bool textTyped;
    private bool textBeTyping;

    private int index = 0;

    private void Awake()
    {
        player = gameObject.AddComponent(typeof(Player)) as Player;
        resume = gameObject.AddComponent(typeof(Resume)) as Resume;
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(events);
            DontDestroyOnLoad(canvas);
            DontDestroyOnLoad(player);
            DontDestroyOnLoad(resume);
            DontDestroyOnLoad(Choice1);
            DontDestroyOnLoad(Choice2);
            DontDestroyOnLoad(music);
            DontDestroyOnLoad(Resume);
            DialogText = dialogText.GetComponent<TextMeshProUGUI>();
            ResumeText = Resume.GetComponentInChildren<TextMeshProUGUI>();
            NameText = nameText.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        Debug.Log(textTyped);
        Debug.Log(textBeTyping);
        Debug.Log(index);
    }

    public void showResume()
    {
        Resume.SetActive(true);
        HideResumeButton.SetActive(true);
        ShowResumeButton.SetActive(false);
        //methods for showing the resume in the UI.
        ResumeText.text = resume.getResume();
    }

    public void hideResume()
    {
        Resume.SetActive(false);
        HideResumeButton.SetActive(false);
        ShowResumeButton.SetActive(true);
    }

    public int getIndex()
    {
        return index;
    }

    public void StartDialog(string[] text)
    {
        if(index >= text.Length)
        {
            index = 0;
        }

        //text will stop and just print out the dialog in this case
        if(!textTyped && textBeTyping)
        {
            dialogBox.SetActive(true);
            //print out entire dialog to dialog box and stop dialog typing
            StopDialog();
            SetDialog(text[index]);
            textTyped = true;
        }
        else if(textTyped && textBeTyping)
        {
            //clear text
            DialogText.text = "";
            //get new text
            index++;
            //start typing
            dialogCo = StartCoroutine(TypeText(text[index]));
            //reset bools properly
            textTyped = false;
        }
        else //if (!textTyped && !textBeTyping)
        {
            dialogBox.SetActive(true);
            DialogText.text = "";
            dialogCo = StartCoroutine(TypeText(text[index]));
            textBeTyping = true;
        }
    }
    public void StopDialog()
    {
        StopCoroutine(dialogCo);
    }
    public void HideDialog()
    {
        dialogBox.SetActive(false);
        StopCoroutine(dialogCo);
        textTyped = false;
    }

    public void SetDialog(string text)
    {
        DialogText.text = text;
    }

    public void SetName(string text)
    {
        NameText.text = text;
    }

    public void SetChoice1Text(string text)
    {
        Choice1.GetComponentInChildren<Text>().text = text;
    }

    public void SetChoice2Text(string text)
    {
        Choice2.GetComponentInChildren<Text>().text = text;
    }

    public void SetDialogTextColor(byte r, byte g, byte b)
    {
        Color32 col = new Color32(r, g, b, 255);
        DialogText.color = col;
        NameText.color = col;
    }

    public void enableChoice()
    {
        Choice1.SetActive(true);
        Choice2.SetActive(true);
    }
    public void disableChoice()
    {
        Choice1.SetActive(false);
        Choice2.SetActive(false);
    }

    public void increaseComp(int competency)
    {
        player.increaseComp(competency);
    }

    IEnumerator TypeText(string text)
    {
        if (DialogText.text == text)
        {
            textTyped = true;
        }
        foreach (char c in text.ToCharArray())
        {
            DialogText.text += c;
            yield return new WaitForSeconds(speed);
        }
    }

    public void startButtonPressed()

    {
        startButton.SetActive(false);
        titleText.SetActive(false);
        logo.enabled = false;

        changeElement(menubackground, sltc);
        dialogBox.SetActive(true);
        dialogText.SetActive(true);
        nameText.SetActive(true);
        tourguide.SetActive(true);
        ShowResumeButton.SetActive(true);
        SetName("Tour Guide");
        SetChoice1Text("Next Stop");
        SetChoice2Text("Next Stop");
        changeScene("sltc");
    }

    public void changeElement(GameObject current, GameObject next)
    {
        current.SetActive(false);
        next.SetActive(true);
    }

    public void changeScene(string toTravel)
    {
        StartCoroutine(LoadYourAsyncScene(toTravel));
    }

    public Player getPlayer()
    {
        return player;
    }


IEnumerator LoadYourAsyncScene(string scene)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

    }

    //public int[] getComp()
    //{
        //throw new System.NotImplementedException();
    //}
}
