using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Splines;

public class spawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject Duck;
    void Start()
    {
        Duck.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Space is Pressed.");
            spawn();
        }
    }
    void spawn()
    {
        GameObject tempduck = Instantiate(Duck, Duck.transform.position, Duck.transform.rotation);
        tempduck.SetActive(true);
    }
}
