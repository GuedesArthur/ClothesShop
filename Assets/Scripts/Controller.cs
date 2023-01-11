using UnityEngine;
using static UnityEngine.Input;

public class Controller : MonoBehaviour
{
    public static IControllable controllable;
    private void Update()
    {
        Vector2 input = new (GetAxis("Horizontal"), GetAxis("Vertical"));
        controllable.OnInput(new DirectionInput(input));
    }
}