package model;

import java.io.Serializable;

import MyException.MyException;

public class Account implements Serializable {
	
	/**
	 * 
	 */
	private static final long serialVersionUID = 8963778559062658267L;
	
	private int accountId;
	private Person accountHolder;
	private double balance;//sold bancar
	
	public Account(int accountId, Person accountHolder, double balance) 
	{
		this.accountId = accountId;
		this.accountHolder = accountHolder;
		this.accountHolder.notifyAllObservers();
		this.balance = balance;
	}

	public int getAccountId() 
	{
		return accountId;
	}

	public void setAccountId(int accountId) 
	{
		this.accountId = accountId;
	}

	public Person getAccountHolder() 
	{
		return accountHolder;
	}

	public void setAccountHolder(Person accountHolder) 
	{
		this.accountHolder = accountHolder;
	}

	public double getBalance() 
	{
		return balance;
	}

	public void setBalance(double balance) 
	{
		this.balance = balance;
	}
	
	//depunere numerar
	public void deposit(double sum)
	{
		this.balance = this.balance + sum;
	}
	
	//retragere numerar	
	public void withdraw(double sum) throws MyException
	{
		if(this.balance - sum > 0.001) this.balance = this.balance - sum;
		else throw new MyException("Sum > Balance");
	}

	@Override
	public String toString() 
	{
		return "Account [accountId=" + accountId + ", accountHolder=" + accountHolder + ", balance=" + balance + "]";
	}
}
