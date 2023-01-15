using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Popups : Singleton<Popups>
{
    const int StackCapacity = 4;
    public static Stack<GameObject> stack = new (StackCapacity);
    static GameObject parent;
    public ObjectTable PrefabTable;

    private void Awake()
    {
        if (parent != null) Destroy(this);
        parent = gameObject;
    }

    /// <summary>
    /// Creates an awaitable PopUp that is interpreted as a boolean input (Yes button => true, No button => false)
    /// </summary>
    /// <param name="question">Question PopUp text</param>
    /// <returns>Whether the player pressed yes or no.</returns>
    public static async UniTask<bool> Boolean(string question, string trueButtonLabel = "Yes", string falseButtonLabel = "No")
    {
        //throw new NotImplementedException();
        return true;
    }

    /// <summary>
    /// Creates an awaitable PopUp that send a message to player and awaits until he clicks the OK button
    /// </summary>
    /// <param name="message">Message PopUp text</param>
    public static async UniTask Ok(string message, string okButtonLabel = "Ok")
    {
        throw new NotImplementedException();
    }

    public static GameObject Create()
    {
        var obj = Instance.PrefabTable.Instantiate("Default", Instance.transform);
        throw new NotImplementedException();
    }


    public struct Data
    {
        public string title;
        public string content;
        public Button[] buttons;
    }

}

public struct Button
{
    public string label;
    public Action onPress;
}