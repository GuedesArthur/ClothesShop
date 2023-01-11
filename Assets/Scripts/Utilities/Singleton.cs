using System;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;

public abstract class Singleton<TSelf> : MonoBehaviour
    where TSelf : Component
{
    private static readonly object Lock = new();
    private static TSelf _instance;
    
    /// <summary>
    /// Returns the static instance of the Singleton class.
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