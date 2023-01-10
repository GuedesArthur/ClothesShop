using UnityEngine;
using System;

[CreateAssetMenu(fileName ="Clothing")]
public class Clothing : ScriptableObject
{
    [SerializeField] bool hasFrontRVariant, hasBackRVariant;
    public bool hasCustomColors;
    public Area equipArea = Area.Torso;
    public Color defaultColor = Color.white;
    public decimal price = 123.45M;
    public Vector2 localPosition;

    [Flags, Serializable]
    public enum Area // System.Flags due to possibility of a piece of clothing occupying multiple areas (i.e. a dress)
    {
        None = 0, // Infinite pieces of clothing with area None can be equipped at any time!
        Torso = 1,
        Legs = 2,
        Feet = 4,
        Hands = 8, // Player may equip two Hands clothing, one for each hand. First left, second right.
        DoubleHands = 16 // DoubleHands remove any Hand clothing being currently held.
    }
}
