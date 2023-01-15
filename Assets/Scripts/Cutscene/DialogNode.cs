using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

/// <summary>
/// Creates a single dialog <see cref="dialogText">text piece </see>, spoken by a single <see cref="Actor"/> in a <see cref="CutsceneGraph">Cutscene</see>.
/// </summary>
public class DialogNode : CutsceneNode
{
    public Actor actor;
    [TextArea(3, 5)] public string dialogText;
    public override async UniTask ExecuteAsync()
        => await DialogBox.SetTextAsync(actor, dialogText);
}
