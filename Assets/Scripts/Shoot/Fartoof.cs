using UnityEngine;

public class Fartoof : MonoBehaviour
{
    [SerializeField] ParticleSystem _particleSystem;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("LDJSLKFJSLDF");
        fart();
    }
    void fart()
    {
        _particleSystem.Play(true);
    }
}
