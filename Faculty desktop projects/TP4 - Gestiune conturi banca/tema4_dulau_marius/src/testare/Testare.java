package testare;

import java.util.*;

import static org.junit.Assert.*;

import org.junit.*;
import org.junit.Test;

import model.*;

public class Testare {

	private Bank b = new Bank();
	private Account a = null;
	
	private static int nrTesteExecutate = 0;
	private static int nrTesteCuSucces = 0;
	
	private static boolean stare;
	
	public Testare()
	{
		System.out.println("Constructor inaintea fiecarui test!");
	}

	@AfterClass
	public static void tearDownAfterClass() throws Exception {
		System.out.println("O singura data dupa terminarea executiei setului de teste din clasa!");
		System.out.println("S-au executat " + nrTesteExecutate + " teste din care "+ nrTesteCuSucces + " au avut succes!");
	}
	
	@Before
	public void setUp() throws Exception {
		System.out.println("Incepe un nou test!");
		nrTesteExecutate++;
	}
	
	@After
	public void tearDown() throws Exception {
		System.out.println("S-a terminat testul curent!");
	}
	
	@Test
	public void test1()
	{
		Person p = new Person("1234567890123", "Maria", "Dan", "Calea Manastur nr. 100");
		b.addPerson(p);
		
		if(b.getMap().containsKey(p)) stare = true;
		else stare = false;
		
		assertTrue(stare);
		nrTesteCuSucces++;
	}
	
	@Test
	public void test2()
	{
		Person p = null;
		b.addPerson(p);
		
		if(b.getMap().containsKey(p)) stare = true;
		else stare = false;
		
		assertTrue(stare);
		nrTesteCuSucces++;
	}
	
	@Test
	public void test3()
	{
		Person p = new Person("1960730260062", "Marius", "Dulau", "Str. Observatorului nr. 34");
		b.addPerson(p);
		Person p2 = b.findPerson("1960730260062");
		
		if(p2 != null) stare = true;
		else stare = false;
		
		assertTrue(stare);
		nrTesteCuSucces++;
	}
	
	@Test
	public void test4()
	{
		Person p = new Person("1960730260062", "Marius", "Dulau", "Str. Observatorului nr. 34");
		b.addPerson(p);
		int id = b.getMaxAccountId() + 1;
		
		if(id == 1) stare = true;
		else stare = false;
		
		assertTrue(stare);
		nrTesteCuSucces++;
	}
	
	@Test
	public void test5()
	{
		Person p = new Person("1960730260062", "Marius", "Dulau", "Str. Observatorului nr. 34");
		b.addPerson(p);
		Account a = new SavingAccount(b.getMaxAccountId() + 1, p, 6000);
		a.deposit(500);
		
		if(a.getBalance() == 6500.0) stare = true;
		else stare = false;
		
		assertTrue(stare);
		nrTesteCuSucces++;
	}
	
	@Test
	public void test6()
	{
		Person p = new Person("1234567890123", "Dana", "Muresan", "Str. Louis Pasteur nr. 54");
		b.addPerson(p);
		b.removePerson(p);
		
		if(b.getMap().containsKey(p)) stare = true;
		else stare = false;
		
		assertFalse(stare);
		nrTesteCuSucces++;
	}
	
	@Test
	public void test7()
	{
		Person p = new Person("1234567890123", "Dana", "Muresan", "Str. Louis Pasteur nr. 54");
		b.addPerson(p);
		Account a = new SpendingAccount(b.getMaxAccountId() + 1, p, 2000.0);
		Account a2 = new SavingAccount(b.getMaxAccountId() + 1, p, 5000.0);
		b.addAccount(a);
		b.addAccount(a2);
		HashSet<Account> accounts = b.readAccounts(p);
		
		if(accounts.size() == 2) stare = true;
		else stare = false;
		
		assertTrue(stare);
		nrTesteCuSucces++;
	}
}