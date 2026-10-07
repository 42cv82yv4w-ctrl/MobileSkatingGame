using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerSkater : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 8f;
    public float accel = 16f;
    public float maxSpeed = 14f;
    public float brakeForce = 12f;
    public float turnSpeed = 180f;

    [Header("Jump / Air")]
    public float jumpForce = 6f;
    public float gravityMultiplier = 2.5f;
    public float airControl = 0.75f;

    [Header("Ground Detection")]
    public Transform groundCheck;
    public float groundRadius = 0.3f;
    public LayerMask groundMask;

    [Header("Visuals")]
    public Transform skateModel;
    public float boardTiltAmount = 18f;

    [Header("Anim")]
    public Animator animator;

    private Rigidbody rb;
    private bool isGrounded;
    private bool isAirborne;
    private float horizontalInput;
    private float verticalInput;
    private float currentSpeed;
    private float currentLean;

    public bool IsGrounded => isGrounded;
    public bool IsAirborne => isAirborne;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.drag = 0.2f;
        rb.angularDrag = 0.15f;
    }

    private void Update()
    {
        ReadInput();

        if (groundCheck != null)
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundRadius, groundMask, QueryTriggerInteraction.Ignore);
        }

        if (animator != null)
        {
            animator.SetBool("Grounded", isGrounded);
            animator.SetFloat("Speed", Mathf.Abs(currentSpeed));
            animator.SetBool("Airborne", isAirborne);
        }

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        ApplyVisualTilt();
    }

    private void FixedUpdate()
    {
        Vector3 moveDir = Vector3.zero;

        if (isGrounded)
        {
            moveDir = transform.forward * verticalInput + transform.right * horizontalInput;
            moveDir.Normalize();

            Vector3 targetVelocityVector = moveDir * maxSpeed;
            Vector3 velocityDelta = targetVelocityVector - new Vector3(rb.velocity.x, 0f, rb.velocity.z);
            rb.AddForce(velocityDelta * accel, ForceMode.Acceleration);

            if (moveDir.magnitude <= 0.01f)
            {
                Vector3 flatVel = rb.velocity;
                flatVel.y = 0f;
                flatVel = Vector3.MoveTowards(flatVel, Vector3.zero, brakeForce * Time.fixedDeltaTime);
                flatVel.y = rb.velocity.y;
                rb.velocity = flatVel;
            }
        }
        else
        {
            Vector3 airMove = transform.forward * verticalInput + transform.right * horizontalInput;
            airMove.Normalize();

            Vector3 flatVel = rb.velocity;
            flatVel.y = 0f;
            flatVel = Vector3.MoveTowards(flatVel, flatVel + airMove * 2.5f, airControl * Time.fixedDeltaTime);
            flatVel.y = rb.velocity.y;
            rb.velocity = flatVel;
        }

        Vector3 gravity = Physics.gravity * gravityMultiplier;
        rb.AddForce(gravity, ForceMode.Acceleration);

        if (isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -20f, 999f), rb.velocity.z);
        }

        currentSpeed = new Vector2(rb.velocity.x, rb.velocity.z).magnitude;

        if (isGrounded && Mathf.Abs(horizontalInput) > 0.01f)
        {
            float rotateDir = horizontalInput;
            float rotationAmount = rotateDir * turnSpeed * Time.fixedDeltaTime;
            Quaternion turn = Quaternion.Euler(0f, rotationAmount, 0f);
            rb.MoveRotation(rb.rotation * turn);
        }

        isAirborne = !isGrounded;
    }

    private void ReadInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void Jump()
    {
        if (!isGrounded) return;

        Vector3 jump = Vector3.up * jumpForce;
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(jump, ForceMode.VelocityChange);

        if (animator != null) animator.SetTrigger("Jump");
    }

    private void ApplyVisualTilt()
    {
        float targetTilt = -horizontalInput * boardTiltAmount;
        currentLean = Mathf.Lerp(currentLean, targetTilt, Time.deltaTime * 8f);

        if (skateModel != null)
        {
            Quaternion targetRot = Quaternion.Euler(0f, 0f, currentLean);
            skateModel.localRotation = Quaternion.Lerp(skateModel.localRotation, targetRot, Time.deltaTime * 10f);
        }
    }

    public void TriggerRampLaunch(float launchForce, Vector3 launchDirection)
    {
        rb.velocity = Vector3.zero;
        rb.AddForce(launchDirection.normalized * launchForce, ForceMode.VelocityChange);
        isAirborne = true;
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
        }
    }
}
