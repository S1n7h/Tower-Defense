using Unity.VisualScripting;
using UnityEngine;

public class Fartoof : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;

    [SerializeField] ParticleSystem _particleSystem2;
    [SerializeField] GameObject Enemy;
    [SerializeField] ParticleCollisionScript particleCollisionScript;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Enemy.tag)
        {
            //Debug.Log($"{collision.tag} Entered Trigger. My Instance id is {GetInstanceID()}. The collided object instance id is {collision.GetInstanceID()}");
            particleCollisionScript.AddEnemies(collision.transform);
            _particleSystem.trigger.AddCollider(collision);
            _particleSystem2.trigger.AddCollider(collision);
            fart();            
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // if (!CollidersInRange)
        // {
        //     CollidersInRange = true;
        //     _particleSystem.trigger.AddCollider(collision);
        // } 
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == Enemy.tag)
        {
            particleCollisionScript.RemoveEnemies(collision.transform);
            _particleSystem.trigger.RemoveCollider(collision);
            _particleSystem2.trigger.RemoveCollider(collision);
            //Debug.Log($"{collision.tag} Exited Trigger. My Instance id is {GetInstanceID()}. The collided object instance id is {collision.GetInstanceID()}");
        }
    }

    void fart()
    {
        _particleSystem.Play(true);
    }    
}
