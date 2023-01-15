using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

/// <summary>
/// Calculates and allocates in stack information regarding analog direction inputs.
/// </summary>
public readonly ref struct DirectionInput
{
    /// <summary>
    /// Inputs below this magnitude shall be considered null (Dead)
    /// </summary>
    public const float DeadMagnitude = 0.1f;

    /// <summary>
    /// Direct input value. Class implicity converts to this value.
    /// </summary>
    private readonly Vector2 input;
    /// <summary>
    /// Normalized input. Invalid if <see cref="isDead"/>.
    /// </summary>
    public readonly Vector2 direction;
    /// <summary>
    /// Direction angle, in degrees. Invalid if <see cref="isDead"/>.
    /// </summary>
    public readonly float angle;
    /// <summary>
    /// <see cref="CardinalAngles">Cardinal Angle</see>. Invalid if <see cref="isDead"/>.
    /// </summary>
    public readonly CardinalAngles cardinalAngle;
    /// <summary>
    /// Magnitude of the analog input.
    /// </summary>
    public readonly float magnitude;
    /// <summary>
    /// Is magnitude below <see cref="DeadMagnitude"/>?
    /// </summary>
    public readonly bool isDead;

    public DirectionInput(Vector2 input)
    {
        this.input = input;
        angle = (Atan2(input.y, input.x) * Rad2Deg + 449.999f) % 360;
        cardinalAngle = angle.ToCardinalAngle();
        magnitude = input.magnitude;
        isDead = magnitude <= DeadMagnitude;
        direction = isDead ? Vector2.zero : input / magnitude;
    }

    /// <summary>
    /// Vertical input component
    /// </summary>
    public readonly float Vertical => direction.y;
    /// <summary>
    /// Horizontall input component
    /// </summary>
    public readonly float Horizontal => direction.x;

    public static implicit operator Vector2(DirectionInput input)
        => input.input;
}
