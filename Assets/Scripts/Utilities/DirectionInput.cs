using Swizzler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public readonly ref struct DirectionInput
{
    public const float DeadMagnitude = 0.1f;
    const float OneOver90 = 1f / 90f;

    private readonly Vector2 input;
    private readonly Vector3 input3D;
    public readonly Vector2 direction;
    public readonly float angle;
    public readonly SimpleAngle simpleAngle;
    public readonly float magnitude;
    public readonly bool isDead;

    public DirectionInput(Vector2 input)
    {
        this.input = input;
        input3D = input.X0Y();
        angle = Atan2(input.y, input.x) * Rad2Deg;
        simpleAngle = (SimpleAngle)RoundToInt(angle * OneOver90);
        magnitude = input.magnitude;
        isDead = magnitude <= DeadMagnitude;
        direction = isDead ? Vector2.zero : input / magnitude;
    }

    public readonly float Vertical => direction.y;
    public readonly float Horizontal => direction.x;

    public static implicit operator Vector2(DirectionInput input)
        => input.input;

    public static implicit operator Vector3(DirectionInput input)
        => input.input3D;
}
