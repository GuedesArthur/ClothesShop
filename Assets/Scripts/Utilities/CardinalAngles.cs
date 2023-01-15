using static UnityEngine.Mathf;

/// <summary>
/// 8 direction angle. Used for <see cref="UnityEngine.SpriteRenderer">rendering sprites</see> that "rotate".
/// </summary>
public enum CardinalAngles : byte
{
    South,
    SouthEast,
    East,
    NorthEast,
    North,
    NorthWest,
    West,
    SouthWest
};

public static class CardinalAnglesEXT
{
    const float OneOver45 = 1f / 45f;
    
    /// <param name="angle">Angle, in degrees</param>
    /// <returns>Corresponding <see cref="CardinalAngles">Cardinal Angle </see></returns>
    public static CardinalAngles ToCardinalAngle(this float angle)
        => (CardinalAngles)FloorToInt(angle * OneOver45);
}