using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private float _initialScaleX;
    private Vector3 _newScale;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _initialScaleX = Mathf.Abs(transform.localScale.x);
        _newScale = transform.localScale;
    }

    public void SetRun(float direction)
    {
        _animator.SetBool("IsRunning", direction != 0f);
        SetDirection(direction);
    }

    private void SetDirection(float direction)
    {
        if (direction == 0f) 
            return;
        
        _newScale.x = Mathf.Sign(direction) * _initialScaleX;
        transform.localScale = _newScale;
    }
}
