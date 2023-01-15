using UnityEngine;

/// <summary>
/// <see cref="InteractableEntity">Entity</see> that sells you its <see cref="ClothingData">clothing piece</see> upon <see cref="OnInteraction(Player)">interaction</see>.
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class ClothingStand : InteractableEntity
{ 
    [SerializeField] ClothingData clothing;

#if UNITY_EDITOR
    private void OnValidate()
        => GetComponent<SpriteRenderer>().sprite = clothing.Icon;
#endif

    private void Awake()
        => GetComponent<SpriteRenderer>().sprite = clothing.Icon;
    public override void OnInteraction(Player player)
        => player.Buy(clothing);
}
