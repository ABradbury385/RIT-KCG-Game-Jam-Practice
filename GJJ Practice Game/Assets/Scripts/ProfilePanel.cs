using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfilePanel : MonoBehaviour
{
    // Variables
    [SerializeField] Text nameText, occupationText, commentText, contact1Text, contact2Text, contact3Text,
        contact1Name, contact2Name, contact3Name;
    [SerializeField] GameObject contact1Panel, contact2Panel, contact3Panel;
    [SerializeField] GameObject contact1Button, contact2Button, contact3Button;
    [SerializeField] List<GameObject> contactPanels;

    // Properties
    public string NameText
    {
        set { nameText.text = value; }
    }
    public string CommentText
    {
        set { commentText.text = value; }
    }
    public string Contact1Text
    {
        set 
        { 
            contact1Text.text = value;
            contact1Button.SetActive(true);
        }
    }
    public string Contact2Text
    {
        set 
        { 
            contact2Text.text = value;
            contact2Button.SetActive(true);
        }
    }
    public string Contact3Text
    {
        set 
        {
            contact3Text.text = value;
            contact3Button.SetActive(true);
        }
    }
    public string Contact1Name
    {
        set
        {
            contact1Name.text = value;
        }
    }
    public string Contact2Name
    {
        set
        {
            contact2Name.text = value;
        }
    }
    public string Contact3Name
    {
        set
        {
            contact3Name.text = value;
        }
    }
    public GameObject Contact1Panel
    {
        set
        {
            contact1Panel = value;
        }
    }
    public GameObject Contact2Panel
    {
        set
        {
            contact2Panel = value;
        }
    }
    public GameObject Contact3Panel
    {
        set
        {
            contact3Panel = value;
        }
    }

    // Functions

    // Enables the contact panel of the person clicked
    public void EnableContactPanel(int _contactNumber)
    {
        switch (_contactNumber)
        {
            case 1:
                GameManager.SharedInstance.CurrentConnectionsPanel.SetActive(false);
                GameManager.SharedInstance.CurrentConnectionsPanel = contact1Panel;
                contact1Panel.SetActive(true);
                break;
            case 2:
                GameManager.SharedInstance.CurrentConnectionsPanel.SetActive(false);
                GameManager.SharedInstance.CurrentConnectionsPanel = contact2Panel;
                contact2Panel.SetActive(true);
                break;
            case 3:
                GameManager.SharedInstance.CurrentConnectionsPanel.SetActive(false);
                GameManager.SharedInstance.CurrentConnectionsPanel = contact3Panel;
                contact3Panel.SetActive(true);
                break;
        }

        GameManager.SharedInstance.Clicks++;
        gameObject.SetActive(false);
    }

    // Disable contacts by default
    private void OnEnable()
    {
        foreach(GameObject panel in contactPanels)
        {
            panel.SetActive(false);
        }
    }
}
