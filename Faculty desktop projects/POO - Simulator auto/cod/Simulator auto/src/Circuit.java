
import java.util.*;
import java.awt.*;
import java.io.*;
import javax.swing.JPanel;

public class Circuit extends JPanel{
	
	ArrayList<Point> pcte;
	ArrayList<Point> traseu;
	ArrayList<Double> unghiuri;
	//ArrayList<Double> path_unghiuri;
	BufferedReader br;
	
	public Circuit(int nr)
	{
		pcte = new ArrayList<Point>();
		traseu = new ArrayList<Point>();
		unghiuri = new ArrayList<Double>();
		//path_unghiuri = new ArrayList<Double>();
		
		citesteFisier(nr);
	}
	
	private void citesteFisier(int nr)
	{
		//br = new BufferedReader(new FileReader("src/Circuite/circuit"+ (nr + 1) +".txt"));
		br = new BufferedReader(new InputStreamReader(this.getClass().getResourceAsStream("/Circuite/circuit"+ (nr + 1) +".txt")));
		try 
		{
			String line;
			while((line = br.readLine()) != null)
			{
				String[] part = line.split(" ");
				int x = Integer.parseInt(part[0]);
				int y = Integer.parseInt(part[1]);
				pcte.add(new Point(x, y));
			}
		} 
		catch (IOException e) 
		{
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	public void afiseazaPcte()
	{
		for(int i = 0; i < pcte.size();i++)
		{
			System.out.println(pcte.get(i).getX() + " " + pcte.get(i).getY());
		}
	}
	
	public void deter_unghiuri()
	{
		unghiuri.add(0.0);
		double m1 = 0.0, m2 = 0.0, alfa = 0.0;
		for(int i = pcte.size() - 2; i >= 1; i--)
		{
			m1 = (double)(pcte.get(i).y - pcte.get(i - 1).y) / (pcte.get(i).x - pcte.get(i - 1).x);
			m2 = (double)(pcte.get(i + 1).y - pcte.get(i).y) / (pcte.get(i + 1).x - pcte.get(i).x);
			
			alfa = Math.toDegrees(Math.atan2((m2 - m1), (1 + m1 * m2)));
			if(alfa < - 90) alfa = 180 + alfa;
			if(alfa >  90) alfa = alfa - 180;
			//System.out.println(alfa);
			unghiuri.add(alfa);
		}
	}
	
	public void constrTraseu()
	{
		Point primul_pct = pcte.get(pcte.size() - 1);
		Point ultimul_pct = pcte.get(0);
		for(int i = pcte.size() - 1; i >= 1; i--)
		{
			traseu.add(new Point(pcte.get(i).x, pcte.get(i).y));
			
			Point punct, punct2, punct3;
			
			punct = new Point(pcte.get(i).x - pcte.get(i - 1).x, pcte.get(i).y - pcte.get(i - 1).y);
			
			int nr_p = (int)Math.sqrt(Math.abs(punct.x * punct.x - punct.y * punct.y)) / 10;
			
			for(int j = 1; j < nr_p; j++)
			{
				punct2 = pcte.get(i);
				
				punct3 = new Point(punct2.x + (-1) * (punct.x * j / nr_p), punct2.y + (-1) * (punct.y * j / nr_p));
				traseu.add(punct3);
				//path_unghiuri.add(unghiuri.get(i - 1)/nr_p);
			}
		}
		
		//for(int i = 0;i<path_unghiuri.size();i++) System.out.println(path_unghiuri.get(i));
	}
	
	public void afiseazaTraseu()
	{
		for(int i = 0; i < traseu.size();i++)
		{
			System.out.println(traseu.get(i).x + " " + traseu.get(i).y);
		}
	}
}