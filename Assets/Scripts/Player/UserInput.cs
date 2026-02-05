using UnityEngine;

public class UserInput : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const string JumpButton = "Jump";

    public Vector2 GetMoveInput()
    {
        return new Vector2(Input.GetAxis(HorizontalAxis), 0f);
    }

    public bool GetJumpInput()
    {
        return Input.GetButtonDown(JumpButton);
    }
}
