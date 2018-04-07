import java.awt.BorderLayout;
import java.awt.EventQueue;
import java.awt.Image;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;

import javax.swing.JLabel;
import javax.swing.ImageIcon;
import javax.swing.JEditorPane;
import javax.swing.JLayeredPane;
import javax.swing.JOptionPane;

import java.awt.Toolkit;
import java.awt.Window.Type;
import java.awt.Panel;
import java.awt.Dialog.ModalExclusionType;
import javax.swing.JButton;
import java.awt.GridLayout;
import java.awt.Color;
import java.awt.Cursor;
import java.awt.Font;
import javax.swing.SwingConstants;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;

import java.net.URL;

public class Meniu extends JFrame {

	private JPanel contentPane;
	URL url;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					Meniu frame = new Meniu();
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
	public Meniu() {
		setResizable(false);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 700, 500);
		contentPane = new JPanel();
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		JLabel label2 = new JLabel("Simulator circuite auto");
		label2.setForeground(new Color(0, 153, 255));
		label2.setHorizontalAlignment(SwingConstants.CENTER);
		label2.setFont(new Font("Times New Roman", Font.PLAIN, 36));
		label2.setBounds(175, 100, 350, 34);
		contentPane.add(label2);
		
		JPanel panel = new JPanel();
		panel.setBounds(105, 400, 490, 30);
		contentPane.add(panel);
		panel.setLayout(null);
		panel.setBackground(new Color(255, 255, 255, 0));
		
		JButton btn1 = new JButton("Simulator");
		btn1.addActionListener(new ActionListener(){
			public void actionPerformed(ActionEvent e)
			{
				Meniu_simulator frame = new Meniu_simulator();
				frame.setVisible(true);
				dispose();
			}
		});
		btn1.setBackground(new Color(0, 153, 255));
		btn1.setForeground(Color.WHITE);
		btn1.setBounds(0, 0, 150, 30);
		btn1.setCursor(new Cursor(Cursor.HAND_CURSOR));
		panel.add(btn1);
		
		JButton btn2 = new JButton("Despre aplicatie");
		btn2.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				JOptionPane.showMessageDialog(null, "Proiect la POO, Dulau Marius, CTI UTCN, 2016-2017");
			}
		});
		btn2.setBackground(new Color(0, 153, 255));
		btn2.setForeground(Color.WHITE);
		btn2.setBounds(170, 0, 150, 30);
		btn2.setCursor(new Cursor(Cursor.HAND_CURSOR));
		panel.add(btn2);
		
		JButton btn_exit = new JButton("Exit");
		btn_exit.addMouseListener(new MouseAdapter() {
			@Override
			public void mouseClicked(MouseEvent e) {
				System.exit(EXIT_ON_CLOSE);
			}
		});
		btn_exit.setForeground(Color.WHITE);
		btn_exit.setBackground(new Color(255, 0, 0));
		btn_exit.setBounds(340, 0, 150, 30);
		btn_exit.setCursor(new Cursor(Cursor.HAND_CURSOR));
		panel.add(btn_exit);
		
		JLabel label1 = new JLabel("");
		label1.setBounds(5, 5, 679, 455);
		contentPane.add(label1);
		url = Meniu.class.getResource("/Resources/background4.jpg");
		ImageIcon img = new ImageIcon(new ImageIcon(url).getImage().getScaledInstance((int)label1.getWidth(), (int)label1.getHeight(), Image.SCALE_AREA_AVERAGING));
		label1.setIcon(img);
	}
}
