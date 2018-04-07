package tema1_dulau_marius;

import java.util.*;

public class Test {

	private static int pozitieX(String sir)
	{
		for(int i = 0; i < sir.length(); i++)
		{
			if(sir.substring(i, i + 1).compareTo("x") == 0) 
			{
				return i;
			}
		}
		return -1;
	}
	
	private static Polinom construirePolinom(String[] valX)
	{
		Monom monomX;
		Polinom polinomX = new Polinom();
		
		for(int i = 0; i < valX.length; i++)
		{
			if(valX[i].length() != 0)
			{
				monomX = new Monom();
				int pozX = pozitieX(valX[i]);
			
				if(pozX > -1)
				{
					if(valX[i].substring(pozX, pozX + 1).compareTo("x") == 0 && pozX == valX[i].length() - 1)
					{
						valX[i] = valX[i].replace("x", "x^1");
					}
				}
			
				if(pozX == -1)
				{
					monomX.setCoeficient(Double.parseDouble(valX[i]));
					monomX.setGrad(0);
				}
				else if(pozX == 0)
				{
					monomX.setCoeficient(1);
					monomX.setGrad(Integer.parseInt(valX[i].substring(2, valX[i].length())));
				}
				else if(pozX == 1 && valX[i].substring(0, 1).compareTo("-") == 0)
				{
					monomX.setCoeficient(-1);
					monomX.setGrad(Integer.parseInt(valX[i].substring(3, valX[i].length())));
				}
				else
				{
					monomX.setCoeficient(Double.parseDouble(valX[i].substring(0, pozX)));
					monomX.setGrad(Integer.parseInt(valX[i].substring(pozX + 2, valX[i].length())));
				}
			
				//System.out.println(monomX.getCoeficient() + " " + monomX.getGrad());
				polinomX.adauga(monomX);
			}
		}
		
		return polinomX;
	}
	
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Polinom polinomP = new Polinom();
		Polinom polinomQ = new Polinom();
		
		String p, q = null;
		String[] valP, valQ;
		
		Scanner citire = new Scanner(System.in);
		
		System.out.print("P(x) = ");
		p = citire.nextLine();
		p = p.toLowerCase();
		
		System.out.print("Q(x) = ");
		q = citire.nextLine();
		q = q.toLowerCase();
		
		citire.close();
		
		p = p.replaceAll("-", "+-"); //inlocuim - cu +- pentru a avea semnul negativ la numere
		p = p.replaceAll("\\s+", ""); // eliminam spatiile ca sa putem desparti mai usor
		q = q.replace("-", "+-");
		q = q.replaceAll("\\s+", "");
		
		//System.out.println("P = " + p);
		//System.out.println("Q = " + q);
		
		valP = p.split("[+]"); //despartim in string dupa +
		valQ = q.split("[+]");
		
		
		polinomP = construirePolinom(valP);
		polinomP.sortare();
		polinomP.eliminareGradeMultiple();
		//polinomP.afisare();
		polinomQ = construirePolinom(valQ);
		polinomQ.sortare();
		polinomQ.eliminareGradeMultiple();
		//polinomQ.afisare();
		
		Polinom polinomR;
		polinomR = polinomP.adunaCu(polinomQ);
		System.out.print("Suma : ");
		polinomR.eliminareGradeMultiple();
		polinomR.toString();
		polinomP.toString();
		polinomQ.toString();
		
		polinomR = polinomP.scadeCu(polinomQ);
		System.out.print("P - Q : ");
		polinomR.toString();
		polinomP.toString();
		polinomQ.toString();
		
		polinomR = polinomQ.scadeCu(polinomP);
		System.out.print("Q - P : ");
		polinomR.toString();
		polinomP.toString();
		polinomQ.toString();
		
		polinomR = polinomP.deriveaza();
		System.out.print("P' : ");
		polinomR.toString();
		polinomP.toString();
		polinomQ.toString();
		
		polinomR = polinomQ.deriveaza();
		System.out.print("Q' : ");
		polinomR.toString();
		polinomP.toString();
		polinomQ.toString();
		
		polinomR = polinomP.integreaza();
		System.out.print("P integrat : ");
		polinomR.toString();
		polinomP.toString();
		polinomQ.toString();
		
		polinomR = polinomQ.integreaza();
		System.out.print("Q integrat : ");
		polinomR.toString();
		polinomP.toString();
		polinomQ.toString();
		
		polinomR = polinomP.inmultesteCu(polinomQ);
		System.out.print("Produs : ");
		polinomR.toString();
		polinomP.toString();
		polinomQ.toString();
		
		polinomR = polinomP.imparteCu(polinomQ);
		System.out.print("Impartire : ");
		polinomR.eliminareGradeMultiple();
		polinomR.toString();
		polinomP.toString();
		polinomQ.toString();
	}

}
