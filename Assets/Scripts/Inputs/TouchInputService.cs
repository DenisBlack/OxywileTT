using UnityEngine;

namespace Inputs
{
    public class TouchInputService : InputService
    {
        public override bool Pressed() => Input.touchCount > 0;

        public override bool ReleaseInput() => Input.touchCount == 0;
        
        public override InputDirection GetInputDirection()
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).position.x > Screen.width / 2)
                    return InputDirection.Right;
                else
                    return InputDirection.Left;
            }
            
            return InputDirection.None;
        }
    }
}