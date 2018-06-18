using UnityEngine;
using System.Collections;

public class GrabAndMove : MonoBehaviour {

    private Vector3 initialMousePosition;
    private Vector3 initialObjectPosition;
    private Vector3 previousMousePosition;
    private bool isSelected = false;
    private float depthFactor;
    private Vector3 selectionOffset;

    void Start ()
    {
	}
	
	void Update ()
    {
        if (CheckForSelection())
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
                depthFactor += .1f;
            else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
                depthFactor -= .1f;

            var currentMousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.3f);
            
            var currentMousePosition3d = Camera.main.ScreenToWorldPoint(currentMousePosition);
            var initialMousePosition3d = Camera.main.ScreenToWorldPoint(initialMousePosition);
            var direction = currentMousePosition3d - initialMousePosition3d;

            var movementRay = new Ray(transform.position, direction);
            var currentMouseRay = Camera.main.ScreenPointToRay(currentMousePosition);

            var distance = Vector3.Distance(initialMousePosition3d, initialObjectPosition - selectionOffset);
            distance *= 1.0f + depthFactor;

            var targetPoint = currentMouseRay.GetPoint(distance);
            
            transform.position = targetPoint + selectionOffset;

            previousMousePosition = currentMousePosition;
        }
    }

    private bool CheckForSelection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initialMousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.3f);
            previousMousePosition = initialMousePosition;

            var rayCastInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(initialMousePosition), out rayCastInfo);
            if (hit)
            {
                if (rayCastInfo.transform.gameObject == gameObject)
                {
                    initialObjectPosition = transform.position;
                    selectionOffset = transform.position - rayCastInfo.point;
                    isSelected = true;
                }
            }
            else
            {
                isSelected = false;
                depthFactor = 0f;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isSelected = false;
            depthFactor = 0f;
        }
        
        return isSelected;
    }
}
