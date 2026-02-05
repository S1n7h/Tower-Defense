using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    [SerializeField] public GameObject _dropletBulletPrefab;
    public ObjectPool<GameObject> _DropletBulletpool;

    private void Start()
    {
        //Debug.Log("Reached here.");
        _DropletBulletpool = new ObjectPool<GameObject>(CreateDropletBullet, GetDropletBulletFromPool, 
                                                        ReturningDucktoPool, OnDestroyDuck, true, 20, 10);
    }

    GameObject CreateDropletBullet()
    {
        GameObject DropletBullet = Instantiate(_dropletBulletPrefab, _dropletBulletPrefab.transform.position, Quaternion.identity);
        DropletBullet.SetActive(true);
        return DropletBullet;
    }

    private void GetDropletBulletFromPool(GameObject droplet)
    {
        droplet.SetActive(true);
    }

    private void ReturningDucktoPool(GameObject droplet)
    {
        Debug.Log("Bullet was released.");
        droplet.SetActive(false);
    }

    private void OnDestroyDuck(GameObject droplet)
    {
        Destroy(droplet);
    }
}
