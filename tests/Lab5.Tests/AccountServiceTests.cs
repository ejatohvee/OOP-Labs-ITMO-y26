using System.Collections.Generic;
using Application.Accounts;
using Infrastructure.DataAccess.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Tests.Mocks;
using Lab5.Models.Accounts;
using Lab5.Models.Operations;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class AccountServiceTests
{
    [Fact]
    public void AddMoneyWhenAccountExistsSuccess()
    {
        // Arrange
        var account = new Account(1, "test", 123, new Balance(0));
        var manager = new CurrentAccountManager();
        manager.Account = account;

        var accounts = new List<Account>()
        {
            account,
        };

        var service = new AccountService(
            new AccountRepositoryMock(accounts),
            manager,
            new HistoryRepositoryMock());

        // Act
        MoneyOperationResult actual = service.DepositMoney(100);

        // Assert
        Assert.IsType<MoneyOperationResult.Success>(actual);
    }

    [Fact]
    public void WithdrawMoneyWhenEnoughMoneySuccess()
    {
        // Arrange
        var account = new Account(1, "test", 123, new Balance(100));
        var manager = new CurrentAccountManager();
        manager.Account = account;

        var accounts = new List<Account>()
        {
            account,
        };

        var service = new AccountService(
            new AccountRepositoryMock(accounts),
            manager,
            new HistoryRepositoryMock());

        // Act
        MoneyOperationResult actual = service.WithdrawMoney(50);

        // Assert
        Assert.IsType<MoneyOperationResult.Success>(actual);
    }

    [Fact]
    public void WithdrawMoneyWhenNotEnoughMoneyFail()
    {
        // Arrange
        var account = new Account(1, "test", 123, new Balance(100));
        var manager = new CurrentAccountManager();
        manager.Account = account;

        var accounts = new List<Account>()
        {
            account,
        };

        var service = new AccountService(
            new AccountRepositoryMock(accounts),
            manager,
            new HistoryRepositoryMock());

        // Act
        MoneyOperationResult actual = service.WithdrawMoney(150);

        // Assert
        Assert.IsType<MoneyOperationResult.NotEnoughMoney>(actual);
    }
}