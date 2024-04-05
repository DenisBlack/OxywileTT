using UnityEngine;

namespace Inputs
{
    public class MouseInputService : InputService
    {
        public override bool Pressed() => Input.GetMouseButton(0);
        public override bool ReleaseInput() => Input.GetMouseButtonUp(0);
        
        public override InputDirection GetInputDirection()
        {
            if (Input.GetMouseButton(0))
            {
                if (Input.mousePosition.x > Screen.width / 2)
                    return InputDirection.Right;
                else
                    return InputDirection.Left;
            }
            return InputDirection.None;
        }
    }
}