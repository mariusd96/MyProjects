package model;

import java.io.Serializable;
import java.util.*;
import javax.swing.JTable;
import java.lang.reflect.*;

public class Bank implements BankProc, Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	private static Map<Person, Set<Account>> map;
	
	public Bank()
	{
		map = new HashMap<Person, Set<Account>>();
	}
	
	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result + ((map == null) ? 0 : map.hashCode());
		return result;
	}

	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		Bank other = (Bank) obj;
		if (map == null) {
			if (other.map != null)
				return false;
		} else if (!map.equals(other.map))
			return false;
		return true;
	}
	
	@Override
	public void addPerson(Person p) {
		// TODO Auto-generated method stub
		assert p != null : "Parameter is null!";
		assert p.getPersonCNP().length() == 13 : "CNP must have 13 digits";
		
		map.put(p, null);
		
		assert map.containsKey(p) : "Map does not contain your parameter";
	}

	@Override
	public Person findPerson(String cnp) {
		// TODO Auto-generated method stub
		assert cnp.length() == 13 : "CNP must have 13 digits";
		
		Person p2 = null;
		
		for(Person p : map.keySet())
		{
			if(p.getPersonCNP().compareTo(cnp) == 0)
			{
				p2 = p;
				break;
			}
		}
		
		assert map.containsKey(p2) : "Map does not contain person with your given CNP";
		assert p2 != null : "Map contains null object";
		
		return p2;
	}
	
	@Override
	public void removePerson(Person p) {
		// TODO Auto-generated method stub
		assert map.containsKey(p) : "Map does not contain parameter p";
		map.remove(p);
		assert !map.containsKey(p) : "Map contain parameter p";
	}

	@Override
	public void addAccount(Account a) {
		// TODO Auto-generated method stub
		assert a != null : "Your account is null";
		assert a.getBalance() >= 0 : "Balance must be positive";
		
		Set<Account> mySet = map.get(a.getAccountHolder());
		if(mySet == null) 
		{
			mySet = new HashSet<Account>();
			map.put(a.getAccountHolder(), mySet);
		}
		mySet.add(a);
		
		assert mySet.contains(a) : "Account is not inserted!";
	}

	@Override
	public void removeAccount(Account a) {
		// TODO Auto-generated method stub
		assert a != null : "Account is null";
		
		Set<Account> mySet = map.get(a.getAccountHolder());
		assert mySet.contains(a) : "Map contain the parameter account";
		
		mySet.remove(a);
		
		assert !mySet.contains(a) : "Map still contain the parameter account";
	}

	@Override
	public HashSet<Account> readAccounts(Person p) {
		// TODO Auto-generated method stub
		assert p != null : "Parameter is null!";
		assert map.containsKey(p) : "Map does not contain Person p";
		
		HashSet<Account> a = null;
		
		for(Person p2 : map.keySet())
		{
			if(p2.equals(p)) a = (HashSet<Account>) map.get(p);
		}
	
		return a;
	}

	@Override
	public int getMaxAccountId() {
		// TODO Auto-generated method stub
		int nr = 0;
		
		for(Person p : map.keySet())
		{
			HashSet<Account> a = (HashSet<Account>) map.get(p);
			if(a != null)
			{
				for(Account i : a)
				{
					if(i.getAccountId() > nr) nr = i.getAccountId();
				}
			}
		}
		
		assert nr >= 0 : "Negative id";
		
		return nr;
	}

	public static JTable createTable(Object obj)
	{
		int nrLinii = 0, nrColoane = 0;
		if(obj instanceof Person) nrColoane = 4;
		else if(obj instanceof Account) nrColoane =  5;
		
		if(obj instanceof Person)  nrLinii = map.keySet().size();
		else if(obj instanceof Account)
		{
			for(Person p : map.keySet())
			{
				if(map.get(p) != null) nrLinii += map.get(p).size();
			}
		}
		
		Object[] columnNames = new Object[nrColoane];
		Object[][] rowData = new Object[nrLinii][nrColoane];
		
		int index = 0;
		if(obj instanceof Person)
		{
			columnNames[index++] = "CNP";
			columnNames[index++] = "First Name";
			columnNames[index++] = "Last Name";
			columnNames[index++] = "Address";
		}
		else if(obj instanceof Account)
		{
			columnNames[index++] = "Account Id";
			columnNames[index++] = "Holder CNP";
			columnNames[index++] = "Balance";
			columnNames[index++] = "Account Type";
			columnNames[index++] = "Interest Rate";
		}
		
		index = 0;
		for(Person p : map.keySet())
		{			
			if(obj instanceof Person)
			{
				rowData[index][0] = p.getPersonCNP();
				rowData[index][1] = p.getFirstName();
				rowData[index][2] = p.getLastName();
				rowData[index][3] = p.getAddress();
				index++;
			}
			else if(obj instanceof Account)
			{				
				HashSet<Account> a = (HashSet<Account>)map.get(p);
				if(a != null)
				{
					for(Account i : a)
					{
						rowData[index][0] = i.getAccountId(); 
						rowData[index][1] = i.getAccountHolder().getPersonCNP();
						rowData[index][2] = i.getBalance();
						if(i instanceof SavingAccount) 
						{
							rowData[index][3] = "Saving Account";
							rowData[index][4] = ((SavingAccount) i).getInterestRate();
						}
						else if(i instanceof SpendingAccount) 
						{
							rowData[index][3] = "Spending Account";
							rowData[index][4] = ((SpendingAccount) i).getInterestRate();
						}
						index++;
					}
				}
			}
		}
		
		JTable table = new JTable(rowData, columnNames);
		return table;
	}
	
	public Map getMap()
	{
		return this.map;
	}
	
	public void setMap(Map map)
	{
		this.map = map;
	}
}
