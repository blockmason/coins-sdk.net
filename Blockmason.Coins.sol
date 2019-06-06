pragma solidity ^0.5.8;


contract Coins {
  mapping (uint256 => uint256) private balances;
  uint256 private supplyAmount;
  address private authority;

  constructor() public {
    authority = msg.sender;
  }

  function supply() public view returns (uint256 amount) {
    return supplyAmount;
  }

  function balance(uint256 holder) public view returns (uint256 amount) {
    return balances[holder];
  }

  function mint(uint256 holder, uint256 amount) public {
    require(msg.sender == authority);
    require(balances[holder] < balances[holder] + amount);
    require(supplyAmount < supplyAmount + amount);

    supplyAmount += amount;
    balances[holder] += amount;
  }

  function burn(uint256 holder, uint256 amount) public {
    require(msg.sender == authority);
    require(balances[holder] - amount < balances[holder]);
    require(supplyAmount - amount < supplyAmount);

    balances[holder] -= amount;
    supplyAmount -= amount;
  }

  function transfer(uint256 from, uint256 to, uint256 amount) public {
    require(msg.sender == authority);
    require(balances[from] - amount < balances[from]);
    require(balances[to] < balances[to] + amount);

    balances[from] -= amount;
    balances[to] += amount;
  }
}
