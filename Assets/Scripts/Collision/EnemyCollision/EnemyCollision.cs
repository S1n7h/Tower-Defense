using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] string DuckTag;
    private List<GameObject> EnemyList;
    public readonly List<GameObject> PublicEnemyList = new List<GameObject>();

    private void Start()
    {
        EnemyList = new List<GameObject>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == DuckTag) Debug.Log("Duck was detected.");
        EnemyList.Add(collision.gameObject);
        PublicEnemyList.Add(collision.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        EnemyList.RemoveAt(0);
        PublicEnemyList.RemoveAt(0);
    }
}

//if trigger triggered
   //set target to whatever object triggered the trigger
   //spawn bullet
//on exit trigger
    //
  
