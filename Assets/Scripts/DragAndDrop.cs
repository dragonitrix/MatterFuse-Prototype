using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    public Matter parent;

    private void OnMouseDown()
    {
        isDragging = true;
    }
    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void Start()
    {
    }

    private void Update()
    {
        if(isDragging)
        {
            var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = 0;
            parent.SetPosition(worldPos);
        }
    }
}
