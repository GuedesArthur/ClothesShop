using UnityEngine;
using System;
using System.Runtime.CompilerServices;
using static System.Runtime.CompilerServices.MethodImplOptions;

[CreateAssetMenu(fileName ="Clothing", menuName ="Items/Clothing")]
public class Clothing : ScriptableObject
{
    [SerializeField] bool hasFrontRVariant, hasBackRVariant;
    public bool hasCustomColors;
    public Area equipArea = Area.Torso;
    public Color defaultColor = Color.white;
    public decimal price = 123.45M;
    public Vector2 localPosition;
    public Sprite[] Sprites = new Sprite[4];

    [MethodImpl(AggressiveInlining)]
    public bool Overlaps(Clothing other) => OverlappingArea(other) == Area.None;

    [MethodImpl(AggressiveInlining)]
    public Area OverlappingArea(Clothing other) => equipArea & other.equipArea;

    [Flags, Serializable]
    public enum Area : byte// System.Flags due to possibility of a piece of clothing occupying multiple areas (i.e. a dress)
    {
        None = 0,
        Torso = 1,
        Legs = 2,
        Feet = 4,
        Hands = 8
    }
}
