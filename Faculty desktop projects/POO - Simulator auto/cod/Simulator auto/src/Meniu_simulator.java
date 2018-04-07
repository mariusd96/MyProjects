import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Cursor;
import java.awt.EventQueue;
import java.awt.Font;
import java.awt.Image;
import java.awt.Panel;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;

import javax.swing.ImageIcon;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.SwingConstants;
import javax.swing.border.EmptyBorder;

import java.net.URL;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;

public class Meniu_simulator extends JFrame {

	private JPanel contentPane;
	
	ImageIcon[] masini = new ImageIcon[6];
	ImageIcon[] circuite = new ImageIcon[5];
	int nr_masina = 0, nr_circuit = 0;
	ImageIcon img;
	URL url;
	
	private void setMasini()
	{
		for(int i = 0 ; i < 6; i++)
		{
			url = Meniu_simulator.class.getResource("/Masini/masina" + (i + 1) + ".png");
			masini[i] = new ImageIcon(url);
		}
	}
	
	private void setCircuite()
	{
		for(int i = 0 ; i < 5; i++)
		{
			url = Meniu_simulator.class.getResource("/Circuite/circuit" + (i + 1) + ".png");
			circuite[i] = new ImageIcon(url);
		}
	}

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					Meniu_simulator frame = new Meniu_simulator();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	public Meniu_simulator() {
		setResizable(false);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 900, 600);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		setMasini();
		setCircuite();
		
		JLabel label1 = new JLabel("Alege masina");
		label1.setHorizontalAlignment(SwingConstants.CENTER);
		label1.setFont(new Font("Times New Roman", Font.PLAIN, 14));
		label1.setBounds(400, 10, 100, 25);
		contentPane.add(label1);
		
		Panel panel1 = new Panel();
		panel1.setBounds(245, 40, 410, 200);
		contentPane.add(panel1);
		panel1.setLayout(null);
		
		JButton btn = new JButton("<");
		btn.setBackground(new Color(0, 153, 255));
		btn.setForeground(Color.WHITE);
		btn.setBounds(10, 85, 40, 30);
		btn.setCursor(new Cursor(Cursor.HAND_CURSOR));
		panel1.add(btn);
		btn.setFont(new Font("Times New Roman", Font.BOLD, 11));
		
		JLabel masina1 = new JLabel("");
		masina1.setBounds(70, 40, 60, 120);
		img = new ImageIcon(masini[5].getImage().getScaledInstance((int)masina1.getWidth(), (int)masina1.getHeight(), Image.SCALE_AREA_AVERAGING));
		masina1.setIcon(img);
		panel1.add(masina1);
		
		JLabel masina2 = new JLabel("");
		masina2.setBounds(160, 15, 90, 170);
		img = new ImageIcon(masini[0].getImage().getScaledInstance((int)masina2.getWidth(), (int)masina2.getHeight(), Image.SCALE_AREA_AVERAGING));
		masina2.setIcon(img);
		panel1.add(masina2);
		
		JLabel masina3 = new JLabel("");
		masina3.setBounds(280, 40, 60, 120);
		img = new ImageIcon(masini[1].getImage().getScaledInstance((int)masina3.getWidth(), (int)masina3.getHeight(), Image.SCALE_AREA_AVERAGING));
		masina3.setIcon(img);
		panel1.add(masina3);
		
		btn.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				nr_masina--;
				if(nr_masina == -1) 
				{
					nr_masina = 5;
					img = new ImageIcon(masini[nr_masina - 1].getImage().getScaledInstance((int)masina1.getWidth(), (int)masina1.getHeight(), Image.SCALE_AREA_AVERAGING));
					masina1.setIcon(img);
					img = new ImageIcon(masini[nr_masina].getImage().getScaledInstance((int)masina2.getWidth(), (int)masina2.getHeight(), Image.SCALE_AREA_AVERAGING));
					masina2.setIcon(img);
					img = new ImageIcon(masini[0].getImage().getScaledInstance((int)masina3.getWidth(), (int)masina3.getHeight(), Image.SCALE_AREA_AVERAGING));
					masina3.setIcon(img);
				}
				else if(nr_masina == 0) 
				{
					img = new ImageIcon(masini[5].getImage().getScaledInstance((int)masina1.getWidth(), (int)masina1.getHeight(), Image.SCALE_AREA_AVERAGING));
					masina1.setIcon(img);
					img = new ImageIcon(masini[nr_masina].getImage().getScaledInstance((int)masina2.getWidth(), (int)masina2.getHeight(), Image.SCALE_AREA_AVERAGING));
					masina2.setIcon(img);
					img = new ImageIcon(masini[nr_masina + 1].getImage().getScaledInstance((int)masina3.getWidth(), (int)masina3.getHeight(), Image.SCALE_AREA_AVERAGING));
					masina3.setIcon(img);
				}
				else
				{
					img = new ImageIcon(masini[nr_masina - 1].getImage().getScaledInstance((int)masina1.getWidth(), (int)masina1.getHeight(), Image.SCALE_AREA_AVERAGING));
					masina1.setIcon(img);
					img = new ImageIcon(masini[nr_masina].getImage().getScaledInstance((int)masina2.getWidth(), (int)masina2.getHeight(), Image.SCALE_AREA_AVERAGING));
					masina2.setIcon(img);
					img = new ImageIcon(masini[nr_masina + 1].getImage().getScaledInstance((int)masina3.getWidth(), (int)masina3.getHeight(), Image.SCALE_AREA_AVERAGING));
					masina3.setIcon(img);
				}
			}
		});
		
		
		JButton btn2 = new JButton(">");
		btn2.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				nr_masina++;
				if(nr_masina == 6) 
				{
					nr_masina = 0;
					img = new ImageIcon(masini[5].getImage().getScaledInstance((int)masina1.getWidth(), (int)masina1.getHeight(), Image.SCALE_AREA_AVERAGING));
					masina1.setIcon(img);
					img = new ImageIcon(masini[nr_masina].getImage().getScaledInstance((int)masina2.getWidth(), (int)masina2.getHeight(), Image.SCALE_AREA_AVERAGING));
					masina2.setIcon(img);
					img = new ImageIcon(masini[nr_masina + 1].getImage().getScaledInstance((int)masina3.getWidth(), (int)masina3.getHeight(), Image.SCALE_AREA_AVERAGING));
					masina3.setIcon(img);
				}
				else if(nr_masina == 5) 
				{
					img = new ImageIcon(masini[nr_masina - 1].getImage().getScaledInstance((int)masina1.getWidth(), (int)masina1.getHeight(), Image.SCALE_AREA_AVERAGING));
					masina1.setIcon(img);
					img = new ImageIcon(masini[nr_masina].getImage().getScaledInstance((int)masina2.getWidth(), (int)masina2.getHeight(), Image.SCALE_AREA_AVERAGING));
					masina2.setIcon(img);
					img = new ImageIcon(masini[0].getImage().getScaledInstance((int)masina3.getWidth(), (int)masina3.getHeight(), Image.SCALE_AREA_AVERAGING));
					masina3.setIcon(img);
				}
				else
				{
					img = new ImageIcon(masini[nr_masina - 1].getImage().getScaledInstance((int)masina1.getWidth(), (int)masina1.getHeight(), Image.SCALE_AREA_AVERAGING));
					masina1.setIcon(img);
					img = new ImageIcon(masini[nr_masina].getImage().getScaledInstance((int)masina2.getWidth(), (int)masina2.getHeight(), Image.SCALE_AREA_AVERAGING));
					masina2.setIcon(img);
					img = new ImageIcon(masini[nr_masina + 1].getImage().getScaledInstance((int)masina3.getWidth(), (int)masina3.getHeight(), Image.SCALE_AREA_AVERAGING));
					masina3.setIcon(img);
				}
			}
		});
		btn2.setBackground(new Color(0, 153, 255));
		btn2.setForeground(Color.WHITE);
		btn2.setBounds(360, 85, 40, 30);
		btn2.setCursor(new Cursor(Cursor.HAND_CURSOR));
		panel1.add(btn2);
		btn2.setFont(new Font("Times New Roman", Font.BOLD, 11));
		
		JLabel label2 = new JLabel("Alege circuitul");
		label2.setHorizontalAlignment(SwingConstants.CENTER);
		label2.setFont(new Font("Times New Roman", Font.PLAIN, 14));
		label2.setBounds(400, 260, 100, 25);
		getContentPane().add(label2);
		
		Panel panel2 = new Panel();
		panel2.setLayout(null);
		panel2.setBounds(50, 290, 800, 200);
		contentPane.add(panel2);
		
		JButton button = new JButton("<");
		button.setBackground(new Color(0, 153, 255));
		button.setForeground(Color.WHITE);
		button.setFont(new Font("Times New Roman", Font.BOLD, 11));
		button.setBounds(10, 85, 40, 30);
		button.setCursor(new Cursor(Cursor.HAND_CURSOR));
		panel2.add(button);
		
		JLabel circuit1 = new JLabel("");
		circuit1.setBounds(70, 63, 150, 75);
		img = new ImageIcon(circuite[4].getImage().getScaledInstance((int)circuit1.getWidth(), (int)circuit1.getHeight(), Image.SCALE_AREA_AVERAGING));
		circuit1.setIcon(img);
		panel2.add(circuit1);
		
		JLabel circuit2 = new JLabel("");
		circuit2.setBounds(250, 25, 300, 150);
		img = new ImageIcon(circuite[0].getImage().getScaledInstance((int)circuit2.getWidth(), (int)circuit2.getHeight(), Image.SCALE_AREA_AVERAGING));
		circuit2.setIcon(img);
		panel2.add(circuit2);
		
		JLabel circuit3 = new JLabel("");
		circuit3.setBounds(580, 63, 150, 75);
		img = new ImageIcon(circuite[1].getImage().getScaledInstance((int)circuit3.getWidth(), (int)circuit3.getHeight(), Image.SCALE_AREA_AVERAGING));
		circuit3.setIcon(img);
		panel2.add(circuit3);
		
		button.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				nr_circuit--;
				if(nr_circuit == -1) 
				{
					nr_circuit = 4;
					img = new ImageIcon(circuite[nr_circuit - 1].getImage().getScaledInstance((int)circuit1.getWidth(), (int)circuit1.getHeight(), Image.SCALE_AREA_AVERAGING));
					circuit1.setIcon(img);
					img = new ImageIcon(circuite[nr_circuit].getImage().getScaledInstance((int)circuit2.getWidth(), (int)circuit2.getHeight(), Image.SCALE_AREA_AVERAGING));
					circuit2.setIcon(img);
					img = new ImageIcon(circuite[0].getImage().getScaledInstance((int)circuit3.getWidth(), (int)circuit3.getHeight(), Image.SCALE_AREA_AVERAGING));
					circuit3.setIcon(img);
				}
				else if(nr_circuit == 0) 
				{
					img = new ImageIcon(circuite[4].getImage().getScaledInstance((int)circuit1.getWidth(), (int)circuit1.getHeight(), Image.SCALE_AREA_AVERAGING));
					circuit1.setIcon(img);
					img = new ImageIcon(circuite[nr_circuit].getImage().getScaledInstance((int)circuit2.getWidth(), (int)circuit2.getHeight(), Image.SCALE_AREA_AVERAGING));
					circuit2.setIcon(img);
					img = new ImageIcon(circuite[nr_circuit + 1].getImage().getScaledInstance((int)circuit3.getWidth(), (int)circuit3.getHeight(), Image.SCALE_AREA_AVERAGING));
					circuit3.setIcon(img);
				}
				else
				{
					img = new ImageIcon(circuite[nr_circuit - 1].getImage().getScaledInstance((int)circuit1.getWidth(), (int)circuit1.getHeight(), Image.SCALE_AREA_AVERAGING));
					circuit1.setIcon(img);
					img = new ImageIcon(circuite[nr_circuit].getImage().getScaledInstance((int)circuit2.getWidth(), (int)circuit2.getHeight(), Image.SCALE_AREA_AVERAGING));
					circuit2.setIcon(img);
					img = new ImageIcon(circuite[nr_circuit + 1].getImage().getScaledInstance((int)circuit3.getWidth(), (int)circuit3.getHeight(), Image.SCALE_AREA_AVERAGING));
					circuit3.setIcon(img);
				}
			}
		});
		
		JButton button1 = new JButton(">");
		button1.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				nr_circuit++;
				if(nr_circuit == 5) 
				{
					nr_circuit = 0;
					img = new ImageIcon(circuite[4].getImage().getScaledInstance((int)circuit1.getWidth(), (int)circuit1.getHeight(), Image.SCALE_AREA_AVERAGING));
					circuit1.setIcon(img);
					img = new ImageIcon(circuite[nr_circuit].getImage().getScaledInstance((int)circuit2.getWidth(), (int)circuit2.getHeight(), Image.SCALE_AREA_AVERAGING));
					circuit2.setIcon(img);
					img = new ImageIcon(circuite[nr_circuit + 1].getImage().getScaledInstance((int)circuit3.getWidth(), (int)circuit3.getHeight(), Image.SCALE_AREA_AVERAGING));
					circuit3.setIcon(img);
				}
				else if(nr_circuit == 4) 
				{
					img = new ImageIcon(circuite[nr_circuit - 1].getImage().getScaledInstance((int)circuit1.getWidth(), (int)circuit1.getHeight(), Image.SCALE_AREA_AVERAGING));
					circuit1.setIcon(img);
					img = new ImageIcon(circuite[nr_circuit].getImage().getScaledInstance((int)circuit2.getWidth(), (int)circuit2.getHeight(), Image.SCALE_AREA_AVERAGING));
					circuit2.setIcon(img);
					img = new ImageIcon(circuite[0].getImage().getScaledInstance((int)circuit3.getWidth(), (int)circuit3.getHeight(), Image.SCALE_AREA_AVERAGING));
					circuit3.setIcon(img);
				}
				else
				{
					img = new ImageIcon(circuite[nr_circuit - 1].getImage().getScaledInstance((int)circuit1.getWidth(), (int)circuit1.getHeight(), Image.SCALE_AREA_AVERAGING));
					circuit1.setIcon(img);
					img = new ImageIcon(circuite[nr_circuit].getImage().getScaledInstance((int)circuit2.getWidth(), (int)circuit2.getHeight(), Image.SCALE_AREA_AVERAGING));
					circuit2.setIcon(img);
					img = new ImageIcon(circuite[nr_circuit + 1].getImage().getScaledInstance((int)circuit3.getWidth(), (int)circuit3.getHeight(), Image.SCALE_AREA_AVERAGING));
					circuit3.setIcon(img);
				}
			}
		});
		button1.setBackground(new Color(0, 153, 255));
		button1.setForeground(Color.WHITE);
		button1.setFont(new Font("Times New Roman", Font.BOLD, 11));
		button1.setBounds(750, 85, 40, 30);
		button1.setCursor(new Cursor(Cursor.HAND_CURSOR));
		panel2.add(button1);
		
		JButton btn_simulare = new JButton("Simuleaza");
		btn_simulare.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				Simulator frame = new Simulator(nr_circuit, nr_masina);
				frame.setVisible(true);
				dispose();
			}
		});
		btn_simulare.setForeground(Color.WHITE);
		btn_simulare.setBackground(new Color(0, 153, 255));
		btn_simulare.setFont(new Font("Times New Roman", Font.PLAIN, 14));
		btn_simulare.setBounds(400, 520, 100, 30);
		btn_simulare.setCursor(new Cursor(Cursor.HAND_CURSOR));
		contentPane.add(btn_simulare);
	}

}
