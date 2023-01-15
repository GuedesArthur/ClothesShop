using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using XNode;

/// <summary>
/// Basic <see cref="Node"/> for <see cref="CutsceneGraph"/>.
/// </summary>
[CreateNodeMenu("Cutscene/Node")]
public abstract class CutsceneNode : Node, IAsyncCommand
{
    /// <summary>
    /// Receive <see cref="NodePort">connections</see> from other nodes. Self referencial port.
    /// <br/>If is not connected, graph sees it as <see cref="CutsceneGraph.Root"/>.
    /// </summary>
    [Input(ShowBackingValue.Never)] public CutsceneNode @this;

    /// <summary>
    /// <see cref="NodePort"/> that connects to the following node to be executed in the <see cref="CutsceneGraph"/>.
    /// <br/>If null, ends the Cutscene.
    /// </summary>
    [Output(ShowBackingValue.Always)] public CutsceneNode next;

    public abstract UniTask ExecuteAsync();

    #region XNodeOverrides
    protected override void Init()
    {
        @this = this;

        if(string.IsNullOrEmpty(name))
            name = $"Node #{graph.nodes.Count}";
    }
    public override void OnCreateConnection(NodePort from, NodePort to)
    {
        if (this == from.node)
        {
            if (next != null) next.OnRemoveConnection(Inputs.Single());
            next = to.node as CutsceneNode;
        }
    }
    public override void OnRemoveConnection(NodePort port)
    {
        if (port.direction == NodePort.IO.Output)
            next = null;
    }
    #endregion
}
