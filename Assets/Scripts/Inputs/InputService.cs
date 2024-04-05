namespace Inputs
{
    public abstract class InputService : IInputService
    {
        public abstract bool Pressed();
        public abstract bool ReleaseInput();
        
        public abstract InputDirection GetInputDirection();

    }
    
    public enum InputDirection
    {
        None,
        Left,
        Right
    }
}
