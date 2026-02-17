using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColliderCollisionCheckScript : MonoBehaviour, IDragHandler
{
    //private void Start()
    //{
    //    Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
    //    rb.useFullKinematicContacts = true;
    //}
    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("Collision detected.");
        BlastAwayTheTrash();
        Console.WriteLine($"Name of Object colliding is:- {other.transform.parent.gameObject.name}");
        StartCoroutine(DestroyAfterTime(other.transform.parent.gameObject));
    }
    void BlastAwayTheTrash()
    {
        Animator BlastAwayMUAHAHAHA = gameObject.GetComponent<Animator>();

        BlastAwayMUAHAHAHA.SetTrigger("PlasmaBlast");
    }

    IEnumerator DestroyAfterTime(GameObject gameobject)
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameobject);
    }

    public void OnDrag(PointerEventData eventData)
    {        
        Debug.Log("On Drag called on toothless.");                  
    }
}



