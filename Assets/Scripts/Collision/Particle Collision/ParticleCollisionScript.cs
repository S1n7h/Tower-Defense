using Unity.VisualScripting;
using UnityEngine;

public class ParticleCollisionScript : MonoBehaviour
{
    private spawner _duckPoolContainer; 
    private ParticleSystem _particleSystem;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnParticleTrigger()
    {
        Debug.Log("Particle Trigger Detected."); 
    }

    void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle Collision Detected."); 

        //When particle collides with enemy, enemy is killed
        _duckPoolContainer._duckpool.Release(other);        

        //Remove enemy from list of particle system colliders.
        _particleSystem.trigger.RemoveCollider(other.GetComponent<Collider2D>());     
    }

    public void Initialise(spawner _DuckPoolContainer)
    {
        this._duckPoolContainer = _DuckPoolContainer;
    }
}
