using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using XNode;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using System.Threading;

/// <summary>
/// NodeGraph containing an awaitable dialog exchaging Cutscene between various <see cref="Actor">Actors</see>.
/// </summary>
[CreateAssetMenu]
public class CutsceneGraph : NodeGraph, IAsyncCommand
{
    [SerializeField] CutsceneNode _root;
    CutsceneNode Root // Root is the first parentless node.
        => _root != null
            ? _root
            : _root = nodes.Cast<CutsceneNode>().First(n => n.@this == null);

    /// <summary>
    /// Starts Cutscene.
    /// </summary>
    public async UniTask ExecuteAsync()
    {
        Debug.Log($"Cutscene {name} started!");

        CancellationTokenSource cts = new ();
        var onActionButton = Controller.OnActionButtonPress.OnInvokeAsync(cts.Token);

        for(var node = Root; node.next != null; node = node.next)
        {
            await node.ExecuteAsync();
            await onActionButton.Preserve();
        }
        Debug.Log($"Cutscene {name} ended!");
    }    
}
