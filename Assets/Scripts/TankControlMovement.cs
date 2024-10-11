using System.Linq;
using UnityEngine;

public class TankControlMovement : MonoBehaviour
{
    [SerializeField] private InputInterpreter inputInterpreter;
    [Space]
    [SerializeField] private Rigidbody rb;
    [Space]
    [SerializeField] private float MovementSpeed = 5;

    [SerializeField] private float RotationSpeed = 0.2f;
    [Space]
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private Transform ForcePosition;

    [SerializeField] private LayerMask GroundMask;

    private RaycastHit Under;
    private Rigidbody MovingPlatform;

    private Vector3 PlayerInfluence = Vector3.zero;
    private Vector3 MovingPlatformInfluence = Vector3.zero;

    public bool isMoving => inputInterpreter.InputMovementDirection != 0;

    private void Start()
    {
        GetComponents();
    }

    private void GetComponents()
    {
        if (!rb) rb = GetComponent<Rigidbody>();
        if (!inputInterpreter) inputInterpreter = GameObject.FindWithTag("Input").GetComponent<InputInterpreter>();
    }

    private void Update()
    {
        HandleMovement();

        if (inputInterpreter.InputRotationDirection == 1)
        {
            RotateRight();
        }
        else if (inputInterpreter.InputRotationDirection == -1)
        {
            RotateLeft();
        }
    }

    private void HandleMovement()
    {
        if (!Physics.CheckSphere(GroundCheck.position, 0.4f, GroundMask)) return;

        GetMovingPlatform();

        HandlePlayerMovement();
        if (MovingPlatform) HandleMovingPlatform();

        rb.velocity = PlayerInfluence + MovingPlatformInfluence;
    }

    private void GetMovingPlatform()
    {
        var hits = Physics.OverlapSphere(GroundCheck.position, 0.4f, GroundMask);
        
        foreach (var hit in hits)
        {
            if (!hit.transform.CompareTag("Moving Platform")) continue;
            MovingPlatform = hit.GetComponent<Rigidbody>();
            return;
        }

        MovingPlatform = null;
    }
    
    private void HandlePlayerMovement()
    {
        var direction = transform.forward;
        var movement = direction * (MovementSpeed * inputInterpreter.InputMovementDirection);
        PlayerInfluence = new Vector3(movement.x, rb.velocity.y, movement.z);
    }

    private void HandleMovingPlatform()
    {
        MovingPlatformInfluence = MovingPlatform.velocity;
    }
    
    public void RotateLeft()
    {
        Rotate(-RotationSpeed);
    }

    public void RotateRight()
    {
        Rotate(RotationSpeed);
    }

    public void Rotate(float amount)
    {
        transform.Rotate(transform.up, amount);
    }
}
