using Unity.Mathematics;
using UnityEditor.ShaderGraph.Internal;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.Pool;

public class enemyAni : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private SplineAnimate aniSpline;
    [SerializeField] private Animator animator;
    private SplineContainer containsSpline;
    private ObjectPool<GameObject> _pool;
    void Start()
    {
        aniSpline.Completed += onComplete;
        containsSpline = gameObject.GetComponent<SplineContainer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CalculateTangent() < 0.0f)
        {
            animator.SetBool("isGoingLeft", true);
        }
        else
        {
            animator.SetBool("isGoingLeft", false);
        }

        aniSpline.ElapsedTime += aniSpline.MaxSpeed * Time.deltaTime;

        //Objects moving across splines had their z component going haywire during spline animation preventing particle collisions from happening.
        //this is required to make particle collisions happen 
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
    
    void onComplete()
    {
        _pool.Release(gameObject);
        SplineAnimate splineanimate = gameObject.GetComponent<SplineAnimate>();
        aniSpline.ElapsedTime = 0;

        //omitted for now
        //splineanimate.Restart(true);
    }

    public float CalculateTangent()
    {
        float tratio = aniSpline.ElapsedTime / aniSpline.Duration;
        float3 tangentVector = containsSpline.EvaluateTangent(aniSpline.Container.Spline, tratio);
        return tangentVector.x;
    }

    public void SetPool(ObjectPool<GameObject> pool)
    {
        _pool = pool;
    }
}
