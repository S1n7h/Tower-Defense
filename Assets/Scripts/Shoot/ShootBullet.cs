using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] Transform prefabBullet;
    [SerializeField] private Transform transformOfSpawnPoint;
    [SerializeField] EnemyCollision enemyCollision;
    [SerializeField] int BulletSpd;

    private void Update()
    {
        if (enemyCollision.PublicEnemyList.Count != 0)
        {
            Transform bullet = Instantiate(prefabBullet, transformOfSpawnPoint.position, Quaternion.identity);
            BulletMovement(bullet, enemyCollision.PublicEnemyList[0].transform);
        }
    }

    void BulletMovement(Transform bullet, Transform target)
    {
        Vector3 direction = (target.position - bullet.position).normalized;

        bullet.position += BulletSpd * direction * Time.deltaTime;

        if (Vector3.Distance(bullet.position, target.position) <= 1f)
        {
            Destroy(bullet.gameObject);
            Destroy(target.gameObject);
        }
    }
}

