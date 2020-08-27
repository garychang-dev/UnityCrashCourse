using UnityEngine;

public class PlayerControllerV2 : MonoBehaviour
{
    private Animator m_Animator;
    private PlayerInputHandler m_PlayerInputHandler;

    // For smooth movement purposes
    public float smoothingFactor = 5f;
    private Vector3 m_CurrentDirection;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();
        m_PlayerInputHandler = GetComponent<PlayerInputHandler>();
    }

    private void OnEnable()
    {
        m_PlayerInputHandler.onBlockEvent.AddListener(OnBlock);
        m_PlayerInputHandler.onAttackEvent.AddListener(OnAttack);
    }

    private void OnDisable()
    {
        m_PlayerInputHandler.onBlockEvent.RemoveListener(OnBlock);
        m_PlayerInputHandler.onAttackEvent.RemoveListener(OnAttack);
    }

    private void Update()
    {
        UpdatePosition();
        UpdateRotation();
    }

    private Vector3 ConvertToPlayerDirection(Vector2 moveDirection)
    {
        Vector3 direction = new Vector3(moveDirection.x, 0f, moveDirection.y);
        direction = Vector3.ClampMagnitude(direction, 1f);
        return direction;
    }

    private void UpdatePosition()
    {
        Vector2 moveDirection = m_PlayerInputHandler.GetMoveDirection();
        Vector3 direction = ConvertToPlayerDirection(moveDirection);

        // Smooth out the direction changes
        Vector3 change = direction - m_CurrentDirection;
        m_CurrentDirection += change * smoothingFactor * Time.deltaTime;

        m_Animator.SetFloat("blendX", m_CurrentDirection.x);
        m_Animator.SetFloat("blendZ", m_CurrentDirection.z);
    }

    private void UpdateRotation()
    {
        Vector2 lookRotation = m_PlayerInputHandler.GetLookDirection();
        m_Animator.SetFloat("turn", lookRotation.x);
    }

    private void OnAttack()
    {
        m_Animator.SetTrigger("attack");
    }

    private void OnBlock(bool blockStatus)
    {
        m_Animator.SetBool("isBlocking", blockStatus);
    }
}
