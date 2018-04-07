package tema1_dulau_marius;

import java.util.*;

public class Logic {
	
	public boolean verifSir(String sir) throws MyException
	{
		String caractere = "X^1234567890+-";
		
		for(int j = 0; j < sir.length(); j++)
		{
			if(!caractere.contains(sir.substring(j, j + 1)))
			{
				throw new MyException("Polinom introdus incorect. Scrieti polimomul sub forma 3X^4+2X^3-X+2");
			}
		}
		
		return true;
	}
	
	public int pozitieX(String sir)
	{
		for(int i = 0; i < sir.length(); i++)
		{
			if(sir.substring(i, i + 1).compareTo("X") == 0) 
			{
				return i;
			}
		}
		
		return -1;
	}
	
	public Polinom construirePolinom(String[] valX) throws MyException
	{
		Monom monomX;
		Polinom polinomX = new Polinom();
		
		for(int i = 0; i < valX.length; i++)
		{
			if(valX[i].length() != 0 && verifSir(valX[i]) == true)
			{				
				monomX = new Monom();
				int pozX = pozitieX(valX[i]);
			
				if(pozX > -1)
				{
					if(valX[i].substring(pozX, pozX + 1).compareTo("X") == 0 && pozX == valX[i].length() - 1)
					{
						valX[i] = valX[i].replace("X", "X^1");
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
			
				polinomX.adauga(monomX);
			}
		}
		
		return polinomX;
	}

}
