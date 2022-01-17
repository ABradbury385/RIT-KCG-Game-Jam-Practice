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
    [SerializeField] private Text clientCommentText, clicksText, timerText;
    [SerializeField] private GameObject clientPicture;
    private Image clientSprite;

    private float levelTimer;
    [SerializeField]
    private bool paused;
    private int clicks;
    private int levelNumber;
    private bool victory;
    private Stack<string> connectionLayer;  //string for now, will change to UI panels
    [SerializeField]
    private Level[] levels;    //temp string, will be level info

    // Start is called before the first frame update
    void Start()
    {
        connectionLayer = new Stack<string>();
        connectionLayer.Push("Base layer");
        levelTimer = 0.0f;
        paused = false;
        clicks = 0;
        levelNumber = 0;
        victory = false;
        //display index 0 of levels

        clientCommentText.text = "\"" + levels[levelNumber].clientRequest + "\"";
        clientSprite = clientPicture.GetComponent<Image>();

        LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {
        //only run timer if level is running
        if (!paused)
        {
            levelTimer += Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
            //will need to check if clicked item is a user icon
            Debug.Log("Click detected");
            clicks++;
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
