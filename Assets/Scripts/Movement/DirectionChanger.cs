using UnityEngine;

public class DirectionChanger : MonoBehaviour
{
    private const float RightRotation = 0f;
    private const float LeftRotation = 180f;
    
    private float _angle;

    public void SetDirection(float direction)
    {
        if (direction == 0f)
            return;

        if (direction > 0f)
            _angle = RightRotation;
        else
            _angle = LeftRotation;

        transform.rotation = Quaternion.Euler(0f, _angle, 0f);
    }
}
