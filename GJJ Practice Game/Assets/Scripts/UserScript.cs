using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

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

public class UserScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public User userInfo;

    [SerializeField] GameObject userPanel;
    [SerializeField] GameObject profilePanel;
    [SerializeField] GameObject commentBubble;
    [SerializeField] Text commentText;
    [SerializeField] Text nameText;

    private void Start()
    {
        commentText.text = userInfo.comment;
        nameText.text = userInfo.name;
    }

    public void enableProfilePanel()
    {
        profilePanel.SetActive(true);
        ProfilePanel panelInfo = profilePanel.GetComponent<ProfilePanel>();
        panelInfo.NameText = userInfo.name;
        panelInfo.OccupationText = userInfo.occupation;
        panelInfo.CommentText = userInfo.comment;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        commentBubble.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        commentBubble.SetActive(false);
    }
}
