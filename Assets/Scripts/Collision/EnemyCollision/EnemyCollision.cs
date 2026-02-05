using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] string DuckTag;
    private List<Transform> EnemyList;
    [SerializeField] float ReloadTime;
    [SerializeField] float Damage;
    [SerializeField] float BulletSpeed;
    [SerializeField] float BlastRadius;
    [SerializeField] CurrencyManager _currencyManager;
    private BulletPool _bulletPoolContainer;
    private spawner _duckPoolContainer;
    private float _reloadTime = 0.0f;
    private void Start()
    {
        EnemyList = new List<Transform>();
    }
    private void Update()
    {
        while (EnemyList.Count > 0 && EnemyList[0] == null) EnemyList.RemoveAt(0);
        //if ready to shoot and there are enemies present in range
        if (_reloadTime >= ReloadTime && EnemyList.Count != 0)
        {
            //Debug.Log($"Container: {_bulletPoolContainer}");
            //Debug.Log($"Pool: {_bulletPoolContainer._DropletBulletpool}");

            //create a bullet
            GameObject Tempbullet = _bulletPoolContainer._DropletBulletpool.Get();

            //set the position of bullet to tower's position
            Tempbullet.transform.position = this.transform.position;

            //setup the bullet
            Debug.Log("Shot a bullet.");
            Bullet _bullet = Tempbullet.GetComponent<Bullet>();
            _bullet.SetPool(_bulletPoolContainer._DropletBulletpool);
            _bullet.Initialise(EnemyList[0], Damage, BulletSpeed, BlastRadius, _duckPoolContainer);
            CurrencyManager.instance.SpillBlood();

            _reloadTime = 0.0f;
        }
        _reloadTime += Time.deltaTime;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected.");
        if (collision.gameObject.tag == DuckTag)
        {
            //Debug.Log("Duck was detected.");
            EnemyList.Add(collision.transform);
        }        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (EnemyList.Count != 0) EnemyList.RemoveAt(0);
    }

    public void Initialise(BulletPool bulletPool, spawner duckPoolContainer)
    {
        _bulletPoolContainer = bulletPool;
        _duckPoolContainer = duckPoolContainer;
    }
}

//if trigger triggered
   //set target to whatever object triggered the trigger
   //spawn bullet
//on exit trigger
    //
  
