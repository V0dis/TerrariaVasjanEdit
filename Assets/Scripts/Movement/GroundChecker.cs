using System.Collections;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    [SerializeField] private float _checkRadius = 0.1f;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Transform _checkPoint;
    [SerializeField] private float _checkInterval = 0.1f;

    private bool _isGrounded;

    public bool IsGrounded => _isGrounded;

    public void Initialize()
    {
        if (_checkPoint == null)
            _checkPoint = transform;

        StartCoroutine(CheckGround(_checkInterval));
    }

    private IEnumerator CheckGround(float wait)
    {
        while (enabled)
        {
            Check();
            yield return new WaitForSeconds(wait);
        }
    }

    public void Check()
    {
        Debug.DrawRay(_checkPoint.position, Vector2.down * _checkRadius, Color.red);

        Collider2D hit = Physics2D.OverlapCircle(_checkPoint.position, _checkRadius, _groundLayer);
        _isGrounded = hit != null;
    }
}
