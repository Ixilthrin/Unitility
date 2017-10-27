using UnityEngine;
using System.Collections;

public class ShowSomeText : MonoBehaviour
{
    private const int LINE_HEIGHT = 25;

    private int _lineNumber = 1;

    private string _textInput = "";

    private string _message = "";

    private int boxX = 0;

    void OnGUI()
    {
        int frameCount = Time.frameCount;
        float timeSinceStartup = Time.realtimeSinceStartup;

        _lineNumber = 1;

        GUI.Label(new Rect(10, GetNextLinePosition(), 100, 20), frameCount.ToString());
        GUI.Label(new Rect(10, GetNextLinePosition(), 100, 20), timeSinceStartup.ToString());

        float frameRate = (float)frameCount / timeSinceStartup;

        GUI.Label(new Rect(10, GetNextLinePosition(), 100, 20), frameRate.ToString());

        _textInput = GUI.TextField(new Rect(10, GetNextLinePosition(), 100, 20), _textInput);

        CreateTheMessage();

        GUI.Label(new Rect(100, 300, 100, 20), _message);
        
    }

    void CreateTheMessage()
    {
        if (_textInput == "David")
        {
            _message = "Idiot!!!";
        }
        else if (_textInput == "Evan")
        {
            _message = "You are cool!";
        }
        else
        {
            _message = "";
        }
    }

    int GetNextLinePosition()
    {
        _lineNumber++;
        return _lineNumber * LINE_HEIGHT + 30;
    }

    // Use this for initialization
    void Start () { }
	
    // Update is called once per frame
    void Update () { }
}
