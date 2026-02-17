using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private const float MinSpeedForRun = 0.1f;

    private readonly int _runHash = Animator.StringToHash("Run");
    private readonly int _groundedHash = Animator.StringToHash("Grounded");
    private readonly int _airSpeedYHash = Animator.StringToHash("AirSpeedY");
    private readonly int _jumpHash = Animator.StringToHash("Jump");
    
    [SerializeField] private Animator _animator;

    private bool _wasGrounded = true;

    private void Awake()
    {
        if (_animator != null)
            _animator = GetComponent<Animator>();
    }

    public void UpdateAnimation(float speed, bool isGrounded, float velocityY)
    {
        if (_animator == null) return;

        _animator.SetBool(_runHash, Mathf.Abs(speed) > MinSpeedForRun);
        _animator.SetBool(_groundedHash, isGrounded);
        _animator.SetFloat(_airSpeedYHash, velocityY);

        if (_wasGrounded && !isGrounded && velocityY > 0)
            _animator.SetTrigger(_jumpHash);

        _wasGrounded = isGrounded;
    }
}