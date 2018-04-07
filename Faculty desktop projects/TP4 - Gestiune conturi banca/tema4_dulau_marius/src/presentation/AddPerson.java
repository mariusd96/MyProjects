package presentation;

import javax.swing.*;

import model.Person;

import java.awt.Color;
import java.awt.event.ActionListener;

public class AddPerson extends JFrame{

	private static final int WIDTH = 300, HEIGHT = 270;
	
	private JPanel panel = new JPanel();
	private JLabel lblCNP = new JLabel("CNP");
	private JLabel lblFirstName = new JLabel("First name");
	private JLabel lblLastName = new JLabel("Last name");
	private JLabel lblAddress = new JLabel("Address");
	private JTextField tfCNP= new JTextField();
	private JTextField tfFirstName = new JTextField();
	private JTextField tfLastName = new JTextField();
	private JTextField tfAddress = new JTextField();
	private JButton btnAdd = new JButton("Add");
	
	public AddPerson(String name)
	{
		super(name);
		this.setDefaultCloseOperation(DISPOSE_ON_CLOSE);
		this.setVisible(true);
		this.setSize(WIDTH, HEIGHT);
		panel.setLayout(null);
		
		lblCNP.setBounds(20, 20, 60, 25);
		lblFirstName.setBounds(20, 55, 60, 25);
		lblLastName.setBounds(20, 90, 60, 25);
		lblAddress.setBounds(20, 125, 60, 25);
		
		panel.add(lblCNP);
		panel.add(lblFirstName);
		panel.add(lblLastName);
		panel.add(lblAddress);
		
		tfCNP.setBounds(110, 20, 150, 25);
		tfFirstName.setBounds(110, 55, 150, 25);
		tfLastName.setBounds(110, 90, 150, 25);
		tfAddress.setBounds(110, 125, 150, 25);
		
		panel.add(tfCNP);
		panel.add(tfFirstName);
		panel.add(tfLastName);
		panel.add(tfAddress);
		btnAdd.setBackground(Color.RED);
		btnAdd.setForeground(Color.WHITE);
		
		btnAdd.setBounds(90, 175, 100, 30);
		panel.add(btnAdd);
		
		this.add(panel);
	}
	
	public void addPersonActionListener(ActionListener pal)
	{
		btnAdd.addActionListener(pal);
	}
	
	private String getCNP()
	{
		return tfCNP.getText();
	}
	
	private String getFirstName()
	{
		return tfFirstName.getText();
	}
	
	private String getLastName()
	{
		return tfLastName.getText();
	}
	
	private String getAddress()
	{
		return tfAddress.getText();
	}
	
	public Person getPerson()
	{
		return (new Person(getCNP(), getFirstName(), getLastName(), getAddress()));
	}
}