using System;
using System.Collections;
using UnityEngine;

public class ColliderCollisionCheckScript : MonoBehaviour
{
    private void Start()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.useFullKinematicContacts = true;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Collision detected.");
        BlastAwayTheTrash();
        StartCoroutine(DestroyAfterTime(col));
    }
    void BlastAwayTheTrash()
    {
        Animator BlastAwayMUAHAHAHA = gameObject.GetComponent<Animator>();

        BlastAwayMUAHAHAHA.SetTrigger("PlasmaBlast");
    }

    IEnumerator DestroyAfterTime(Collision2D col)
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(col.gameObject);
    }
}



