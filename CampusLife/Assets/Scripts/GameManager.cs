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

    public GameObject dialogBox;
    public GameObject dialogText;
    public GameObject nameText;

    public GameObject Resume;

    public GameObject Choice1;
    public GameObject Choice2;

    public Image background;
    public GameObject character;
    public Image logo;

    public GameObject startButton;
    public GameObject titleText;

    private Player player;
    private Resume resume;

    [Header("Scene Transition Stuff")]
    public int energy = 4;

    [Header("Text Stuff")]
    public float speed = 0.1f;

    [Header("Music stuff")]
    public GameObject music;

    private TextMeshProUGUI DialogText;
    private Coroutine dialogCo;
    private bool textTyped;
    private bool textBeTyping;

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

    public void showResume()
    {
        Resume.SetActive(true);
        //methods for showing the sresume in the UI.
    }
    public void StartDialog(string text)
    {
        if (dialogCo != null)
        {
            HideDialog();
        }
        
        if(!textTyped && textBeTyping)
        {
            //print out entire dialog to dialog box and stop dialog typing
            StopDialog();
            SetDialog(text);
        }
        else if(textTyped && textBeTyping)
        {
            //methods for updating current dialog
        }
        else if (!textTyped && !textBeTyping)
        {
            dialogBox.SetActive(true);
            dialogCo = StartCoroutine(TypeText(text));
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

    public void enableChar()
    {
        //character.setActive(true);
    }

    public void disableChar()
    {
        //character.setActive(false);
    }

    public void increaseComp(int competency)
    {
        player.increaseComp(competency);
    }

    IEnumerator TypeText(string text)
    {
        DialogText.text = "";
        foreach (char c in text.ToCharArray())
        {
            DialogText.text += c;
            yield return new WaitForSeconds(speed);
        }
        if(DialogText.text == text)
        {
            textTyped = true;
        }
    }

    public void startButtonPressed()

    {
        startButton.SetActive(false);
        titleText.SetActive(false);
        logo.enabled = false;

        dialogBox.SetActive(true);
        dialogText.SetActive(true);
        nameText.SetActive(true);
        character.SetActive(true);
        changeBackground("sltc");
    }

    public void changeBackground(string text)
    {
        background.sprite = Resources.Load("Assets/Sprites/Backgrounds/" + text + "8.png") as Sprite;
    }

    public void changeCharacter(string text)
    {
        //character.sprite = Resources.Load("Assets/Sprites/Characters/" + text) as Sprite;
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
