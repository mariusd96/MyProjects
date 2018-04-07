package presentation;

import javax.swing.*;
import java.awt.Color;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import bll.AccountBLL;
import bll.CustomerBLL;
import model.Account;
import model.Customer;

public class Login extends JFrame{

	private static int WIDTH = 400, HEIGHT = 240;
	
	private JPanel panel = new JPanel();
	private JPanel panel2 = new JPanel();
	
	private JTextField userText = new JTextField();
	private JPasswordField passText = new JPasswordField();
	
	private JLabel lblUsername = new JLabel("username");
	private JLabel lblPassword = new JLabel("password");
	
	private JButton btnLogin = new JButton("Login");
	private JButton btnSignUp = new JButton("Sign Up");
	
	private Formular formular;
	private AdminFrame adminFrame;
	private UserFrame userFrame;
	
	public Login(String name)
	{
		super(name);
		
		//setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setResizable(false);
		this.setSize(WIDTH, HEIGHT);
		panel.setLayout(null);
		panel2.setLayout(null);
		panel2.setBounds(80, 30, 240, 80);
		
		lblUsername.setBounds(10, 15, 75, 20);
		panel2.add(lblUsername);
		
		lblPassword.setBounds(10, 45, 75, 20);
		panel2.add(lblPassword);
		
		userText.setBounds(100, 15, 130, 20);
		panel2.add(userText);
		
		passText.setBounds(100, 45, 130, 20);
		panel2.add(passText);
		
		panel.add(panel2);
		
		btnLogin.setBounds(70, 140, 120, 25);
		panel.add(btnLogin);
		
		btnSignUp.setBounds(210, 140, 120, 25);
		panel.add(btnSignUp);
		
		loginActionListener();
		signUpActionListener();
		
		this.add(panel);
	}
	
	private void loginActionListener()
	{
		btnLogin.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e)
			{
				Account a = new Account(getUsername(), getPassword(), 'U');
				AccountBLL accountBLL = new AccountBLL();
				Object[] campuri = {"username", "pass"};
				try
				{
					a = (Account)accountBLL.findByUser(a, campuri);
					if(a.getRole()=='U') 
					{
						userFrame = new UserFrame("User : " + a.getUsername(), a);
						userFrame.setVisible(true);
					}
					else 
					{
						adminFrame = new AdminFrame("Admin");
						adminFrame.setVisible(true);
					}
					setVisible(false);
					dispose();
				}
				catch(Exception ex)
				{
					JOptionPane.showMessageDialog(panel, ex.toString());
				}
			}
		});
	}
	
	private void signUpActionListener()
	{
		btnSignUp.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent arg0) {
				// TODO Auto-generated method stub
				formular = new Formular("Formular inregistrare");
				formular.setVisible(true);
			}
		});
	}
	
	public String getUsername()
	{
		return this.userText.getText();
	}
	
	public String getPassword()
	{
		return String.valueOf(this.passText.getPassword());
	}
	
	void addLoginListener(ActionListener all)
	{
		btnLogin.addActionListener(all);
	}
}
