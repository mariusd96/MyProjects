package presentation;

import java.awt.Color;
import java.awt.event.*;
import javax.swing.*;

public class EditDeletePerson extends JFrame{
	
	private static final int WIDTH = 350;
	private static int HEIGHT = 84;
	
	private JPanel panel = new JPanel();
	private JLabel lblCNP = new JLabel("CNP");
	private JLabel lblFirstName = new JLabel("First name");
	private JLabel lblLastName = new JLabel("Last name");
	private JLabel lblAddress = new JLabel("Address");
	public JTextField tfCNP= new JTextField();
	private JTextField tfFirstName = new JTextField();
	private JTextField tfLastName = new JTextField();
	private JTextField tfAddress = new JTextField();
	private JButton btnEdit = new JButton("Edit");
	private JButton btnDelete = new JButton("Delete");
	private JButton btnOk = new JButton("Ok");
	
	public EditDeletePerson(String name)
	{
		super(name);
		setResizable(false);
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
		
		btnEdit.setBackground(Color.RED);
		btnEdit.setForeground(Color.WHITE);
		btnEdit.setBounds(50, 175, 100, 30);
		panel.add(btnEdit);
		
		btnDelete.setBackground(Color.RED);
		btnDelete.setForeground(Color.WHITE);
		btnDelete.setBounds(180, 175, 100, 30);
		panel.add(btnDelete);
		
		btnOk.setForeground(Color.WHITE);
		btnOk.setBackground(Color.RED);
		btnOk.setBounds(270, 20, 55, 25);
		panel.add(btnOk);
		
		getContentPane().add(panel);
	}
	
	public int getWidth()
	{
		return this.WIDTH;
	}
	
	public int getHeight()
	{
		return this.HEIGHT;
	}
	
	public void setHeight(int h)
	{
		this.HEIGHT = h;
	}
	
	public void cnpOkActionListener(ActionListener oal)
	{
		btnOk.addActionListener(oal);
	}
	
	public void editActionListener(ActionListener eal)
	{
		btnEdit.addActionListener(eal);
	}
	
	public void deleteActionListener(ActionListener dal)
	{
		btnDelete.addActionListener(dal);
	}
	
	public String getCNP()
	{
		return tfCNP.getText();
	}
	
	public String getFirstName()
	{
		return tfFirstName.getText();
	}
	
	public void setFirstName(String firstName)
	{
		tfFirstName.setText(firstName);
	}
	
	public String getLastName()
	{
		return tfLastName.getText();
	}
	
	public void setLastName(String lastName)
	{
		tfLastName.setText(lastName);
	}
	
	public String getAddress()
	{
		return tfAddress.getText();
	}
	
	public void setAddress(String address)
	{
		tfAddress.setText(address);
	}
}