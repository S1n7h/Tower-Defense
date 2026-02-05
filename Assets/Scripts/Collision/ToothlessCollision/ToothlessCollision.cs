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
    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("Collision detected.");
        BlastAwayTheTrash();
        StartCoroutine(DestroyAfterTime(col.gameObject));
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



