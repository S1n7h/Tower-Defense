using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    private ObjectPool<GameObject> _dropletBulletpool;
    private Transform _target;
    private float _damage;
    private float _bulletSpeed;
    private float _blastRadius;
    [SerializeField] float expireTime;
    private float _timeElapsed = 0.0f;
    public void Initialise(Transform Target, float Damage, float BulletSpeed, float BlastRadius)
    {
        this._target = Target;
        this._damage = Damage;
        this._bulletSpeed = BulletSpeed;
        this._blastRadius = BlastRadius;
    }
    void Update()
    {
        if (_timeElapsed >= expireTime)
        {
            _dropletBulletpool.Release(gameObject);
        }_timeElapsed += Time.deltaTime;
        if (_target != null)
        {
            Vector3 direction = (_target.position - this.transform.position).normalized;

            this.transform.position += _bulletSpeed * direction * Time.deltaTime;

            if (Vector3.Distance(this.transform.position, _target.position) < _blastRadius)
            {
                _dropletBulletpool.Release(gameObject);
                Destroy(_target.gameObject);
            }
        }
        else //redirect projectile to next enemy
        {

        }
    }

    //set pool to droplet's gloabal bullet pool
    public void SetPool(ObjectPool<GameObject> DropletBulletpool)
    {
        _dropletBulletpool = DropletBulletpool;
    }
}

