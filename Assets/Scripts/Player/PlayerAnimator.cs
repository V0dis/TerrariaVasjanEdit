using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const float MinSpeedForRun = 0.1f;

    private static readonly int RunHash = Animator.StringToHash("Run");
    private static readonly int GroundedHash = Animator.StringToHash("Grounded");
    private static readonly int AirSpeedYHash = Animator.StringToHash("AirSpeedY");
    private static readonly int JumpHash = Animator.StringToHash("Jump");

    [SerializeField] private Animator _animator;

    private bool _wasGrounded = true;

    private void Awake()
    {
        if (_animator == null)
            _animator = GetComponent<Animator>();
    }

    public void SetAnimationParameters(float speed, bool isGrounded, float velocityY)
    {
        if (_animator == null)
            return;

        _animator.SetBool(RunHash, Mathf.Abs(speed) > MinSpeedForRun);
        _animator.SetBool(GroundedHash, isGrounded);
        _animator.SetFloat(AirSpeedYHash, velocityY);

        if (_wasGrounded && !isGrounded && velocityY > 0)
            _animator.SetTrigger(JumpHash);

        _wasGrounded = isGrounded;
    }
}
