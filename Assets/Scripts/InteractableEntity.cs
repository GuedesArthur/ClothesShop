using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An Entity that can be <see cref="IInteractable">interacted</see> when near the player
/// </summary>
public abstract class InteractableEntity : MonoBehaviour, IInteractable
{
    public static LinkedList<InteractableEntity> All = new();

    /// <returns>Nearest <see cref="InteractableEntity">Entity</see> to given position</returns>
    public static InteractableEntity Nearest(Vector2 position)
        => All
            .MinObj(obj => Vector2.Distance(obj.transform.position, position));
    
    private void OnEnable()
        => All.AddLast(this);

    private void OnDisable()
        => All.Remove(this);
    public abstract void OnInteraction(Player player);
}
