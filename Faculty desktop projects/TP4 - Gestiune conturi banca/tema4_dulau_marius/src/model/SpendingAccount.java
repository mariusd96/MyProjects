package model;

public class SpendingAccount extends Account {

	/**
	 * 
	 */
	private static final long serialVersionUID = 9207266701909519430L;
	private double interestRate;//dobanda
	
	public SpendingAccount(int accountId, Person accountHolder, double balance) {
		super(accountId, accountHolder, balance);
		// TODO Auto-generated constructor stub
		interestRate = 0.0;
	}
	
	public double getInterestRate() 
	{
		return interestRate;
	}

	public void setInterestRate() 
	{
		this.interestRate = 0.0;
	}

}
