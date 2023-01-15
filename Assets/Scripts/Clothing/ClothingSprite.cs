using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Clothing piece being worn by the <see cref="Player"/>.
/// <br/><br/>Not to be mistaken by <see cref="ClothingData"/> and <see cref="ClothingStand"/> (where you buy a piece upon interacting)
/// </summary>
public class ClothingSprite : CardinalAngleSprite
{
    public static ClothingSprite Create(ClothingData clothing, Transform parent)
    {
        var obj = new GameObject(clothing.name);
        obj.transform.parent = parent;
        obj.transform.localPosition = Vector3.zero;

        var sprite = obj.AddComponent<ClothingSprite>();
        sprite.Clothing = clothing;
        return sprite;
    }

    [SerializeField] ClothingData _clothing;
    public ClothingData Clothing
    {
        get => _clothing;
        set
        {
            if (_clothing == value) return;

            // Sets Z-Depth according to its equip area (higher in value -> closer to screen)
            transform.localPosition += new Vector3(0f,0f, (int)value.equipArea * -0.0001f);

            value.Sprites.CopyTo(_sprites, 0);
            _clothing = value;
        }
    }

    public static implicit operator ClothingData(ClothingSprite sprite)
        => sprite._clothing;
}
