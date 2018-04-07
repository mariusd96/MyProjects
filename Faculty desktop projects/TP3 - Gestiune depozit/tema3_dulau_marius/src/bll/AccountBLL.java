package bll;

import java.util.NoSuchElementException;

import dao.AccountDAO;
import dao.ReflectionDAO;
import model.Account;

public class AccountBLL {

	public AccountBLL()
	{
		
	}
	
	public Object findByUser(Account a, Object[] campuri)
	{
		Object o = ReflectionDAO.select(a, campuri);
		if(o == null)
		{
			throw new NoSuchElementException("Account not found");
		}
		
		return o;
	}
	
	public boolean userExist(Account a, Object[] campuri) throws Exception
	{
		Object o = ReflectionDAO.select(a, campuri);
		if(o != null)
		{
			throw new Exception("Account exist");
		}
		
		return false;
	}
	
	public void insertAccount(Account a)
	{
		ReflectionDAO.insert(a);
	}
	
	public void deleteAccount(Account a)
	{
		ReflectionDAO.delete(a);
	}
	
}
