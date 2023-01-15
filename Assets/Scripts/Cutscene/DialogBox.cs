using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

/// <summary>
/// Shows awaitable dialog text during <see cref="CutsceneGraph">Cutscenes</see>.
/// </summary>
public class DialogBox : Singleton<DialogBox>
{
    TMP_Text _text;

    private void Awake() => _text = GetComponent<TMP_Text>();


    public static async UniTask SetTextAsync(Actor actor, string text, int delayMs = 50)
    {
        var tmp = Instance._text;
        tmp.SetText(text.Color(actor.textColor));
        var len = tmp.GetParsedText().Length;

        var delayTask = UniTask.Delay(delayMs);

        for (tmp.maxVisibleCharacters = 0; tmp.maxVisibleCharacters < len; tmp.maxVisibleCharacters++)
            await delayTask.Preserve();
    }
}
