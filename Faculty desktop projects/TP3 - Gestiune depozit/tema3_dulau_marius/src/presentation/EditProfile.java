package presentation;

import java.awt.event.ActionListener;

import javax.swing.*;

import bll.AccountBLL;
import bll.CustomerBLL;
import model.Account;
import model.Customer;

public class EditProfile extends JFrame{

	private static int WIDTH = 350, HEIGHT = 420;
	private JPanel panel = new JPanel();
	
	private JLabel lblFirstName = new JLabel("First name");
	private JLabel lblLastName = new JLabel("Last name");
	private JLabel lblAge = new JLabel("Age");
	private JLabel lblAddress = new JLabel("Address");
	private JLabel lblEmail = new JLabel("Email");
	private JLabel lblPhoneNumber = new JLabel("Phone number");
	
	private JTextField tfFirstName = new JTextField();
	private JTextField tfLastName = new JTextField();
	private JTextField tfAge = new JTextField();
	private JTextField tfAddress = new JTextField();
	private JTextField tfEmail = new JTextField();
	private JTextField tfPhoneNumber = new JTextField();
	
	private JButton btnUpdate = new JButton("Update");
	
	private Customer c = new Customer(0, "test", "test", "test", 30, "test", "test@test.com", "0123456789");
	private CustomerBLL customerBLL = new CustomerBLL();
	private Account myAccount;
	private AccountBLL accountBLL = new AccountBLL();
	private Object[] campuri ={"username"};
	
	public EditProfile(String name, Account a)
	{
		super(name);
		myAccount = a;
		this.setSize(WIDTH, HEIGHT);
		setResizable(false);
		panel.setLayout(null);
		
		lblFirstName.setBounds(20, 50, 100, 25);
		tfFirstName.setBounds(120, 50, 200, 25);
		lblLastName.setBounds(20, 90, 100, 25);
		tfLastName.setBounds(120, 90, 200, 25);
		lblAge.setBounds(20, 130, 100, 25);
		tfAge.setBounds(120, 130, 200, 25);
		lblAddress.setBounds(20, 170, 100, 25);
		tfAddress.setBounds(120, 170, 200, 25);
		lblEmail.setBounds(20, 210, 100, 25);
		tfEmail.setBounds(120, 210, 200, 25);
		lblPhoneNumber.setBounds(20, 250, 100, 25);
		tfPhoneNumber.setBounds(120, 250, 200, 25);
		
		panel.add(lblFirstName);
		panel.add(lblLastName);
		panel.add(lblAge);
		panel.add(lblAddress);
		panel.add(lblEmail);
		panel.add(lblPhoneNumber);
		
		panel.add(tfFirstName);
		panel.add(tfLastName);
		panel.add(tfAge);
		panel.add(tfAddress);
		panel.add(tfEmail);
		panel.add(tfPhoneNumber);
		
		btnUpdate.setBounds(110, 320, 130, 35);
		panel.add(btnUpdate);
		
		c.setUsername(a.getUsername());
		c = (Customer)customerBLL.findCustomerByUser(c, campuri);
		populateTF();
		getContentPane().add(panel);
	}
	
	private void populateTF()
	{
		tfFirstName.setText(c.getFirstName());
		tfLastName.setText(c.getLastName());
		tfAge.setText(String.valueOf(c.getAge()));
		tfAddress.setText(c.getAddress());
		tfEmail.setText(c.getEmail());
		tfPhoneNumber.setText(c.getPhoneNumber());
	}
	
	private String getFirstName()
	{
		return tfFirstName.getText();
	}
	
	private String getLastName()
	{
		return tfLastName.getText();
	}
	
	private int getAge()
	{
		return Integer.valueOf(tfAge.getText());
	}
	
	private String getAddress()
	{
		return tfAddress.getText();
	}
	
	private String getEmail()
	{
		return tfEmail.getText();
	}
	
	private String getPhoneNumber()
	{
		return tfPhoneNumber.getText();
	}
	
	public Customer getCustomer()
	{
		c = new Customer(c.getId(), myAccount.getUsername(), getFirstName(), getLastName(), getAge(), getAddress(), getEmail(), getPhoneNumber());
		return c;
	}
	
	public void addEditCustomerListener(ActionListener ecl)
	{
		btnUpdate.addActionListener(ecl);
	}
}
