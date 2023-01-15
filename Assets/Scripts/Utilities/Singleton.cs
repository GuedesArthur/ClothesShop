using System;
using UnityEngine;

/// <summary>
/// <see cref="MonoBehaviour"/> Classes that are only instanced once. Easily referenced by <see cref="Instance"/>
/// </summary>
/// <typeparam name="TSelf">Parent component class type</typeparam>
public abstract class Singleton<TSelf> : MonoBehaviour
    where TSelf : Component
{
    private static readonly object Lock = new();
    private static TSelf _instance;
    
    /// <summary>
    /// Returns the <see cref="_instance">static instance</see> of the <see cref="Singleton{TSelf}">Singleton</see> class.
    /// </summary>
    /// <exception cref="UnityException">Thrown when no component is found when its first called</exception>
    public static TSelf Instance
    {
        get
        {
            lock (Lock)
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<TSelf>()
                            ?? throw new UnityException($"Could not find Singleton Component of type {typeof(TSelf)}");
                    DontDestroyOnLoad(_instance);
                }

                return _instance;
            }
        }
    }
}