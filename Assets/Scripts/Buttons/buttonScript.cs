using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Pool;

public class ButtonScript : MonoBehaviour, IDragHandler, IEndDragHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Button button;
    [SerializeField] GameObject GameObjectHolder;
    [SerializeField] Image ImageToRender;
    [SerializeField] BulletPool bulletPoolContainer;
    Vector3 mouse_pos;
    
    // Update is called once per frame
    void Update()
    {
        mouse_pos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (!ImageToRender.enabled) ImageToRender.enabled = true;
        ImageToRender.transform.position = new Vector3(mouse_pos.x, mouse_pos.y, 0);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        GameObject GameObjectToSpawn = Instantiate(GameObjectHolder, new Vector3(mouse_pos.x, mouse_pos.y, 0), Quaternion.identity);

        //setup EnemyCollision script to reference the Pool
        EnemyCollision enemyCollision = GameObjectToSpawn.GetComponent<EnemyCollision>();
        enemyCollision.Initialise(bulletPoolContainer);

        ImageToRender.enabled = false;
        GameObjectToSpawn.SetActive(true);
        Animator anim_temp = GameObjectToSpawn.GetComponent<Animator>();
        anim_temp.enabled = true;
    }
}



