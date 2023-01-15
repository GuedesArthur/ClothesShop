using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using UnityEngine;

/// <summary>
/// Contains Items bought by the <see cref="Player"/>
/// </summary>
[CreateAssetMenu(menuName = "Inventory")]
public class Inventory : ScriptableObject, IReadOnlyCollection<ClothingData>
{
    public const int MaxItems = 40;

    public List<ClothingData> ClothingList;
    public bool IsFull => ClothingList.Count >= 40;
    public int Count => ClothingList.Count;
    public int RemainingSlots => MaxItems - ClothingList.Count;

    public void Add(ClothingData clothing)
    {
        if (IsFull) throw new FullCollectionException(name, MaxItems);

        ClothingList.Add(clothing);
    }

    /// <returns><see cref="IEnumerable{T}">IEnumerable</see> containg all <see cref="ClothingData">clothing</see> pieces of the given <see cref="ClothingData.Area">Area</see></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public IEnumerable<ClothingData> FilterByArea(ClothingData.Area area)
        => ClothingList.Where(c => c.equipArea == area);

    /// <returns><see cref="IEnumerable{T}">IEnumerable</see> containg all <see cref="ClothingData">clothing</see> pieces that match the given <see cref="Regex"/> pattern</returns>
    public IEnumerable<ClothingData> FilterByName(string pattern)
    {
        var regex = new Regex(pattern, RegexOptions.IgnoreCase);

        return ClothingList.Where(c => regex.IsMatch(c.name));
    }

    public IEnumerator<ClothingData> GetEnumerator() => ClothingList.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => ClothingList.GetEnumerator();
}
