namespace Inputs
{
    public interface IInputService
    {
         bool Pressed();
         bool ReleaseInput();
         
         InputDirection GetInputDirection();
    }
}