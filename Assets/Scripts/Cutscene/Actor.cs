using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An actor in a <seealso cref="CutsceneNode"/>. Contains all the information needed about who's speaking each dialog.
/// </summary>
[CreateAssetMenu(menuName ="Cutscene/Actor")]
public class Actor : ScriptableObject
{
    public Color textColor;
}
