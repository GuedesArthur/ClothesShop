using Swizzler;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour, IControllable
{
    public Wallet wallet;
    public Inventory Inventory;
    public LinkedList<Clothing> EquippedClothing = new();
    public Vector2 velocity;
    public bool IsNude => EquippedClothing.Count == 0;

    private void Awake()
    {
        Controller.controllable = this;
    }

    private void OnDestroy()
    {
        Controller.controllable = null;
    }

    public async void Equip(Clothing clothing)
    {
        var overlaps = EquippedClothing.Where(clothing.Overlaps).ToArray();

        if(overlaps.Length > 0)
        {
            var itemNames = string.Join(", ", overlaps.Select(c => c.ToString()));

            var wantsToRemove = await Popups.Boolean(
                $"Your {clothing.name} overlaps with the following items: {itemNames}." +
                $"\nDo you wish to remove them now?");

            if (!wantsToRemove) return;

            if (Inventory.RemainingSlots < overlaps.Length)
                throw new FullCollectionException("Inventory", Inventory.MaxItems);

            foreach (var c in overlaps)
                Unequip(c);
        }

        EquippedClothing.AddLast(clothing);
    }
    public void Unequip(Clothing clothing)
    {
        Debug.Assert(!Inventory.IsFull, $"Tried unequipping {clothing.name} with a full Inventory!");

        EquippedClothing.Remove(clothing);
        Inventory.Add(clothing);
    }

    void IControllable.OnInput(DirectionInput input)
    {
        transform.position += Vector2.Scale(input, velocity * Time.deltaTime).XY0();
    }
}
