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
    }
    
    void onComplete()
    {
        _pool.Release(gameObject);
        SplineAnimate splineanimate = gameObject.GetComponent<SplineAnimate>();
        splineanimate.Restart(true);
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
