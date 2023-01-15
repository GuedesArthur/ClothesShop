using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.Input;

/// <summary>
/// <see cref="Singleton{TSelf}">Singleton</see> class that read the user's <see cref="UnityEngine.Input">Inputs</see>
/// and send them to the <see cref="Player"/>
/// </summary>
public class Controller : Singleton<Controller>
{
    static IControllable _controllable;

    /// <summary>
    /// Sets <see cref="IControllable"/> as the Player
    /// </summary>
    /// <param name="controlled"></param>
    public static void SetControllable(IControllable controlled)
    {
        if (_controllable == controlled) return;

        if(_controllable != null)
            OnActionButtonPress.RemoveListener(_controllable.OnActionButtonPress);

        if (controlled != null)
            OnActionButtonPress.AddListener(controlled.OnActionButtonPress);

        _controllable = controlled;
    }

    public static UnityEvent OnActionButtonPress = new();

    private void Update()
    {
        Vector2 input = new (GetAxis("Horizontal"), GetAxis("Vertical"));
        _controllable.OnDirectionalInput(new DirectionInput(input));

        if (GetKeyDown(KeyCode.Space))
            OnActionButtonPress.Invoke();
    }
}