using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    private static readonly int RunHash = Animator.StringToHash("Run");

    [SerializeField] private Animator _animator;

    public void SetMoving()
    {
        _animator.SetBool(RunHash, true);
    }

    public void SetIdle()
    {
        _animator.SetBool(RunHash, false);
    }
}
