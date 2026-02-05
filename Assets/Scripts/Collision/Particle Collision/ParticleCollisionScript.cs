using Unity.VisualScripting;
using UnityEngine;

public class ParticleCollisionScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnParticleCollision2D(GameObject other)
    {
        Debug.Log("Particle Collision Detected.");
        Destroy(other);
    }
}
