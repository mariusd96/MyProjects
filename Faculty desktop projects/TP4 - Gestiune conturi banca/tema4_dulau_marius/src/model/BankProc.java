package model;

import java.util.HashSet;

public interface BankProc {

	/**
	 * @pre p != null
	 * @pre p.getPersonCNP().length() == 13
	 * @post map.contains(p)
	 */
	void addPerson(Person p);
	
	
	/**
	 * @pre cnp.length() == 13
	 * @post p2 != null
	 * @post map.contains(p)
	 */
	Person findPerson(String cnp);
	
	
	/**
	 * @pre map.contains(p)
	 * @post !map.contains(p)
	 */
	void removePerson(Person p);
	
	
	/**
	 * @pre a != null
	 * @pre a.getBalance() >= 0
	 * @post mySet.contains(a)
	 */
	void addAccount(Account a);
	
	/**
	 * @pre a != null
	 * @pre mySet.contains(a)
	 * @post !map.contains(a.getAccountHolder() ,a)
	 */
	void removeAccount(Account a);
	
	
	/**
	 * @pre p != null
	 * @map.contains(p)
	 * @post a != null
	 */
	HashSet<Account> readAccounts(Person p);
	
	
	/**
	 * @pre true
	 * @post nr >= 0
	 */
	int getMaxAccountId();
}