using UnityEngine;

public class PlayerControllerV2 : MonoBehaviour
{
    private Animator m_Animator;
    private PlayerInputHandler m_PlayerInputHandler;

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
        Vector2 moveDirection = m_PlayerInputHandler.GetMoveDirection();
        Vector3 direction = ConvertToPlayerDirection(moveDirection);

        m_Animator.SetFloat("blendX", direction.x);
        m_Animator.SetFloat("blendZ", direction.z);
    }

    private Vector3 ConvertToPlayerDirection(Vector2 moveDirection)
    {
        Vector3 direction = new Vector3(moveDirection.x, 0f, moveDirection.y);
        direction = Vector3.ClampMagnitude(direction, 1f);
        return direction;
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
