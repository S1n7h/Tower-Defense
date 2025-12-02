using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UnitRelocatorScript : MonoBehaviour, IDragHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector3 mouse_pos;

    // Update is called once per frame
    void Update()
    {
        mouse_pos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
    }

    public void OnClick()
    {

        Debug.Log("Object was clicked.");
    }

    public void OnDrag(PointerEventData eventData)
    {
        gameObject.transform.position = new Vector3(mouse_pos.x, mouse_pos.y, 0);
        Debug.Log("Object is being dragged.");
    }
}
