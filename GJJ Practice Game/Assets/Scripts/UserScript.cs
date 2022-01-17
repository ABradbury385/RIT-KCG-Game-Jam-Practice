using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class User
{
    public string name;
    public string occupation;
    [TextArea(5,10)]
    public string comment;
    public User[] connections;
    //UI panel to fill up
    public Sprite profilePic;
}

public class UserScript : MonoBehaviour
{
    public User userInfo;

    [SerializeField] GameObject userPanel;
    [SerializeField] GameObject profilePanel;

    public void enableProfilePanel()
    {
        profilePanel.SetActive(true);
        ProfilePanel panelInfo = profilePanel.GetComponent<ProfilePanel>();
        panelInfo.NameText = userInfo.name;
        panelInfo.OccupationText = userInfo.occupation;
        panelInfo.CommentText = userInfo.comment;
    }
}
