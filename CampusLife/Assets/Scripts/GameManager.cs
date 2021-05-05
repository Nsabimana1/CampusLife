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
    public GameObject backButton;
    public GameObject helpButton;
    public GameObject helpDialogBox;
    public GameObject creditButton;
    public GameObject creditDialogBox;
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
    public GameObject careerfair;
    public GameObject volunteer;
    public GameObject hirehendrix;
    public GameObject csmeeting;
    public GameObject careerterm;

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

    public bool choiceMake = false;

    private int index = 0;

    private string toScene;
    private string otherScene;
    private string choice1text;
    private string choice2text;
    private string other1text;
    private string other2text;
    private string character;
    private string othercharacter;

    private string curDialog = "";

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
        //Debug.Log(textTyped);
        //Debug.Log(textBeTyping);
        Debug.Log(index);
    }

    private void FixedUpdate()
    {
        if (dialogText.GetComponent<TextMeshProUGUI>().text == curDialog)
        {
            //Debug.Log("TextTyped should be true");
            textTyped = true;
        }
    }

    public void showResume()
    {
        Resume.SetActive(true);
        HideResumeButton.SetActive(true);
        ShowResumeButton.SetActive(false);
        //methods for showing the resume in the UI.
        //ResumeText.text = resume.getResume();
        ResumeText.text = resume.constructResume();

    }

    public GameObject getButton1()
    {
        return Choice1;
    }
    public GameObject getButton2()
    {
        return Choice2;
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
    public void setIndex(int val)
    {
        index = val;
    }

    public void StartDialog(string[] text)
    {
        if(dialogCo != null)
        {
            StopDialog();
        }
        //text will stop and just print out the dialog in this case
        if (!textTyped && textBeTyping)
        {
            dialogBox.SetActive(true);
            //print out entire dialog to dialog box and stop dialog typing
            SetDialog(text[index]);
            textTyped = true;
        }
        else if(textTyped && textBeTyping)
        {
            //clear text
            DialogText.text = "";
            //Get new text
            index++;
            //start typing
            dialogCo = StartCoroutine(TypeText(text[index]));
            curDialog = text[index];
            //reset bools properly
            textTyped = false;
        }
        else //if (textTyped && !textBeTyping)
        {
            index = 0;
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
        foreach (char c in text.ToCharArray())
        {
            DialogText.text += c;
            yield return new WaitForSeconds(speed);
        }
    }

    public void startButtonPressed()

    {
        startButton.SetActive(false);
        creditButton.SetActive(false);
        helpButton.SetActive(false);
        backButton.SetActive(false);
        titleText.SetActive(false);
        logo.enabled = false;

        changeElement(menubackground, sltc);
        dialogBox.SetActive(true);
        dialogText.SetActive(true);
        nameText.SetActive(true);
        tourguide.SetActive(true);
        ShowResumeButton.SetActive(true);
        SetName("Tour Guide");
        SetChoice1Text("Take tour");
        SetChoice2Text("Skip tour");
        changeScene("sltc");
    }

    public void creditButtonPressed()
    {
        creditDialogBox.SetActive(true);
        helpButton.SetActive(false);
        backButton.SetActive(true);
    }

    public void helpButtonPressed()
    {
        helpDialogBox.SetActive(true);
        backButton.SetActive(true);
    }

    public void backButtonPressed()
    {
        backButton.SetActive(false);
        creditButton.SetActive(true);
        creditDialogBox.SetActive(false);
        helpButton.SetActive(true);
        helpDialogBox.SetActive(false);
    }

    public void setChoices(string nextScene, string secondScene, string c1, string c2, string o1, string o2, string ch, string och)
    {
        toScene = nextScene;
        otherScene = secondScene;
        choice1text = c1;
        choice2text = c2;
        other1text = o1;
        other2text = o2;
        character = ch;
        othercharacter = och;
    }

    public void updateComp(string comp)
    {
        if (comp != null)
        {
            resume.addExperience(comp);
        }
    }

    public void resetButtons()
    {

    }

    public void choice1Pressed()
    {
        index = 0;
        changeScene(toScene);
        SetChoice1Text(choice1text);
        SetChoice2Text(choice2text);
        changeBackground(toScene);
        disableChoice();
        changeCharacter(character);
        textTyped = false;
        textBeTyping = false;
    }

    public void choice2Pressed()
    {
        index = 0;
        changeScene(otherScene);
        SetChoice1Text(other1text);
        SetChoice2Text(other2text);
        changeBackground(otherScene);
        disableChoice();
        changeCharacter(othercharacter);
        textTyped = false;
        textBeTyping = false;
    }

    public void changeCharacter(string s)
    {
        disableAllChar();
        if (s == "tourguide")
        {
            tourguide.SetActive(true);
            SetName("Tour Guide");
            //SetDialogTextColor(245, 130, 42)
        }
        else if (s == "bearman")
        {
            bearman.SetActive(true);
            SetName("Career Services Rep");
            //SetDialogTextColor(245, 130, 42)
        }
        else if (s == "briefcasehead")
        {
            briefcasehead.SetActive(true);
            SetName("Employer");
            //SetDialogTextColor(245, 130, 42)
        }
    }

    public void disableAllChar()
    {
        tourguide.SetActive(false);
        bearman.SetActive(false);
        briefcasehead.SetActive(false);
    }

    public void changeBackground(string s)
    {
        disableAllBackgrounds();
        if (s == "sltc")
        {
            sltc.SetActive(true);
        }
        else if (s == "art")
        {
            art.SetActive(true);
        }
        else if (s == "bailey")
        {
            bailey.SetActive(true);
        }
        else if (s == "caf")
        {
            caf.SetActive(true);
        }
        else if (s == "csoffice")
        {
            csoffice.SetActive(true);
        }
        else if (s == "dwr")
        {
            dwr.SetActive(true);
        }
        else if (s == "ellis")
        {
            ellis.SetActive(true);
        }
        else if (s == "fausett")
        {
            fausett.SetActive(true);
        }
        else if (s == "martin")
        {
            martin.SetActive(true);
        }
        else if (s == "mcr")
        {
            mcr.SetActive(true);
        }
        else if (s == "mills")
        {
            mills.SetActive(true);
        }
        else if (s == "trieschmann")
        {
            trieschmann.SetActive(true);
        }
        else if (s == "wac")
        {
            wac.SetActive(true);
        }
        else if (s == "careerfair")
        {
            careerfair.SetActive(true);
        }
        else if (s == "volunteer")
        {
            volunteer.SetActive(true);
        }
        else if (s == "hirehendrix")
        {
            hirehendrix.SetActive(true);
        }
        else if (s == "csmeeting")
        {
            csmeeting.SetActive(true);
        }
        else if (s == "careerterm")
        {
            careerterm.SetActive(true);
        }

        else
        {
            menubackground.SetActive(true);
        }
    }

    public void disableAllBackgrounds()
    {
        menubackground.SetActive(false);
        sltc.SetActive(false);
        art.SetActive(false);
        bailey.SetActive(false);
        caf.SetActive(false);
        csoffice.SetActive(false);
        dwr.SetActive(false);
        ellis.SetActive(false);
        fausett.SetActive(false);
        martin.SetActive(false);
        mcr.SetActive(false);
        mills.SetActive(false);
        trieschmann.SetActive(false);
        wac.SetActive(false);
        careerfair.SetActive(false);
        volunteer.SetActive(false);
        csmeeting.SetActive(false);
        hirehendrix.SetActive(false);
        careerterm.SetActive(false);
    }

    public void changeElement(GameObject current, GameObject next)
    {
        current.SetActive(false);
        next.SetActive(true);
    }

    public void changeScene(string toTravel)
    {
        Debug.Log(toTravel);
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
