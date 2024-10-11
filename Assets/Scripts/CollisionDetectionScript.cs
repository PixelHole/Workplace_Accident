using UnityEngine;
using UnityEngine.Events;

public class CollisionDetectionScript : MonoBehaviour
{
    [SerializeField] private float SpeedThreshold = 10f;

    public UnityEvent EntityCrushed;

    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out Rigidbody rb);
        
        if (!rb) return;
        
        var speed = rb.velocity.magnitude;
        
        if (speed > SpeedThreshold) EntityCrushed.Invoke();
    }
}
