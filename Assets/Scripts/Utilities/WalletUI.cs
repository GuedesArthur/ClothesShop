using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class WalletUI : MonoBehaviour
{
    TMP_Text _text;
    public Player player;
    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        OnChange(player.wallet);
    }

    private void OnEnable() => player.wallet.OnChangeValue.AddListener(OnChange);
    private void OnDisable() => player.wallet.OnChangeValue.RemoveListener(OnChange);
    void OnChange(Wallet wallet) => _text.SetText(wallet.ToString());
}
