using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public class ParticleCollisionScript : MonoBehaviour
{
    private spawner _duckPoolContainer;
    private ParticleSystem particleSystem;
    private ParticleSystem.Particle[] emittedParticles;
    private List<Transform> enemiesInRange = new List<Transform>();

    [SerializeField] float radiusDecrease;
    void OnEnable()
    {
        particleSystem = GetComponent<ParticleSystem>();

        // Allocate once with max particles
        emittedParticles = new ParticleSystem.Particle[particleSystem.main.maxParticles];
    }

    void Update()
    {
        int numParticlesAlive = particleSystem.GetParticles(emittedParticles);

        if (numParticlesAlive > 0)
        {
            float size = emittedParticles[0].GetCurrentSize(particleSystem);
            var tempListOfEnemiesToRemove = new List<Transform>();

            for (int i = 0 ; i < enemiesInRange.Count ; i++)
            {
                if (size - radiusDecrease >= Vector2.Distance(enemiesInRange[i].transform.position, transform.position))
                {
                    tempListOfEnemiesToRemove.Add(enemiesInRange[i]);
                    _duckPoolContainer._duckpool.Release(enemiesInRange[i].gameObject);
                }                
            }
            for (int i = 0 ; i < tempListOfEnemiesToRemove.Count ; i++)
            {
                enemiesInRange.Remove(tempListOfEnemiesToRemove[i]);
            }
            Debug.Log($"Current Size of First Particle: {size}");
        }
    }

    public void Initialise(spawner _DuckPoolContainer)
    {
        this._duckPoolContainer = _DuckPoolContainer;
    }

    public void AddEnemies(Transform enemy)
    {
        enemiesInRange.Add(enemy);
    }

    //if you interchange the two lines dealing with releasing duck from pool and adding to templistof
    //enemies to remove, you will end up triggering on trigger exit of Fartoof which will lead to 
    //RemoveEnemies getting called, which in turn, will remove the enemy. Due to this, when
    //enemiesInRange.Remove(tempListOfEnemiesToRemove[i]); is gonna be run, since the enemy was already
    //removed in this roundabout way, it will trigger an out of range error.
    public void RemoveEnemies(Transform enemy)
    {
        if (enemiesInRange.Contains(enemy))
            enemiesInRange.Remove(enemy);
    }
}
