# Coins SDK for .NET

This library provides a virtual currency backed by a [Blockmason Link][1]
project.

## Installing

Add the following line to your project file:

```
<PackageReference Include="Blockmason.Coins" Version="1.0.0"/>
```

[Sign up][2] for Blockmason Link and copy/paste the contents of
**Blockmason.Coins.sol** into your project.

## Usage

Import this library:

```
using Blockmason.Coins;
```

Create a treasury to manage your coins:

```
// Replace with your Link project's Client ID and Client Secret
Treasury treasury = new Treasury("<client-id>", "<client-secret>");
```

Mint some coins for one of your users:

```
// This library just needs a numeric user ID to keep track of who owns what
Coin coin = await treasury.Mint(userId, amount);
```

Burn coins from the supply:

```
await treasury.Burn(userId, amount);
```

Transfer a stack of coins between two users:

```
await treasury.Transfer(coin, toUserId);
```

A `Coin` has a `Holder` and an `Amount`.

[1]: https://blockmason.link/
[2]: https://mason.link/sign-up
