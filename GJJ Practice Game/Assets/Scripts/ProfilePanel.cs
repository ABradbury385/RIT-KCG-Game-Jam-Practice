using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfilePanel : MonoBehaviour
{
    [SerializeField] Text nameText, occupationText, commentText;

    // Properties
    public string NameText
    {
        set { nameText.text = "Name: " + value; }
    }

    public string OccupationText
    {
        set { occupationText.text = "Occupation: " + value; }
    }
    public string CommentText
    {
        set { commentText.text = "Comment: " + value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
