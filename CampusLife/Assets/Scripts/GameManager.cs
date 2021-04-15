using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject events;
    public GameObject canvas;
    public static GameManager Instance { get; private set; }

    public GameObject dialogBox;
    public GameObject dialogText;

    public GameObject Choice1;
    public GameObject Choice2;

    public GameObject startButton;
    public GameObject titleText;

    public Player player;

    public GameObject music;

    private Coroutine dialogCo;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
            //DontDestroyOnLoad(events);
            //DontDestroyOnLoad(canvas);
            //DontDestroyOnLoad(player);
            //DontDestroyOnLoad(Choice1);
            //DontDestroyOnLoad(Choice2);
            DontDestroyOnLoad(music);
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
        if (dialogCo != null)
        {
            HideDialog();
        }
        dialogBox.SetActive(true);
        dialogCo = StartCoroutine(TypeText(text));
    }
    public void StopDialog()
    {
        StopCoroutine(dialogCo);
    }
    public void HideDialog()
    {
        dialogBox.SetActive(false);
        StopCoroutine(dialogCo);
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
        dialogText.GetComponent<TextMeshProUGUI>().text = "";
        foreach (char c in text.ToCharArray())
        {
            dialogText.GetComponent<TextMeshProUGUI>().text += c;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void startButtonPressed()
    {
        startButton.SetActive(false);
        titleText.SetActive(false);
        changeScene("sltc");
    }

    public void changeScene(string toTravel)
    {
        StartCoroutine(LoadYourAsyncScene(toTravel));
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

}
