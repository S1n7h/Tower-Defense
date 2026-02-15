using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Splines;
using UnityEngine.Pool;

public class spawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject Duck;

    public ObjectPool<GameObject> _duckpool;
    void Start()
    {
        _duckpool = new ObjectPool<GameObject>(CreateDuck, GetDuckfromPool, ReturningDucktoPool, OnDestroyDuck, true, 10, 20);
        Duck.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            spawn();
        }
    }
    void spawn()
    {
        //previous method of instantiating duck object
        GameObject tempduck = _duckpool.Get();
        tempduck.SetActive(true);
    }

    GameObject CreateDuck()
    {   
        //Instantiating a new duck GameObject
        GameObject duck = Instantiate(Duck, Duck.transform.position, Duck.transform.rotation);
        enemyAni enemyani = duck.GetComponent<enemyAni>();
        enemyani.SetPool(_duckpool);
        return duck;
    }

    //to do when taking object from object pool
    private void GetDuckfromPool(GameObject duck)
    {
        //setting duck's gameobject properties
        //Debug.Log("This is being called to spawn the duck.");
        duck.transform.position = Duck.transform.position;
        duck.transform.rotation = Duck.transform.rotation;
        //activating duck
        duck.SetActive(true);
    }

    //what to do when returning to pool
    private void ReturningDucktoPool(GameObject duck)
    {
        //Debug.Log("This is being called to release the duck.");

        //reseting spline animate of the duck
        SplineAnimate splineAnimate = duck.GetComponent<SplineAnimate>();

        //recent omition
        // splineAnimate.Restart(true);
        duck.SetActive(false);
    }

    private void OnDestroyDuck(GameObject duck)
    {
        //Debug.Log("This is being called to destroy the duck.");
        Destroy(duck);
    }
}
