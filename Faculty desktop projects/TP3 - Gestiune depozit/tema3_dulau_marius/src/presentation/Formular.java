package presentation;

import javax.swing.*;

import model.Account;
import model.Customer;
import bll.AccountBLL;
import bll.CustomerBLL;

import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;

import java.awt.Color;
import java.awt.Component;
import java.awt.event.*;

public class Formular extends JFrame{

	private static int WIDTH = 770, HEIGHT = 360;
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
	
	private JSeparator separator = new JSeparator();
	
	JLabel lblUsername = new JLabel("Username");
	JLabel lblPass = new JLabel("Password");
	JLabel lblPass2 = new JLabel("Password confirmation");
	
	private JTextField tfUsername = new JTextField();
	private JPasswordField pfPass = new JPasswordField();
	private JPasswordField pfPass2 = new JPasswordField();
	
	private JButton btnAccount = new JButton("Create account");
	
	private Customer c;
	private CustomerBLL customerBLL = new CustomerBLL();
	private Account a;
	private AccountBLL accountBLL = new AccountBLL();
	
	public Formular(String name)
	{
		super(name);
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
		
		separator.setOrientation(SwingConstants.VERTICAL);
		separator.setForeground(Color.GRAY);
		separator.setBackground(Color.BLACK);
		
		separator.setBounds(350, 40, 2, 245);
		panel.add(separator);
		
		lblUsername.setBounds(384, 50, 150, 25);
		panel.add(lblUsername);
		
		tfUsername.setBounds(534, 50, 200, 25);
		panel.add(tfUsername);
		
		lblPass.setBounds(384, 90, 150, 25);
		panel.add(lblPass);
		
		pfPass.setBounds(534, 90, 200, 25);
		panel.add(pfPass);
		
		lblPass2.setBounds(384, 130, 150, 25);
		panel.add(lblPass2);
		
		pfPass2.setBounds(534, 130, 200, 25);
		panel.add(pfPass2);
		
		btnAccount.setBounds(485, 230, 150, 45);
		accountActionListener();
		panel.add(btnAccount);
		
		getContentPane().add(panel);
	}
	
	private void accountActionListener()
	{
		btnAccount.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent arg0) {
				// TODO Auto-generated method stub
				if(fieldsCompleted()==true)
				{
					if(getPass().compareTo(getPassConfirmation()) == 0)
					{
						a = new Account(getUsername(), getPass(), 'U');
						c = new Customer(a.getUsername() ,getFirstName(), getLastName(), getAge(), getAddress(), getEmail(), getPhoneNumber());
						
						try
						{
							Object[] campuri = {"username"};
							if(accountBLL.userExist(a, campuri) == false) 
							{
								accountBLL.insertAccount(a);
								customerBLL.insertCustomer(c);
								JOptionPane.showMessageDialog(panel, "Account succsessfully created");
							}
						}
						catch(Exception e)
						{
							JOptionPane.showMessageDialog(panel, e.toString());
						}
					}
					else
					{
						JOptionPane.showMessageDialog(panel, "Password does not match password confirmation!");
					}
				}
				else
				{
					JOptionPane.showMessageDialog(panel, "Please complete all fields!");
				}
			}
		});
	}
	
	private boolean fieldsCompleted()
	{	
		for(Component c: panel.getComponents())
		{
			if(c instanceof JTextField)
			{
				if(((JTextField) c).getText().length() == 0) 
				{
					return false;
				}
			}
			if(c instanceof JPasswordField)
			{
				if(String.valueOf(((JPasswordField) c).getPassword()).length() == 0)
				{
					return false;
				}
			}
		}
		
		return true;
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
		return Integer.parseInt(tfAge.getText());
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
	
	private String getUsername()
	{
		return tfUsername.getText();
	}
	
	private String getPass()
	{
		return String.valueOf(pfPass.getPassword());
	}
	
	private String getPassConfirmation()
	{
		return String.valueOf(pfPass2.getPassword());
	}
}
