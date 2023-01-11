using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory")]
public class Inventory : ScriptableObject, IReadOnlyCollection<Clothing>
{
    public const int MaxItems = 40;

    public List<Clothing> ClothingList;
    public bool IsFull => ClothingList.Count >= 40;
    public int Count => ClothingList.Count;
    public int RemainingSlots => MaxItems - ClothingList.Count;

    public void Add(Clothing clothing)
    {
        if (IsFull) throw new FullCollectionException(name, MaxItems);

        ClothingList.Add(clothing);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IEnumerable<Clothing> FilterByArea(Clothing.Area area)
        => ClothingList.Where(c => c.equipArea == area);
    public IEnumerable<Clothing> FilterByName(string pattern)
    {
        var regex = new Regex(pattern, RegexOptions.IgnoreCase);

        return ClothingList.Where(c => regex.IsMatch(c.name));
    }

    public IEnumerator<Clothing> GetEnumerator() => ClothingList.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => ClothingList.GetEnumerator();
}
