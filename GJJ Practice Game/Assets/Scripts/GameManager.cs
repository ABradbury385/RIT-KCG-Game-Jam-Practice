using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Level
{
    public string name;
    public string correctName;
    public Sprite clientPicture;
    [TextArea(3,5)]
    public string clientRequest;
    //level UI panel
    public string baseLayer;    //first layer to display
}

public class GameManager : MonoBehaviour
{
    public static GameManager SharedInstance;

    [SerializeField] private Text clientCommentText, clicksText, timerText, successText;
    [SerializeField] private GameObject clientPicture, currentConnectionsPanel,
        gameScreen, endScreen, successScreen, failureScreen;
    private Image clientSprite;

    private float levelTimer;
    [SerializeField]
    private bool paused;
    private int clicks;
    private int levelNumber;
    [SerializeField]
    private bool gameOver;
    [SerializeField]
    private bool victory;
    private Stack<string> connectionLayer;  //string for now, will change to UI panels
    [SerializeField]
    private Level[] levels;    //temp string, will be level info


    // Properties
    public GameObject CurrentConnectionsPanel
    {
        get { return currentConnectionsPanel; }
        set { currentConnectionsPanel = value; }
    }

    public int Clicks { get { return clicks; } set { clicks = value; } }

    public bool GameOver { get { return gameOver; } set { gameOver = value; } }

    public bool Victory { get { return victory; } set { victory = value; } }

    public string CorrectName { get { return levels[levelNumber].correctName; } }

    private void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

        connectionLayer = new Stack<string>();
        connectionLayer.Push("Base layer");
        levelTimer = 0.0f;
        paused = false;
        clicks = 0;
        levelNumber = 0;
        victory = false;
        gameOver = false;
        //display index 0 of levels

        clientCommentText.text = "\"" + levels[levelNumber].clientRequest + "\"";
        clientSprite = clientPicture.GetComponent<Image>();

        LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the game has ended and displays the results
        if(gameOver)
        {
            paused = true;
            gameScreen.SetActive(false);
            endScreen.SetActive(true);

            if(victory)
            {
                successScreen.SetActive(true);
                successText.text = "You connected the right people in " + clicks + "  clicks and " + Mathf.RoundToInt(levelTimer) + " seconds!";
            }
            else
            {
                failureScreen.SetActive(true);
            }
        }

        //only run timer if level is running
        if (!paused)
        {
            levelTimer += Time.deltaTime;
        }

        // Update Level Info textboxes
        clicksText.text = "Clicks: " + clicks.ToString();
        timerText.text = "Time: " + Mathf.RoundToInt(levelTimer);

    }

    /// <summary>
    /// Resets values of the level
    /// </summary>
    void ResetLevel()
    {
        levelTimer = 0;
        paused = true;
        clicks = 0;
        victory = false;
        while (connectionLayer.Count > 1)
        {
            connectionLayer.Pop();
        }
    }

    void NextLevel()
    {
        ResetLevel();
        if(levelNumber >= levels.Length - 1)
        {
            Debug.Log("Ran out of levels");
            return;
        }

        //next level, clear and repopulate connection layer
        levelNumber++;
        connectionLayer.Pop();
        connectionLayer.Push(levels[levelNumber].baseLayer);
        //display level at index levelNumber
    }

    void LoadLevel()
    {
        clientSprite.sprite = levels[levelNumber].clientPicture;
    }

}
