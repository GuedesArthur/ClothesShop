using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A sprite renderer that has sprites for each <see cref="CardinalAngles">CardinalAngle</see>
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class CardinalAngleSprite : MonoBehaviour
{
    [SerializeField] protected Sprite[] _sprites = new Sprite[8];
    protected SpriteRenderer spriteRenderer;

    [SerializeField] CardinalAngles _simpleAngle;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = _sprites[0];
    }
    
    public CardinalAngles SimpleAngle
    {
        get => _simpleAngle;
        set
        {
            if (value == _simpleAngle) return;

            spriteRenderer.sprite = _sprites[(int)value];
            _simpleAngle = value;
        }
    }

}
