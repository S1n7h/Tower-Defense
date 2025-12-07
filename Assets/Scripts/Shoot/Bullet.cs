using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
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
            Destroy(this);
        }_timeElapsed += Time.deltaTime;
        if (_target != null)
        {
            Vector3 direction = (_target.position - this.transform.position).normalized;

            this.transform.position += _bulletSpeed * direction * Time.deltaTime;

            if (Vector3.Distance(this.transform.position, _target.position) < _blastRadius)
            {
                Destroy(this.gameObject);
                Destroy(_target.gameObject);
            }
        }
        else //redirect projectile to next enemy
        {

        }
    }
}

