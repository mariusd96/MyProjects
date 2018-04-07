package model;

public class Observer {
	
	SavingAccount a;
	
	public Observer(SavingAccount b)
	{
		this.a = b;
		this.a.getAccountHolder().attach(this);
	}
	
	public void update()
	{
		a.depositMonthlyRate();
	}

}
