using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class mouseScript : MonoBehaviour
{
    Ray ray;
    [SerializeField] string UIDeploymentLayer;
    [SerializeField] SpriteRenderer spriteToRender;
    //[SerializeField] spriteRender spriterender;
    bool mouseButtonWasDown;
    [SerializeField] GameObject dropletObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouse_pos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
        ray = Camera.main.ScreenPointToRay(Mouse.current.position.value);
        LayerMask layer = LayerMask.GetMask(UIDeploymentLayer);
        RaycastHit2D hit = Physics2D.GetRayIntersection(ray, 10.0f, layer);

        
        if (!Mouse.current.leftButton.isPressed)
        {
            //erasing sprite
            if (spriteToRender.sprite != null)
            {
                spawn(mouse_pos);
                spriteToRender.sprite = null;
            }
        }
        else
        {
            //rendering sprite when mouse button is pressed
            if (hit)
            {
                CheckForColliders(hit);
                //spriteToRender.sprite = spriterender.sprite;
            }
            //managing position of sprite renderer
            if (spriteToRender.sprite)
            {
                spriteToRender.transform.position = mouse_pos;
            }
        }
    }
    void CheckForColliders(RaycastHit2D hit)
    {
        Debug.Log("Hit object with tag: " + hit.collider.tag);
    }
    void spawn(Vector3 mouse_pos)
    {
        GameObject tempDroplet = Instantiate(dropletObject, mouse_pos, dropletObject.transform.rotation);
        tempDroplet.SetActive(true);
        Animator anim_temp = tempDroplet.GetComponent<Animator> ();
        anim_temp.enabled = true;
    }
}
