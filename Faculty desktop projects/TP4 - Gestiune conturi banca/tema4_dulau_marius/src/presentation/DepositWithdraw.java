package presentation;

import java.awt.Color;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.HashSet;

import javax.swing.*;

import MyException.MyException;
import model.Account;
import model.SavingAccount;
import model.SpendingAccount;

public class DepositWithdraw extends JFrame{
	
	private static final int WIDTH = 450;
	private static int HEIGHT = 350;
	
	public JPanel panel = new JPanel();
	private JLabel lblAccountHolderCNP = new JLabel("Account Holder CNP");
	private JLabel lblAccountId = new JLabel("Account Id");
	private JLabel lblBalance = new JLabel("Balance");
	private JLabel lblAccountType = new JLabel("Account Type");
	public JTextField tfAccountHolderCNP = new JTextField();
	public JComboBox cbAccounts = new JComboBox();
	private JTextField tfBalance = new JTextField();
	public JRadioButton rdbtnSavingAccount = new JRadioButton("Saving Account");
	public JRadioButton rdbtnSpendingAccount = new JRadioButton("Spending Account");
	private JButton btnDeposit = new JButton("Deposit");
	private JButton btnWithdraw = new JButton("Withdraw");
	private JButton btnOk = new JButton("Ok");
	private JLabel lblSum = new JLabel("Sum");
	public JTextField tfSum = new JTextField();
	public HashSet<Account> accounts = new HashSet<>();
	public Account myAccount;
	
	public DepositWithdraw(String name)
	{
		super(name);
		setResizable(false);
		this.setDefaultCloseOperation(DISPOSE_ON_CLOSE);
		this.setVisible(true);
		this.setSize(WIDTH, HEIGHT);
		panel.setLayout(null);
		
		lblAccountHolderCNP.setBounds(20, 20, 120, 25);
		lblAccountId.setBounds(20, 55, 120, 25);
		lblBalance.setBounds(20, 90, 120, 25);
		lblAccountType.setBounds(20, 125, 120, 25);
		panel.add(lblAccountHolderCNP);
		panel.add(lblAccountId);
		panel.add(lblBalance);
		panel.add(lblAccountType);
		
		tfAccountHolderCNP.setBounds(170, 20, 150, 25);
		cbAccounts.setBounds(170, 55, 150, 25);
		tfBalance.setEditable(false);
		tfBalance.setBounds(170, 90, 150, 25);
		panel.add(tfAccountHolderCNP);
		panel.add(cbAccounts);
		panel.add(tfBalance);
		rdbtnSavingAccount.setEnabled(false);
		
		rdbtnSavingAccount.setBounds(170, 125, 150, 25);
		rdbtnSavingAccount.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if(rdbtnSpendingAccount.isSelected() == true)
				{
					rdbtnSpendingAccount.setSelected(false);
				}
			}
		});
		rdbtnSpendingAccount.setEnabled(false);
		rdbtnSpendingAccount.setBounds(170, 160, 150, 25);
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
		
		lblSum.setBounds(20, 210, 120, 25);
		tfSum.setBounds(170, 210, 150, 25);
		panel.add(lblSum);
		panel.add(tfSum);
		
		btnOk.setForeground(Color.WHITE);
		btnOk.setBackground(Color.BLACK);
		btnOk.setBounds(340, 20, 70, 25);
		panel.add(btnOk);
		
		btnDeposit.setForeground(Color.WHITE);
		btnDeposit.setBackground(Color.BLACK);
		btnDeposit.setBounds(20, 270, 100, 30);
		panel.add(btnDeposit);
		
		btnWithdraw.setForeground(Color.WHITE);
		btnWithdraw.setBackground(Color.BLACK);
		btnWithdraw.setBounds(220, 270, 100, 30);
		panel.add(btnWithdraw);
		
		getContentPane().add(panel);
	}

	public String getHolderCNP()
	{
		return tfAccountHolderCNP.getText();
	}
	
	public void setBalanceTextField(double sum)
	{
		tfBalance.setText(String.valueOf(sum));
	}
	
	public Double getSum() throws MyException
	{
		if(Double.valueOf(tfSum.getText()) != null)	return Double.valueOf(tfSum.getText());
		else throw new MyException("Insert valid sum!");
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
	
	public void btnOkAction(ActionListener okAL)
	{
		btnOk.addActionListener(okAL);
	}
	
	public void btnDepositAction(ActionListener eAL)
	{
		btnDeposit.addActionListener(eAL);
	}
	
	public void btnWithdrawAction(ActionListener wAL)
	{
		btnWithdraw.addActionListener(wAL);
	}
	
	public void showData()
	{
		cbAccounts.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				for(Account a : accounts)
				{
					if(a.getAccountId() == Integer.valueOf(cbAccounts.getSelectedItem().toString()))
					{
						myAccount = a;
						setBalanceTextField(a.getBalance());
						rdbtnSavingAccount.setSelected(false);
						rdbtnSpendingAccount.setSelected(false);
						if(a instanceof SavingAccount) rdbtnSavingAccount.setSelected(true);
						else if(a instanceof SpendingAccount) rdbtnSpendingAccount.setSelected(true);
						break;
					}
				}
			}
		});
	}
}
