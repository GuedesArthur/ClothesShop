using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Runtime.CompilerServices;

[Serializable]
public class Wallet
{
    public const string Currency = "G$";

    [field: SerializeField]
    public decimal Amount { get; private set; }

    public override string ToString() => $"{Amount:0.00}{Currency}";

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public bool CanAfford(decimal amount) => Amount >= amount;

    public static Wallet operator +(Wallet wallet, decimal amount)
    {
        Debug.Assert(amount >= 0, "Cannot add negative funds. Did you mean to subtract them?");

        wallet.Amount += amount;
        return wallet;
    }

    public static Wallet operator - (Wallet wallet, decimal amount)
    {
        Debug.Assert(amount >= 0, "Cannot remove negative funds. Did you mean to add them?");

        var remainder = wallet.Amount - amount;

        if (remainder < 0) throw new InsufficientFundsException();
        wallet.Amount = remainder;

        return wallet;
    }
    public class InsufficientFundsException : Exception
    {
        
    }
}
