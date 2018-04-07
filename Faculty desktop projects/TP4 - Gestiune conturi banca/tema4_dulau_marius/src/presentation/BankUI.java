package presentation;

import javax.swing.*;
import javax.swing.table.JTableHeader;

import MyException.MyException;
import model.*;
import model.Observer;

import java.awt.Color;
import java.awt.Component;
import java.awt.event.*;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.util.*;

import presentation.*;

public class BankUI extends JFrame{
	
	private static final int WIDTH = 800, HEIGHT = 500;
	
	private JPanel pane = new JPanel();
	private JPanel operationPanel = new JPanel();
	
	private JButton btnTable = new JButton("View accounts");
	private JButton btnAdd = new JButton("Add person");
	private JButton btnEditDelete = new JButton("Edit/Delete person");
	private JButton btnLogout = new JButton("Logout");
	private JSeparator separator = new JSeparator();
	private JTable table = new JTable();
	private JScrollPane scrollPane;
	private JTableHeader header;
	private JButton btnDepositWithdraw = new JButton("Deposit/withdraw");
	
	AddPerson addPerson;
	EditDeletePerson editDeletePerson;
	AddAccount addAccount;
	EditDeleteAccount editDeleteAccount;
	DepositWithdraw transaction;
	
	Bank b = new Bank();
	Map m;
	Person p = new Person("1234567890123", "test", "test", "test");
	Account a = new Account(0, p, 0.0);
	
	public BankUI(String name)
	{
		super(name);
		setResizable(false);
		this.setDefaultCloseOperation(EXIT_ON_CLOSE);
		this.setSize(WIDTH, HEIGHT);
		this.setVisible(true);
		
		pane.setLayout(null);
		operationPanel.setLayout(null);
		operationPanel.setBounds(10, 10, 200, 430);
		pane.add(operationPanel);
		btnTable.setBackground(Color.RED);
		btnTable.setForeground(Color.WHITE);
		
		btnTable.setBounds(10, 10, 180, 30);
		operationPanel.add(btnTable);
		btnAdd.setBackground(Color.RED);
		btnAdd.setForeground(Color.WHITE);
		btnAdd.setBounds(10, 51, 180, 30);
		
		operationPanel.add(btnAdd);
		btnEditDelete.setBackground(Color.RED);
		btnEditDelete.setForeground(Color.WHITE);
		btnEditDelete.setBounds(10, 92, 180, 30);
		
		operationPanel.add(btnEditDelete);
		btnLogout.setForeground(Color.WHITE);
		btnLogout.setBackground(Color.RED);
		btnLogout.setBounds(10, 389, 180, 30);
		
		operationPanel.add(btnLogout);
		btnDepositWithdraw.setForeground(Color.WHITE);
		btnDepositWithdraw.setBackground(Color.RED);
		btnDepositWithdraw.setBounds(10, 133, 180, 30);
		btnDepositWithdraw.setVisible(false);
		
		operationPanel.add(btnDepositWithdraw);
		
		separator.setOrientation(SwingConstants.VERTICAL);
		separator.setBounds(220, 10, 2, 430);
		pane.add(separator);
		
		getContentPane().add(pane);
		
		readBank();
		table.setBounds(232, 10, 542, 430);
		table.setFillsViewportHeight(true);
		table = b.createTable(p);
		
		header = table.getTableHeader();
		header.setBackground(Color.RED);
		header.setForeground(Color.WHITE);
		
		table.addMouseListener(new MouseAdapter(){
			@Override
			public void mouseClicked(MouseEvent arg0) {
				// TODO Auto-generated method stub
				JOptionPane.showMessageDialog(null, table.getColumnModel().getColumn(table.getSelectedColumn()).getHeaderValue() + " = " + table.getValueAt(table.getSelectedRow(), table.getSelectedColumn()).toString());
			}
		});
		
		scrollPane = new JScrollPane(table);
		scrollPane.setBounds(232, 10, 542, 430);
		pane.add(scrollPane);
		
		viewTableActionListener();
		addActionListener();
		editDeleteActionListener();
		transactionAction();
		logoutActionListener();
	}
	
	//citim fisierul cu map corespunzator clasei Bank
	private void readBank()
	{
		try {
			FileInputStream f = new FileInputStream("bank.ser");
			ObjectInputStream i = new ObjectInputStream(f);
			
			m = (Map)i.readObject();
			b.setMap(m);
//			System.out.println(b.toString());
			i.close();
			f.close();
		} catch (FileNotFoundException e) {
			System.out.println("File not found");
		} catch (IOException e) {
			System.out.println("Error initializing stream");
		} catch (ClassNotFoundException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	private void viewTableActionListener()
	{
		btnTable.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent arg0) {
				// TODO Auto-generated method stub
				if(btnTable.getText().compareTo("View persons") == 0)
				{
					setData("person");
					refreshTablePerson();
				}
				else if(btnTable.getText().compareTo("View accounts") == 0)
				{
					setData("account");
					refreshTableAccount();
				}
			}
		});
	}
	
	//setam textul si culoarea butoanleor
	private void setData(String arg)
	{
		if(arg.compareTo("person") == 0) 
		{
			header.setBackground(Color.RED);
			btnEditDelete.setText("Edit/Delete person");
			btnDepositWithdraw.setVisible(false);
		}
		else
		{
			header.setBackground(Color.BLACK);
			btnEditDelete.setText("Delete account");
			btnDepositWithdraw.setVisible(true);
		}
		
		for(Component b : operationPanel.getComponents())
		{
			if(b instanceof JButton)
			{
				if(arg.compareTo("person") == 0) b.setBackground(Color.RED);
				else if(arg.compareTo("account") == 0) b.setBackground(Color.BLACK);
			}
		}
		
		if(arg.compareTo("person") == 0) btnTable.setText("View " + "account" + "s");
		else if(arg.compareTo("account") == 0) btnTable.setText("View " + "person" + "s");
		btnAdd.setText("Add " + arg);
	}
	
	//deschidem fereastra de adaugare persoana
	private void addActionListener()
	{
		btnAdd.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent arg0) {
				// TODO Auto-generated method stub
				if(btnAdd.getText().compareTo("Add person") == 0)
				{
					addPerson = new AddPerson("Add person");
					addPerson.addPersonActionListener(new AddPersonActionListener());
				}
				else
				{
					addAccount = new AddAccount("Add account");
					addAccount.addAccountActionListener(new AddAccountActionListener());
				}
			}
		});
	}
	
	//deschidem fereastra de editare persoana
	private void editDeleteActionListener()
	{
		btnEditDelete.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				if(btnEditDelete.getText().compareTo("Edit/Delete person") == 0)
				{
					editDeletePerson = new EditDeletePerson("Edit/Delete person");
					editDeletePerson.setHeight(84);
					editDeletePerson.cnpOkActionListener(new cnpOKActionListener());
					editDeletePerson.editActionListener(new EditActionListener());
					editDeletePerson.deleteActionListener(new DeleteActionListener());
				}
				else
				{
					editDeleteAccount = new EditDeleteAccount("Edit/Delete account");
					editDeleteAccount.setHeight(84);
					editDeleteAccount.btnOkAction(new cnpOK2ActionListener());
					editDeleteAccount.deleteAction(new DeleteAccountActionListener());
				}
			}		
		});
	}
	
	//deschidem fereastra pentru transactii (depunere/retragere numerar)
	private void transactionAction()
	{
		btnDepositWithdraw.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent arg0) {
				// TODO Auto-generated method stub
				transaction = new DepositWithdraw("Deposit or Withdraw");
				transaction.setHeight(84);
				transaction.btnOkAction(new cnpOK3ActionListener());
				transaction.btnDepositAction(new DepositActionListener());
				transaction.btnWithdrawAction(new WithdrawActionListener());
			}
		});
	}
	
	//scriem map-ul din clasa Bank intr-un fisier
	private void logoutActionListener()
	{
		btnLogout.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e)
			{
				try {
					FileOutputStream f = new FileOutputStream("bank.ser");
					ObjectOutputStream o = new ObjectOutputStream(f);
					
					o.writeObject(b.getMap());
					
					o.close();
					f.close();
				}  catch (FileNotFoundException e1) {
					System.out.println("File not found");
				} catch (IOException e1) {
					System.out.println("Error initializing stream");
				}
				
				setVisible(false);
				dispose();
			}
		});
	}
	
	//punem persoane in tabel
	public void refreshTablePerson()
	{
		table = b.createTable(p);
		table.setFillsViewportHeight(true);
		header = table.getTableHeader();
		header.setBackground(Color.RED);
		header.setForeground(Color.WHITE);
		scrollPane.setViewportView(table);
	}
	
	//punem conturi in tabel
	public void refreshTableAccount()
	{
		table = b.createTable(a);
		table.setFillsViewportHeight(true);
		header = table.getTableHeader();
		header.setBackground(Color.BLACK);
		header.setForeground(Color.WHITE);
		scrollPane.setViewportView(table);
	}
	
	//action listener pentru adaugare persoana
	class AddPersonActionListener implements ActionListener
	{
		@Override
		public void actionPerformed(ActionEvent arg0) {
			// TODO Auto-generated method stub
			b.addPerson(addPerson.getPerson());
			refreshTablePerson();
			addPerson.setVisible(false);
			addPerson.dispose();
		}	
	}
	
	//action listener pentru gasirea unei persoane dupa cnp
	class cnpOKActionListener implements ActionListener
	{
		@Override
		public void actionPerformed(ActionEvent arg0) {
			// TODO Auto-generated method stub
			Person p = b.findPerson(editDeletePerson.getCNP());
			
			if(p != null)
			{
				editDeletePerson.setHeight(270);
				editDeletePerson.tfCNP.setEditable(false);
				editDeletePerson.setSize(editDeletePerson.getWidth(), editDeletePerson.getHeight());
				editDeletePerson.setFirstName(p.getFirstName());
				editDeletePerson.setLastName(p.getLastName());
				editDeletePerson.setAddress(p.getAddress());
			}
			else
			{
				JOptionPane.showMessageDialog(pane, "Person with cnp = " + editDeletePerson.getCNP() + " does not exits!");
			}
		}
	}
	
	//action listener pentru editare persoana
	class EditActionListener implements ActionListener
	{
		@Override
		public void actionPerformed(ActionEvent arg0) {
			// TODO Auto-generated method stub
			Person p = b.findPerson(editDeletePerson.getCNP());
			
			p.setFirstName(editDeletePerson.getFirstName());
			p.setLastName(editDeletePerson.getLastName());
			p.setAddress(editDeletePerson.getAddress());
			
			refreshTablePerson();
			
			editDeletePerson.setVisible(false);
			editDeletePerson.dispose();
		}
	}
	
	//action listener pentru stergere persoane
	class DeleteActionListener implements ActionListener
	{
		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			Person p = b.findPerson(editDeletePerson.getCNP());
			if(p != null)
			{
				b.removePerson(p);
				refreshTablePerson();
				
				editDeletePerson.setVisible(false);
				editDeletePerson.dispose();
			}
		}	
	}
	
	//action listener pentru adaugare account
	class AddAccountActionListener implements ActionListener
	{
		@Override
		public void actionPerformed(ActionEvent arg0) {
			// TODO Auto-generated method stub
			
			Person p;
			if((p = b.findPerson(addAccount.getHolderCNP())) != null)
			{
				Account a = null;
				
				if(addAccount.rdbtnSavingAccount.isSelected() == true)
				{
					a = new SavingAccount(b.getMaxAccountId() + 1, p, addAccount.getBalance());
					p.attach(new Observer((SavingAccount)a));
				}
				else if(addAccount.rdbtnSpendingAccount.isSelected() == true)
				{
					a = new SpendingAccount(b.getMaxAccountId() + 1, p, addAccount.getBalance());
				}
				
				b.addAccount(a);
				refreshTableAccount();
				addAccount.setVisible(false);
				addAccount.dispose();
			}
			else
			{
				JOptionPane.showMessageDialog(addAccount.panel, "CNP invalid!");
			}
		}	
	}
	
	//action listener pentru gasirea unei persoane dupa cnp in fereastra de stergere a unui cont
	class cnpOK2ActionListener implements ActionListener
	{
		@Override
		public void actionPerformed(ActionEvent arg0) {
			// TODO Auto-generated method stub
			Person p = b.findPerson(editDeleteAccount.getHolderCNP());
			
			if(p != null)
			{
				editDeleteAccount.setHeight(320);
				editDeleteAccount.tfAccountHolderCNP.setEditable(false);
				editDeleteAccount.setSize(editDeleteAccount.getWidth(), editDeleteAccount.getHeight());
				editDeleteAccount.accounts = b.readAccounts(p);
				editDeleteAccount.showData();
				
				for(Account a : editDeleteAccount.accounts)
				{
					editDeleteAccount.cbAccounts.addItem(a.getAccountId());
				}
			}
			else
			{
				JOptionPane.showMessageDialog(pane, "Person with cnp = " + editDeleteAccount.getHolderCNP() + " does not exits!");
			}
		}
	}

	//action listener pentru stergerea unui cont
	class DeleteAccountActionListener implements ActionListener
	{
		@Override
		public void actionPerformed(ActionEvent e) {
			// TODO Auto-generated method stub
			if(editDeleteAccount.myAccount.getBalance() < 0.001)
			{
				b.removeAccount(editDeleteAccount.myAccount);
				refreshTableAccount();
				editDeleteAccount.setVisible(true);
				editDeleteAccount.dispose();
			}
			else
			{
				JOptionPane.showMessageDialog(editDeleteAccount.panel, "Balance must be 0!");
			}
		}
	}

	//action listener pentru gasirea unei persoane dupa cnp in fereastra de stergere a unui cont
	class cnpOK3ActionListener implements ActionListener
	{
		@Override
		public void actionPerformed(ActionEvent arg0) {
			// TODO Auto-generated method stub
			Person p = b.findPerson(transaction.getHolderCNP());
			
			if(p != null)
			{
				transaction.setHeight(350);
				transaction.tfAccountHolderCNP.setEditable(false);
				transaction.setSize(transaction.getWidth(), transaction.getHeight());
				transaction.accounts = b.readAccounts(p);
				transaction.showData();
				
				for(Account a : transaction.accounts)
				{
					transaction.cbAccounts.addItem(a.getAccountId());
				}
			}
			else
			{
				JOptionPane.showMessageDialog(pane, "Person with cnp = " + transaction.getHolderCNP() + " does not exits!");
			}
		}
	}

	//cod pentru momentul cand apasam pe butonul Deposit din fereastra de depunere/retragere numerar
	class DepositActionListener implements ActionListener
	{
		@Override
		public void actionPerformed(ActionEvent arg0) {
			// TODO Auto-generated method stub
			try {
				transaction.myAccount.deposit(transaction.getSum());
				
				refreshTableAccount();
				transaction.setVisible(true);
				transaction.dispose();
			} catch (MyException e) {
				// TODO Auto-generated catch block
				JOptionPane.showMessageDialog(transaction.panel, e);
			}
		}	
	}

	//cod pentru momentul cand apasam pe butonul Withdraw din fereastra de depunere/retragere numerar
	class WithdrawActionListener implements ActionListener
	{
		@Override
		public void actionPerformed(ActionEvent arg0) {
			// TODO Auto-generated method stub
			try {
				transaction.myAccount.withdraw(transaction.getSum());
				
				refreshTableAccount();
				transaction.setVisible(true);
				transaction.dispose();
			} catch (MyException e) {
				// TODO Auto-generated catch block
				JOptionPane.showMessageDialog(transaction.panel, e);
			}
		}	
	}
}
