package model;
import MyException.MyException;

public class SavingAccount extends Account {
		
	/**
	 * 
	 */
	private static final long serialVersionUID = -6937375404415477390L;
	
	private double minBalance;
	private double interestRate;//dobanda
	private double initialBalance;
	
	public SavingAccount(int accountId, Person accountHolder, double balance) 
	{
		super(accountId, accountHolder, balance);
		this.initialBalance = balance;
		this.minBalance = 1000;
		this.interestRate = 0.5;
	}

	public double getMinBalance() 
	{
		return minBalance;
	}

	public void setMinBalance(double minBalance) 
	{
		this.minBalance = minBalance;
	}

	public double getInterestRate() 
	{
		return interestRate;
	}

	public void setInterestRate(double interestRate) 
	{
		this.interestRate = interestRate;
	}
	
	public double getInitialBalance() 
	{
		return initialBalance;
	}

	public void setInitialBalance() 
	{
		this.initialBalance = this.getBalance();
	}
	
	public void depositMonthlyRate()
	{
		this.deposit(this.getInitialBalance() * this.getInterestRate() / 12);
	}
}
