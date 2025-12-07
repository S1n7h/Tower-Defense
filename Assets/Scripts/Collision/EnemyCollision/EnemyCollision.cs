using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] string DuckTag;
    private List<Transform> EnemyList;
    [SerializeField] Bullet bullet;
    [SerializeField] float ReloadTime;
    [SerializeField] float Damage;
    [SerializeField] float BulletSpeed;
    [SerializeField] float BlastRadius;
    private float _reloadTime = 0.0f;
    private void Start()
    {
        EnemyList = new List<Transform>();
    }
    private void Update()
    {
        if (_reloadTime >= ReloadTime && EnemyList.Count != 0)
        {
            Bullet Tempbullet = Instantiate(bullet, this.transform.position, Quaternion.identity);
            Tempbullet.Initialise(EnemyList[0], Damage, BulletSpeed, BlastRadius);
            _reloadTime = 0.0f;
        }
        _reloadTime += Time.deltaTime;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == DuckTag)
        {
            Debug.Log("Duck was detected.");
            EnemyList.Add(collision.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        EnemyList.RemoveAt(0);
    }
}

//if trigger triggered
   //set target to whatever object triggered the trigger
   //spawn bullet
//on exit trigger
    //
  
