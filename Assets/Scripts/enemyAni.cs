using Unity.Mathematics;
using UnityEditor.ShaderGraph.Internal;
using UnityEditorInternal.VersionControl;
using UnityEngine;
using UnityEngine.Splines;

public class enemyAni : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private SplineAnimate aniSpline;
    [SerializeField] private Animator animator;
    private SplineContainer containsSpline;
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
        Destroy(gameObject);
    }

    public float CalculateTangent()
    {
        float tratio = aniSpline.ElapsedTime / aniSpline.Duration;
        float3 tangentVector = containsSpline.EvaluateTangent(aniSpline.Container.Spline, tratio);
        return tangentVector.x;
    }
    
}
