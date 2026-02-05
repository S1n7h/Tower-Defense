using UnityEngine;
using UnityEngine.ParticleSystemJobs;

public class Fart : MonoBehaviour
{

    void fart()
    {
        ParticleSystem _particleSystem = gameObject.GetComponent<ParticleSystem>();
        _particleSystem.Play(true);
    }

    void OnParticleCollision2D(GameObject other)
    {
        fart();
    }
 
}