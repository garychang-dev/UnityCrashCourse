using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float angularSpeed;
    public float jumpForce;

    private Animator m_Animator;
    private Rigidbody m_Rigidbody;
    private PlayerInputHandler m_PlayerInputHandler;
    private PlayerSounds m_PlayerSounds;
    private GroundCheck m_GroundCheck;

    void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_PlayerInputHandler = GetComponent<PlayerInputHandler>();
        m_PlayerSounds = GetComponentInChildren<PlayerSounds>();
        m_GroundCheck = GetComponent<GroundCheck>();
    }

    private void OnEnable()
    {
        m_PlayerInputHandler.onJumpEvent.AddListener(Jump);
    }

    private void OnDisable()
    {
        m_PlayerInputHandler.onJumpEvent.RemoveListener(Jump);
    }

    void Update()
    {
        Vector2 moveDirection = m_PlayerInputHandler.GetMoveDirection();
        Vector3 direction = ConvertToPlayerDirection(moveDirection);

        Move(direction);
        UpdateAnimator(direction);
    }

    private Vector3 ConvertToPlayerDirection(Vector2 moveDirection)
    {
        Vector3 direction = new Vector3(moveDirection.x, 0f, moveDirection.y);
        direction = Vector3.ClampMagnitude(direction, 1f);
        return direction;
    }

    private void Move(Vector3 direction)
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);

        if (direction != Vector3.zero)
        {
            var desiredRotaton = Quaternion.LookRotation(direction, transform.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotaton, angularSpeed * Time.deltaTime);
        }
    }

    private void UpdateAnimator(Vector3 direction)
    {
        m_Animator.SetBool("isMoving", direction.magnitude > 0.1f);
        m_Animator.SetFloat("speedMultiplier", direction.magnitude);
    }

    private void Jump()
    {
        if (m_GroundCheck.IsGrounded())
        {
            m_Animator.SetTrigger("jump");
            m_Rigidbody.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void OnAnimationJump()
    {
        m_PlayerSounds.PlayJumpSound();
    }

    public void OnAnimationStep()
    {
        m_PlayerSounds.PlayStepSound();
    }
}
