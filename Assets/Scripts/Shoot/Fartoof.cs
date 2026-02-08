using Unity.VisualScripting;
using UnityEngine;

public class Fartoof : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;
    bool CollidersInRange = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered Trigger.");
        CollidersInRange = true;
        Debug.Log($"{collision.gameObject.name}");
        _particleSystem.trigger.AddCollider(collision);
        fart();
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
        CollidersInRange = false;
        _particleSystem.trigger.RemoveCollider(collision);
    }

    void fart()
    {
        _particleSystem.Play(true);
    }    
}
