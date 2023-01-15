using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Runtime.CompilerServices;
using UnityEngine.Events;
using static System.Runtime.CompilerServices.MethodImplOptions;


/// <summary>
/// Contains <see cref="Amount">current funds</see> and support for common monetary operations (<see cref="operator +(Wallet, double)">Add</see>, <see cref="operator -(Wallet, double)">Subtract</see>)
/// <br/><br/>For the current money amount HUD, check: <see cref="WalletUI"/>
/// </summary>
[Serializable]
public class Wallet
{
    public const string Currency = "G$";
    public override string ToString() => $"{Amount:0.00}{Currency}";

    [field: SerializeField]
    public double Amount { get; private set; }
    // NOTE: Monetary amounts are prefered to be stored as a decimal,
    // but, as the type is not serialized by Unity, it would demand a
    // custom propertydrawer. Double will suffice for now.
    // May need to change to decimal in the future.

    public UnityEvent<Wallet> OnChangeValue;

    [MethodImpl(AggressiveInlining)]
    public bool CanAfford(double amount) => Amount >= amount;

    // NOTE: Returns a self reference in order to be able to use "+=" operator.
    // C# should really takes more notes from C++ than from Java sometimes.
    public static Wallet operator +(Wallet wallet, double amount)
    {
        Debug.Assert(amount >= 0, "Cannot add negative funds. Did you mean to subtract them?");

        wallet.Amount += amount;

        wallet.OnChangeValue.Invoke(wallet);
        return wallet;
    }

    //NOTE: Same as + operator's note.
    public static Wallet operator -(Wallet wallet, double amount)
    {
        Debug.Assert(amount >= 0, "Cannot remove negative funds. Did you mean to add them?");

        var remainder = wallet.Amount - amount;

        if (remainder < 0) throw new InsufficientFundsException(amount, wallet.Amount);
        wallet.Amount = remainder;

        wallet.OnChangeValue.Invoke(wallet);
        return wallet;
    }

    /// <summary>
    /// You bit <see cref="cost">more</see> than you <see cref="funds">can chew</see>, dummy. *throws exception*
    /// </summary>
    public class InsufficientFundsException : Exception
    {
        public double cost, funds;
        public InsufficientFundsException(double cost, double funds)
            : base($"Cannot afford {cost:0.00}. Current funds: {funds:0.00}")
                => (this.cost, this.funds) = (cost, funds);

    }
}
