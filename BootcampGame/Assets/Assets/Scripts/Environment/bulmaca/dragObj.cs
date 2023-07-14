using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class dragObj : MonoBehaviour
{
    public bool dragging = false,done = false;
    private float startPosX;
    private float startPosY;

   [SerializeField] private Canvas canvas;


    public void DragHandler(BaseEventData data)
    {
        PointerEventData pointerDate = (PointerEventData)data;
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            (RectTransform)canvas.transform,
            pointerDate.position,
            canvas.worldCamera,
            out position);
        transform.position = canvas.transform.TransformPoint(position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == this.gameObject.name)
        {
            done = true;
        }
        else
        {
            done = false;
        }
    }

}
