using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Animator m_Animator;
    private Rigidbody2D m_Rigidbody;
    private PlayerInputHandler m_PlayerInputHandler;
    private GroundCheck m_GroundCheck;
    private SpriteRenderer m_SpriteRenderer;
    private Weapon m_Weapon;

    private float m_ShootStateLength = .5f;
    private float m_ShootingExpiration;
    private bool m_IsShooting;

    void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_PlayerInputHandler = GetComponent<PlayerInputHandler>();
        m_GroundCheck = GetComponent<GroundCheck>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_Weapon = GetComponent<Weapon>();
    }

    private void OnEnable()
    {
        m_PlayerInputHandler.onJumpEvent.AddListener(Jump);
        m_PlayerInputHandler.onShootEvent.AddListener(Shoot);
    }

    private void OnDisable()
    {
        m_PlayerInputHandler.onJumpEvent.RemoveListener(Jump);
        m_PlayerInputHandler.onShootEvent.RemoveListener(Shoot);
    }

    void Update()
    {
        Vector2 moveDirection = m_PlayerInputHandler.GetMoveDirection();
        Vector3 direction = ConvertToPlayerDirection(moveDirection);

        Move(direction);
        UpdateAnimator(direction);
    }

    private Vector2 ConvertToPlayerDirection(Vector2 moveDirection)
    {
        Vector2 direction = Vector2.ClampMagnitude(moveDirection, 1f);
        direction.y = 0f;
        return direction;
    }

    private void Move(Vector3 direction)
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
        if (direction.x < 0f)
        {
            m_SpriteRenderer.flipX = true;
        }
        if (direction.x > 0f)
        {
            m_SpriteRenderer.flipX = false;
        }
    }

    private void UpdateAnimator(Vector3 direction)
    {
        m_Animator.SetBool("isRunning", Mathf.Abs(direction.x) > 0.1f);
        m_Animator.SetBool("isGrounded", m_GroundCheck.IsGrounded());

        if (m_IsShooting && Time.time > m_ShootingExpiration)
        {
            m_IsShooting = false;
        }
        m_Animator.SetBool("isShooting", m_IsShooting);
    }

    private void Jump()
    {
        if (m_GroundCheck.IsGrounded())
        {
            m_Animator.SetTrigger("jump");
            m_Rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void Shoot()
    {
        m_IsShooting = true;
        m_ShootingExpiration = Time.time + m_ShootStateLength;

        m_Weapon.isFlipped = m_SpriteRenderer.flipX;
        m_Weapon.Fire();
    }
}
