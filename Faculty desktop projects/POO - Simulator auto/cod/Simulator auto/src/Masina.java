import java.awt.*;
import java.util.*;

import javax.swing.JLabel;
import javax.swing.JOptionPane;

public class Masina extends JLabel {

	ArrayList<Point> pcte_unghiulare;
	ArrayList<Point> traseu;
	ArrayList<Double> unghiuri;
	public int i, j;//i - index-ul punctului din traseu, j - index-ul punctului unghiular
	public double angle;
	protected int nrTure;
	protected int viteza;
	private int viteza_max;
	Random rand;
	private int milisec, sec, min;
	protected String timp, last_lap, best_lap;
	
	public Masina(int nr)
	{
		traseu = new ArrayList<Point>();
		pcte_unghiulare = new ArrayList<Point>();
		unghiuri = new ArrayList<Double>();
		i = 1;
		j = 1;
		angle = -90.0;
		nrTure = 0;
		viteza = 0;
		rand = new Random();
		viteza_max = 300;
		milisec = sec = min = 0;
		timp = "00:00:000";
		last_lap = "00:00:000";
		best_lap = "99:99:999";
	}
	
	public void traseuDeParcurs(ArrayList<Point> traseu_circuit)
	{
		traseu = traseu_circuit;
	}
	
	public void setUnghiuri(ArrayList<Double> unghiuri_circuit)
	{
		/*for(int i = unghiuri_circuit.size() - 1; i >= 0; i--)
		{
			unghiuri.add(unghiuri_circuit.get(i));
		}*/
		unghiuri = unghiuri_circuit;
	}
	
	public void setPcteUnghiulare(ArrayList<Point> pcte)
	{
		for(int i = pcte.size() - 1; i >= 0; i--)
		{
			pcte_unghiulare.add(pcte.get(i));
		}
		//pcte_unghiulare = pcte;
	}
	
	public void afiseazaTraseu()
	{
		for(int i = 0; i < traseu.size();i++)
		{
			System.out.println(traseu.get(i).x + " " + traseu.get(i).y);
		}
	}
	
	public void parcurgeTraseu()
	{
		setLocation(traseu.get(i).x, traseu.get(i).y);
		viteza += rand.nextInt(10);
		if(viteza > viteza_max) viteza = viteza_max;
			
		if(traseu.get(i).x == pcte_unghiulare.get(j).x && traseu.get(i).y == pcte_unghiulare.get(j).y)
		{
			//JOptionPane.showMessageDialog(null, unghiuri.get(j));
			angle += (-1) * (unghiuri.get(j));
			viteza = speed(viteza, unghiuri.get(j));
			if(j == unghiuri.size() - 1) j = 0;
			else j++;
		}
		/*angle += (-1) * (unghiuri.get(j));
		if(j == unghiuri.size() - 1) j = 0;
		else j++;*/
		if(i == traseu.size() - 1) 
		{
			i = 0; 
			nrTure++;
		}
		else i++;
	}
	
	private int speed(int vitaza, double unghi_viraj)
	{
		if(unghi_viraj >= -30 && unghi_viraj <= 30) return (int)(viteza * 7/10) + (rand.nextInt(10) - 5);
		else if(unghi_viraj >= -60 && unghi_viraj < -30 && unghi_viraj >30 && unghi_viraj <= 360) return (int)(viteza * 45/100) + (rand.nextInt(10) - 5);
		return (int)(viteza * 2/10) + (rand.nextInt(10) - 5);
	}
	
	public void cronometru()
	{		
		if(i == 0) 
		{
			last_lap = timp;
			if(last_lap.compareTo(best_lap) < 0) best_lap = last_lap;
			milisec = sec = min = 0;
		}
		else
		{
			milisec++;
			if(milisec == 1000)
			{
				milisec = 0;
				sec++;
			}
			if(sec == 60)
			{
				sec = 0;
				min++;
			}
			
			timp = "0" + min + ":";
			if(sec < 10) timp = timp + "0" + sec + ":";
			else timp = timp + sec + ":";
			if(milisec < 10) timp = timp + "00" + milisec;
			else if(milisec < 100) timp = timp + "0" + milisec;
			else timp = timp + milisec;
		}
	}
}
