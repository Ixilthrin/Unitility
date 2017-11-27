using UnityEngine;
using System.Collections.Generic;

public class SampleMouseInfo : MonoBehaviour
{
    private bool _leftButtonDown;
    private bool _rightButtonDown;
    private List<Rect> _boxes;

    private string _text1;

    // Use this for initialization
    void Start()
    {
        _boxes = new List<Rect>();

        int x = 50;
        int y = 50;
        int width = 100;
        int height = 22;

        _boxes.Add(new Rect(x, y, width, height));
        y += 30;
        width = 250;
        _boxes.Add(new Rect(x, y, width, height));
        y += 30;
        _boxes.Add(new Rect(x, y, width, height));
        y += 30;
        _boxes.Add(new Rect(x, y, width, height));
        _text1 = "Hello World";
        _leftButtonDown = false;
        _rightButtonDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        _leftButtonDown = Input.GetMouseButton(0);
        _rightButtonDown = Input.GetMouseButton(1);
    }

    private void OnGUI()
    {
        GUI.Box(_boxes[0], _text1);
        GUI.Box(_boxes[1], "Mouse Position: " + Input.mousePosition.ToString());
        GUI.Box(_boxes[2], "Left Mouse Down: " + _leftButtonDown);
        GUI.Box(_boxes[3], "Right Mouse Down: " + _rightButtonDown);
    }
}
