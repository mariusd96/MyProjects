package tema1_dulau_marius;

import java.util.*;

import javax.swing.JOptionPane;

import java.text.DecimalFormat;

public class Polinom {

	public ArrayList<Monom> listaMonoame;
	private DecimalFormat df;
	
	public Polinom()
	{
		listaMonoame = new ArrayList<Monom>();
		df = new DecimalFormat();
		df.setDecimalSeparatorAlwaysShown(false);
	}
	
	public void adauga(Monom a)
	{
		listaMonoame.add(a);
	}
	
	public Polinom adunaCu(Polinom b)
	{
		Polinom a = this;
		Polinom c = new Polinom();
		
		a.listaMonoame.forEach(elem -> c.adauga(elem));
		b.listaMonoame.forEach(elem -> c.adauga(elem));
		
		c.sortare();
		c.eliminareGradeMultiple();
		
		return c;
	}
	
	public Polinom scadeCu(Polinom b)
	{
		Polinom a = this;
		Polinom c = new Polinom();
		
		a.listaMonoame.forEach(elem -> c.adauga(elem));
		for(Monom i: b.listaMonoame)
		{
			Monom b2 = new Monom();
			b2.setCoeficient((-1) * i.getCoeficient());
			b2.setGrad(i.getGrad());
			c.adauga(b2);
		}
		
		c.sortare();
		c.eliminareGradeMultiple();
		
		return c;
	}
	
	public Polinom inmultesteCu(Polinom b)
	{
		Polinom a = this;
		Polinom c = new Polinom();
		
		for(Monom i: a.listaMonoame)
		{
			for(Monom j: b.listaMonoame)
			{
				Monom aux = new Monom();
				aux.setCoeficient(i.getCoeficient() * j.getCoeficient());
				aux.setGrad(i.getGrad() + j.getGrad());
				c.adauga(aux);
			}
		}
		
		c.sortare();
		c.eliminareGradeMultiple();
		
		return c;
	}
	
	public Polinom imparteCu(Polinom i)
	{
		Polinom d = this;
		Polinom c = new Polinom();
		
		while(d.gradMax() >= i.gradMax())
		{
			Monom monomAux = new Monom();
			monomAux.setCoeficient(d.coefGradMax() / i.coefGradMax());
			monomAux.setGrad(d.gradMax() - i.gradMax());
			
			c.adauga(monomAux);
			Polinom polinomAux = new Polinom();
			polinomAux.adauga(monomAux);
			
			Polinom polinomAux2 = polinomAux.inmultesteCu(i);
			
			d = d.scadeCu(polinomAux2);
			d.sortare();
			d.eliminareGradeMultiple();
		}
		
		c.sortare();
		c.eliminareGradeMultiple();
		
		return c;
	}
	
	public Polinom deriveaza()
	{
		Polinom c = new Polinom();
		
		for(Monom i: this.listaMonoame)
		{
			Monom aux = new Monom();
			aux.setCoeficient(i.getCoeficient() * i.getGrad());
			aux.setGrad(i.getGrad() - 1);
			c.adauga(aux);
		}
		
		//c.sortare();
		//c.eliminareGradeMultiple();
		
		return c;
	}
	
	public Polinom integreaza()
	{
		Polinom c = new Polinom();
		
		for(Monom i : this.listaMonoame)
		{
			Monom aux = new Monom();
			aux.setGrad(i.getGrad() + 1);
			aux.setCoeficient(i.getCoeficient() / (i.getGrad() + 1));
			c.adauga(aux);
		}
		
		//c.sortare();
		//c.eliminareGradeMultiple();
		return c;
	}
	
	public String toString()
	{
		boolean inceput = true;
		String mesaj = "";
		
		for(int i = 0; i < listaMonoame.size(); i++)
		{
			Monom a = listaMonoame.get(i);
			if(Math.abs(a.getCoeficient()) != 1 && inceput == true) 
			{
				mesaj = mesaj + df.format(a.getCoeficient());
			}
			else if(a.getCoeficient() != 1 && a.getCoeficient() > 0 && inceput == false) 
			{
				mesaj = mesaj + "+" + df.format(a.getCoeficient());
			}
			else if(a.getCoeficient() != -1 && a.getCoeficient() < 0) 
			{
				mesaj = mesaj + df.format(a.getCoeficient());
			}
			else if(a.getCoeficient() == -1) 
			{
				if(a.getGrad() == 0) mesaj = mesaj + "-1";
				else mesaj = mesaj + "-";
			}
			else if(a.getCoeficient() == 1) 
			{
				if(a.getGrad() == 0)
				{
					if(inceput == true) mesaj = mesaj + "1";
					else mesaj = mesaj + "+1";
				}
				else
				{
					if(inceput == true) mesaj = mesaj + "";
					else mesaj = mesaj + "+";
				}
			}
			
			if(a.getGrad() >= 2) 
			{
				mesaj = mesaj + "X^" + a.getGrad();
			}
			else if(a.getGrad() == 1) 
			{
				mesaj = mesaj + "X";
			}
			else if(a.getGrad() == 0) 
			{
				mesaj = mesaj + "";
			}
			
			inceput = false;
		}
		
		return mesaj;
	}
	
	public void sortare()
	{		
		Collections.sort(this.listaMonoame, new Comparator<Monom>(){
			@Override
			public int compare(Monom a, Monom b)
			{
				if(a.getGrad() == b.getGrad()) return 0;
				return a.getGrad() > b.getGrad() ? -1:1;
			}
		});
	}
	
	public void eliminareGradeMultiple()
	{
		for(int i = 0 ; i < this.listaMonoame.size() - 1; i++)
		{
			Monom a = listaMonoame.get(i);
			Monom b = listaMonoame.get(i + 1);
			
			if(a.getGrad() == b.getGrad())
			{
				Monom aux = new Monom();
				aux.setCoeficient(a.getCoeficient() + b.getCoeficient());
				aux.setGrad(a.getGrad());
				if(aux.getCoeficient() == 0.0f) listaMonoame.remove(a);
				else listaMonoame.set(i, aux);
				listaMonoame.remove(b);
			}
		}
	}
	
	public int gradMax()
	{
		int max = 0;
		
		for(Monom i: listaMonoame)
		{
			if(i.getGrad() > max) 
			{
				max = i.getGrad();
			}
		}
		
		return max;
	}
	
	public double coefGradMax()
	{
		double coefMax = 0.0f;
		int grMax = 0;
		
		for(Monom i: listaMonoame)
		{
			if(i.getGrad() > grMax) 
			{
				coefMax = i.getCoeficient();
				grMax = i.getGrad();
			}
			else if(i.getGrad() == grMax)
			{
				coefMax += i.getCoeficient();
			}
		}
		
		return coefMax;
	}
	
}