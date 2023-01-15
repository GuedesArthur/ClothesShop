using UnityEngine;
using System;
using System.Runtime.CompilerServices;
using static System.Runtime.CompilerServices.MethodImplOptions;

/// <summary>
/// Clothing piece data (<see cref="ScriptableObject"/>). Stores information about each clothing item available in the game.
/// <br/><br/>Not to be mistaken by <see cref="ClothingSprite"/> (clothing instance when worn) and <see cref="ClothingStand"/> (where you buy a piece upon interacting)
/// </summary>
[CreateAssetMenu(fileName ="Clothing", menuName ="Items/Clothing")]
public class ClothingData : ScriptableObject
{
    //public bool hasCustomColors;
    public Area equipArea = Area.Torso;
    //public Color defaultColor = Color.white;
    public double price = 123.45; // NOTE: see Wallet.amount's note.

    public Sprite Icon;
    public Sprite[] Sprites = new Sprite[8]; // One sprite for each CardinalDirection.
                                             // TODO: A custom PropertyDrawer that facilitates the assignment of sprites

    /// <summary>
    /// Whether this <see cref="ClothingData">clothing</see> overlaps with another piece.
    /// <br/><br/>If information about overlapping is required, use: <see cref="OverlappingArea(ClothingData)"/>
    /// </summary>
    /// <param name="other">The other clothing piece</param>
    /// <returns>True if there is any overlap. False otherwise.</returns>
    [MethodImpl(AggressiveInlining)]
    public bool Overlaps(ClothingData other) => OverlappingArea(other) != Area.None;

    /// <summary>
    /// Which exact <see cref="Area">areas</see> of this and the other <see cref="ClothingData">clothing</see> piece cause overlaps. 
    /// <br/><br/>If you only need to know whether it overlaps or not, use: <see cref="Overlaps(ClothingData)"/>
    /// </summary>
    /// <param name="other">The other clothing piece</param>
    /// <returns><see cref="ClothingData.Area"/> <see cref="FlagsAttribute">FlagEnum</see> detailing every overlap. <br/><see cref="Area.None"/> if they do not overlap (i.e. can be used simultaneously)</returns>
    [MethodImpl(AggressiveInlining)]
    public Area OverlappingArea(ClothingData other) => equipArea & other.equipArea;

    /// <summary>
    /// Information about what area each clothing piece occupy.
    /// <br/><br/>Supports multiple areas (e.g. Dress occupy Torso and Feet, therefore value is 5)
    /// </summary>
    [Flags, Serializable]
    public enum Area : byte
    {
        None = 0,
        Feet = 1,
        Legs = 2,
        Torso = 4,
        Hands = 8,
        Face = 16,
        Head = 32
    } // Values are ordered according to their Z relative offset
}
