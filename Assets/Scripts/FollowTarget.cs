using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    
    
    [Tooltip("Seconds to reach target")] 
    public float smoothTime = 0.5f;
    public Vector3 offset = new Vector3(0f, 0f, -10f);

    private Vector3 _velocity;
    private Transform _transform;

    public bool isFollowingTarget;

    private void Start()
    {
        isFollowingTarget = true;
        _transform = transform;
        _transform.position = target.position + offset;
    }
    

    private void FixedUpdate()
    {
        if (isFollowingTarget)
        {
            Vector3 targetPosition = target.TransformPoint(offset);
            _transform.position = Vector3.SmoothDamp(_transform.position, targetPosition, ref _velocity, smoothTime);
        }
                
    }
}
