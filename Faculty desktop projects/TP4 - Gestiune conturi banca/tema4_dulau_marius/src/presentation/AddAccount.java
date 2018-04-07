package presentation;

import java.awt.Color;

import javax.swing.*;

import model.Person;

import java.awt.event.ActionListener;
import java.awt.event.ActionEvent;

public class AddAccount extends JFrame{

	private static final int WIDTH = 360, HEIGHT = 270;
	
	public JPanel panel = new JPanel();
	private JLabel lblAccountHolderCNP = new JLabel("Account Holder CNP");
	private JLabel lblBalance = new JLabel("Balance");
	private JLabel lblAccountType = new JLabel("Account Type");
	private JTextField tfAccountHolderCNP = new JTextField();
	private JTextField tfBalance = new JTextField();
	public JRadioButton rdbtnSavingAccount = new JRadioButton("Saving Account");
	public JRadioButton rdbtnSpendingAccount = new JRadioButton("Spending Account");
	private JButton btnAdd = new JButton("Add");
	
	public AddAccount(String name)
	{
		super(name);
		setResizable(false);
		this.setDefaultCloseOperation(DISPOSE_ON_CLOSE);
		this.setVisible(true);
		this.setSize(WIDTH, HEIGHT);
		panel.setLayout(null);
		
		lblAccountHolderCNP.setBounds(20, 20, 120, 25);
		lblBalance.setBounds(20, 55, 120, 25);
		lblAccountType.setBounds(20, 90, 120, 25);
		panel.add(lblAccountHolderCNP);
		panel.add(lblBalance);
		panel.add(lblAccountType);
		
		tfAccountHolderCNP.setBounds(170, 20, 150, 25);
		tfBalance.setBounds(170, 55, 150, 25);
		panel.add(tfAccountHolderCNP);
		panel.add(tfBalance);
		
		rdbtnSavingAccount.setBounds(170, 90, 150, 25);
		rdbtnSavingAccount.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if(rdbtnSpendingAccount.isSelected() == true)
				{
					rdbtnSpendingAccount.setSelected(false);
				}
			}
		});
		rdbtnSpendingAccount.setBounds(170, 125, 150, 25);
		rdbtnSpendingAccount.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if(rdbtnSavingAccount.isSelected() == true)
				{
					rdbtnSavingAccount.setSelected(false);
				}
			}
		});
		panel.add(rdbtnSavingAccount);
		panel.add(rdbtnSpendingAccount);
		
		btnAdd.setBackground(Color.BLACK);
		btnAdd.setForeground(Color.WHITE);
		btnAdd.setBounds(120, 175, 100, 30);
		panel.add(btnAdd);
		
		getContentPane().add(panel);
	}
	
	public String getHolderCNP()
	{
		return tfAccountHolderCNP.getText();
	}
	
	public Double getBalance()
	{
		if(Double.valueOf(tfBalance.getText()) != null)	return Double.valueOf(tfBalance.getText());
		return 0.0;
	}
	
	public void addAccountActionListener(ActionListener aal)
	{
		btnAdd.addActionListener(aal);
	}
}
