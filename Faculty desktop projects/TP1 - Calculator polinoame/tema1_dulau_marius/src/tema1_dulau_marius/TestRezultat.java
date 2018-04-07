package tema1_dulau_marius;

import static org.junit.Assert.*;

import org.junit.*;
import org.junit.Test;

public class TestRezultat {

	private static Polinom f;
	private static Polinom g;
	private static Polinom h;
	private static Polinom r;
	
	private static String p, q, mesaj;
	private static String[] valP, valQ;
	
	private static int nrTesteExecutate = 0;
	private static int nrTesteCuSucces = 0;
	
	private static boolean stare;
	
	public TestRezultat()
	{
		System.out.println("Constructor inaintea fiecarui test!");
		f = new Polinom();
		g = new Polinom();
		
		p = "3X^4+2X^2-4X+5";
		q = "4X^2-1";
		
		p = p.replaceAll("-", "+-"); //inlocuim - cu +- pentru a avea semnul negativ la numere
		p = p.replaceAll("\\s+", ""); // eliminam spatiile ca sa putem desparti mai usor
		q = q.replace("-", "+-");
		q = q.replaceAll("\\s+", "");
		
		valP = p.split("[+]"); //despartim in string dupa +
		valQ = q.split("[+]");
		
		try
		{
			f = (new Logic()).construirePolinom(valP);
			f.sortare();
			f.eliminareGradeMultiple();
			g = (new Logic()).construirePolinom(valQ);
			g.sortare();
			g.eliminareGradeMultiple();
		}catch(MyException ex)
		{
			System.out.println(ex.toString());
		}
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
		h = f.adunaCu(g);
		mesaj = h.toString();
		
		if(mesaj.compareTo("3X^4+6X^2-4X+4") == 0) stare = true;
		else stare = false;
		
		assertTrue(stare);
		nrTesteCuSucces++;
	}
	
	@Test
	public void test2()
	{
		h = f.scadeCu(g);
		mesaj = h.toString();
		
		if(mesaj.compareTo("3X^4-2X^2-4X+6") == 0) stare = true;
		else stare = false;
		
		assertTrue(stare);
		nrTesteCuSucces++;
	}
	
	
	@Test
	public void test3()
	{
		h = g.scadeCu(f);
		mesaj = h.toString();
		
		if(mesaj.compareTo("-3X^4+2X^2+4X-6") == 0) stare = true;
		else stare = false;
		
		assertTrue(stare);
		nrTesteCuSucces++;
	}
	
	@Test
	public void test4()
	{
		h = f.inmultesteCu(g);
		mesaj = h.toString();
		
		if(mesaj.compareTo("12X^6+5X^4-16X^3+18X^2+4X-5") == 0) stare = true;
		else stare = false;
		
		assertTrue(stare);
		nrTesteCuSucces++;
	}
	
	@Test
	public void test5()
	{
		h = f.imparteCu(g);
		mesaj = h.toString();
		
		if(mesaj.compareTo("0,75X^2+0,688") == 0) stare = true;
		else stare = false;
		
		assertTrue(stare);
		nrTesteCuSucces++;
	}
	
	@Test
	public void test6()
	{
		h = g.imparteCu(f);
		Polinom aux = h.inmultesteCu(f);
		r = g.scadeCu(aux);
		mesaj = r.toString();
		
		if(mesaj.compareTo("4X^2-1") == 0) stare = true;
		else stare = false;
		
		assertTrue(stare);
		nrTesteCuSucces++;
	}
	
	@Test
	public void test7()
	{
		h = f.deriveaza();
		mesaj = h.toString();
		
		if(mesaj.compareTo("12X^3+4X-4") == 0) stare = true;
		else stare = false;
		
		assertTrue(stare);
		nrTesteCuSucces++;
	}
	
	@Test
	public void test8()
	{
		h = g.deriveaza();
		mesaj = h.toString();
		
		if(mesaj.compareTo("8X") == 0) stare = true;
		else stare = false;
		
		assertTrue(stare);
		nrTesteCuSucces++;
	}
	
	@Test
	public void test9()
	{
		h = f.integreaza();
		mesaj = h.toString();
		
		if(mesaj.compareTo("0,6X^5+0,667X^3-2X^2+5X") == 0) stare = true;
		else stare = false;
		
		assertTrue(stare);
		nrTesteCuSucces++;
	}
	
	@Test
	public void test10()
	{
		h = g.integreaza();
		mesaj = h.toString();
		
		if(mesaj.compareTo("1,333X^3-X") == 0) stare = true;
		else stare = false;
		
		assertTrue(stare);
		nrTesteCuSucces++;
	}
}
