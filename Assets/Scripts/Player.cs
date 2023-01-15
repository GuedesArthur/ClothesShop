using Cysharp.Threading.Tasks;
using Swizzler;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class Player : MonoBehaviour, IControllable
{
    public Wallet wallet;
    public Inventory Inventory;
    CardinalAngleSprite baseSprite;
    public LinkedList<ClothingSprite> EquippedClothing = new();
    public Vector2 velocity;
    [SerializeField] CardinalAngles _angle;
    CardinalAngles Angle
    {
        get => _angle;
        set
        {
            if (value == _angle) return;

            baseSprite.SimpleAngle = value;
            foreach (var cs in EquippedClothing)
                cs.SimpleAngle = value;
            _angle = value;
        }
    }
    public bool IsNude => EquippedClothing.Count == 0;

    private void Awake()
    {
        baseSprite = GetComponent<CardinalAngleSprite>();
    }

    private void OnEnable() => Controller.SetControllable(this);
    private void OnDisable() => Controller.SetControllable(null);

    public async void Buy(ClothingData clothing)
    {
        try
        {
            wallet -= clothing.price;
        }
        catch(Wallet.InsufficientFundsException)
        {
            Debug.Log("Cannot afford!");
            return;
        }

        Inventory.Add(clothing);
        await Equip(clothing);
    }
    public async UniTask Equip(ClothingData clothing)
    {
        var overlaps = EquippedClothing
            .Where(c => clothing.Overlaps(c)).ToArray();

        if(overlaps.Length > 0)
        {
            var itemNames = string.Join(", ", overlaps.Select(c => c.Clothing.name));

            var wantsToRemove = await Popups.Boolean(
                $"Your {clothing.name} overlaps with the following items: {itemNames}." +
                $"\nDo you wish to remove them now?");

            if (!wantsToRemove) return;

            if (Inventory.RemainingSlots < overlaps.Length)
                throw new FullCollectionException("Inventory", Inventory.MaxItems);

            foreach (var c in overlaps)
                Unequip(c);
        }

        var cloth = ClothingSprite.Create(clothing, transform);
        EquippedClothing.AddLast(cloth);
    }

    public void Unequip(ClothingData clothing) => Unequip(EquippedClothing.Single(cs => clothing == cs));
    public void Unequip(ClothingSprite clothingSprite)
    {
        Debug.Assert(!Inventory.IsFull, $"Tried unequipping {clothingSprite.Clothing.name} with a full Inventory!");

        EquippedClothing.Remove(clothingSprite);
        Destroy(clothingSprite.gameObject);
        Inventory.Add(clothingSprite);
    }
    void IControllable.OnDirectionalInput(DirectionInput input)
    {
        if(input.isDead) return;

        transform.position += Vector2.Scale(input, velocity * Time.deltaTime).XYY();
        Angle = input.cardinalAngle;
    }

    public void OnActionButtonPress()
        => InteractableEntity.Nearest(transform.position)
            .OnInteraction(this);
}
