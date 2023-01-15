
/// <summary>
/// Classes that can be controlled by <see cref="OnDirectionalInput(DirectionInput)">analog</see> and <see cref="OnActionButtonPress">button</see> inputs
/// </summary>
public interface IControllable
{
    public void OnDirectionalInput(DirectionInput input);

    public void OnActionButtonPress();
}