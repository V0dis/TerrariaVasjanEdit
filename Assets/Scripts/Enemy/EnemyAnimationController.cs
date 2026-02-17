using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    private readonly static int _RunHash = Animator.StringToHash("Run");
    
    [SerializeField] private Animator _animator;

    private void Awake()
    {
        if (_animator == null)
            _animator = GetComponent<Animator>();
    }

    public void UpdateAnimation(bool isMoving)
    {
        if (_animator == null)
            return;
    
        _animator.SetBool(_RunHash, isMoving);
    }
}
