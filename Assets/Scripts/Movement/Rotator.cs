using UnityEngine;

public class Rotator : MonoBehaviour
{
    private const float RightRotation = 0f;
    private const float LeftRotation = 180f;
    
    private float _direction;

    public void SetDirection(float direction)
    {
        if (direction == 0f)
            return;

        _direction = direction > 0f ? RightRotation : LeftRotation;
        transform.rotation = Quaternion.Euler(0f, _direction, 0f);
    }
}
