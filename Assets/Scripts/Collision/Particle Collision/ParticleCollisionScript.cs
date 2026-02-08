using Unity.VisualScripting;
using UnityEngine;

public class ParticleCollisionScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnParticleTrigger()
    {
        Debug.Log("Particle Collision Detected.");
    }
}
