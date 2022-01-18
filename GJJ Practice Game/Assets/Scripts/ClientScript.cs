using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClientScript : MonoBehaviour
{
    public static ClientScript SharedInstance;
    private LineRenderer line;
    private Material lineMat;
    public Color lineColor;
    public float lineWidth;
    public Transform lineSpawn;
    private Vector3 lineStart;
    public bool selected;

    private void Awake()
    {
        SharedInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        line = gameObject.AddComponent<LineRenderer>();

        lineMat = new Material(Shader.Find("Sprites/Default"));
        lineMat.color = lineColor;
        line.material = lineMat;

        line.startWidth = lineWidth;
        line.endWidth = lineWidth;

        selected = false;

        lineStart = lineSpawn.position;
        lineStart.z = -5;
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = -5;
            Vector3[] positions = new Vector3[] { lineStart, mousePos};
            line.SetPositions(positions);

            //right click to end selection
            if(Input.GetMouseButtonDown(1))
            {
                line.enabled = false;
                selected = false;
            }
        }
    }

    public void SelectUser()
    {
        selected = true;
        line.enabled = true;
    }
}
