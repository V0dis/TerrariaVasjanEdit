using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private const float MinSpeedForRun = 0.1f;

    private static readonly int RunHash = Animator.StringToHash("Run");
    private static readonly int GroundedHash = Animator.StringToHash("Grounded");
    private static readonly int AirSpeedYHash = Animator.StringToHash("AirSpeedY");

    [SerializeField] private Animator _animator;

    private bool _wasGrounded = true;

    private void Awake()
    {
        if (_animator == null)
            _animator = GetComponent<Animator>();
    }

    public void SetSpeed(float speed)
    {
        _animator.SetBool(RunHash, Mathf.Abs(speed) > MinSpeedForRun);
    }

    public void SetGrounded(bool isGrounded)
    {
        _animator.SetBool(GroundedHash, isGrounded);

        _wasGrounded = isGrounded;
    }

    public void SetAirSpeedY(float velocityY)
    {
        _animator.SetFloat(AirSpeedYHash, velocityY);
    }
}
