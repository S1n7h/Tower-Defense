using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class UnitRelocatorScript : MonoBehaviour, IDragHandler, IPointerClickHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector3 mouse_pos;
    private Collider2D _collider;
    private bool _dragCheck = false;
    [SerializeField] private SpriteRenderer unitRangeRenderer;
    private bool _rangeRenderCheck = false;
    void Start()
    {
        unitRangeRenderer.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        // Debug.Log("Hi.");
        mouse_pos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
    }

    public void OnMouseDown()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        _dragCheck = true;
        Debug.Log(_dragCheck);
        // Debug.Log(eventData.pointerDrag);
        Debug.Log($"{mouse_pos.z}");
        if(eventData.hovered[0].tag == this.tag)     
            eventData.hovered[0].transform.position = new Vector3(mouse_pos.x, mouse_pos.y, 0);
        // Debug.Log("Object is being dragged."); 
        Debug.Log($"{eventData.hovered[0]}");                   
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_dragCheck)
        {
            _dragCheck = false;
            return;
        }
        if (!_rangeRenderCheck)
        {
            _rangeRenderCheck = true;
            unitRangeRenderer.enabled = true;
        }else {
            _rangeRenderCheck = false;
            unitRangeRenderer.enabled = false;
        }
        Debug.Log("Object was clicked.");
    }
}
