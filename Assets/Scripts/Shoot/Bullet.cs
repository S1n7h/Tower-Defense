using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Splines;

public class Bullet : MonoBehaviour
{
    private ObjectPool<GameObject> _dropletBulletpool;
    private spawner _duckPoolContainer;
    private Transform _target;
    private float _damage;
    private float _bulletSpeed;
    private float _blastRadius;
    [SerializeField] float expireTime;
    private float _timeElapsed = 0.0f;
    public void Initialise(Transform Target, float Damage, float BulletSpeed, float BlastRadius, spawner duckPoolContainer)
    {
        this._target = Target;
        this._damage = Damage;
        this._bulletSpeed = BulletSpeed;
        this._blastRadius = BlastRadius;
        this._duckPoolContainer = duckPoolContainer;
    }
    void Update()
    {
        if (_timeElapsed >= expireTime)
        {
            //set it to 0 otherwise, the next time it is enabled, the _timeElapsed is already going to be above 
            //expireTime
            _timeElapsed = 0;
            _dropletBulletpool.Release(gameObject);
        }_timeElapsed += Time.deltaTime;

        //don't check for null, instead check whether target is active or not since pooling is implemented
        if (_target.gameObject.activeInHierarchy != false)
        {
            Vector3 direction = (_target.position - this.transform.position).normalized;

            this.transform.position += _bulletSpeed * direction * Time.deltaTime;

            if (Vector3.Distance(this.transform.position, _target.position) < _blastRadius)
            {
                _dropletBulletpool.Release(gameObject);
                _duckPoolContainer._duckpool.Release(_target.gameObject);

                //set target gameobject's elapsed time to 0, so that it doesn't spawn at the same spot
                _target.gameObject.GetComponent<SplineAnimate>().ElapsedTime = 0;
                //Destroy(_target.gameObject);
            }
        }
        else //redirect projectile to next enemy
        {

        }
    }

    //set pool to droplet's gloabal bullet pool
    public void SetPool(ObjectPool<GameObject> dropletBulletpool)
    {
        _dropletBulletpool = dropletBulletpool;
    }
}

