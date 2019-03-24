using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionBox : MonoBehaviour
{

    [SerializeField] GameObject selectionIndicator;
    [SerializeField] Camera cam;
    int selectButton = 0;

    Vector2 startSelectPos,
            mouseWorldPos;
    Vector3 topLeft;

    [SerializeField] public float gridSize;

    private void OnGUI()
    {
        //Get the mouse position in world space
        Event currentEvent = Event.current;
        Vector3 currentMousePos = new Vector2(
            currentEvent.mousePosition.x,
            cam.pixelHeight - currentEvent.mousePosition.y); //y position is inverted.

        mouseWorldPos = cam.ScreenToWorldPoint(new Vector3(
            currentMousePos.x, 
            currentMousePos.y,
            -cam.transform.position.z));

        topLeft = selectionIndicator.transform.position - (selectionIndicator.transform.localScale /2);
    }

    private void Update()
    {

        if (Input.GetMouseButton(selectButton))
        {
            if (Input.GetMouseButtonDown(selectButton))
            {
                startSelectPos = new Vector3(Mathf.Round(mouseWorldPos.x), Mathf.Round(mouseWorldPos.y)); //round to an interger
                selectionIndicator.transform.position = startSelectPos;
                selectionIndicator.transform.localScale = new Vector3(1, 1, 1);
            }

            //round to grid, and always be under the mouse
            float dragPosX, dragPosY;
            if (mouseWorldPos.x > startSelectPos.x)
                { dragPosX = Mathf.Ceil(mouseWorldPos.x); Debug.Log("1"); } else
                { dragPosX = Mathf.Floor(mouseWorldPos.x); Debug.Log("2"); }
            if (mouseWorldPos.y > startSelectPos.y)
                { dragPosY = Mathf.Ceil(mouseWorldPos.y); Debug.Log("8"); } else
                { dragPosY = Mathf.Floor(mouseWorldPos.y); Debug.Log("9"); }
            Vector3 dragPosition = new Vector3(dragPosX, Mathf.Ceil(mouseWorldPos.y));

            //move cube to where you clicked
            selectionIndicator.transform.position = startSelectPos;

            //Vector3 distance = dragPosition - topLeft;
            //selectionIndicator.transform.localScale = new Vector3(distance.x, distance.y, 1) ;
            //selectionIndicator.transform.position += selectionIndicator.transform.localScale / 2;
        }

    }
}
