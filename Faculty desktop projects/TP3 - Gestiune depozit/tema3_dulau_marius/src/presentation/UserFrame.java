package presentation;

import java.awt.Color;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.List;

import javax.swing.*;

import bll.AccountBLL;
import bll.CustomerBLL;
import dao.ReflectionDAO;
import model.Account;
import model.Customer;
import model.Product;

public class UserFrame extends JFrame{
	
	private static int WIDTH = 800, HEIGHT = 400;
	private JPanel panel = new JPanel();
	private JTable table = new JTable();
	private JScrollPane scrollPane;
	private JButton btnOrder = new JButton("Order");
	private JButton btnLogout = new JButton("Logout");
	
	private List<Object> objects;
	private Product test = new Product("test", 1);
	private JButton btnEditProfile = new JButton("Edit profile data");
	
	private Account myAccount;
	private AccountBLL accountBLL = new AccountBLL();
	private Customer customer = new Customer(0, "test", "test", "test", 30, "test", "test@test.com", "0123456789");
	private CustomerBLL customerBLL = new CustomerBLL();
	
	private JButton btnDeleteAccount = new JButton("Delete account");
	
	private EditProfile editProfile;
	private OrderManagement orderManagement;
	private Object[] campuri ={"username"};
	
	public UserFrame(String name, Account a)
	{
		super(name);
		myAccount = a;
		setResizable(false);
		this.setSize(WIDTH, HEIGHT);
		
		panel.setLayout(null);
		
		table.setBounds(232, 30, 540, 310);
		btnOrder.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				customer.setUsername(myAccount.getUsername());
				customer = (Customer)customerBLL.findCustomerByUser(customer, campuri);
				orderManagement = new OrderManagement("Order", customer);
				orderManagement.setVisible(true);
			}
		});
		//panel.add(table);
		
		btnOrder.setBounds(20, 30, 150, 35);
		panel.add(btnOrder);
		
		btnLogout.setBounds(20, 305, 150, 35);
		btnLogout.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e) {
				// TODO Auto-generated method stub
				setVisible(false);
				System.exit(0);			
			}
		});
		panel.add(btnLogout);
		
		JSeparator separator = new JSeparator();
		separator.setForeground(Color.GRAY);
		separator.setOrientation(SwingConstants.VERTICAL);
		separator.setBounds(200, 30, 2, 310);
		panel.add(separator);
		
		objects = ReflectionDAO.createListOfObject(test);
		table = ReflectionDAO.createTable(objects);
		scrollPane = new JScrollPane(table);
		scrollPane.setBounds(232, 30, 540, 310);
		table.setFillsViewportHeight(true);
		
		panel.add(scrollPane);
		btnEditProfile.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				editProfile = new EditProfile("Edit", a);
				editProfile.setVisible(true);
				editProfile.addEditCustomerListener(new AddEditCustomerListener());
			}
		});
		
		btnEditProfile.setBounds(20, 76, 150, 35);
		panel.add(btnEditProfile);
	
		btnDeleteAccount.setBounds(20, 122, 150, 35);
		btnDeleteAccount.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent arg0) {
				// TODO Auto-generated method stub
				try
				{
					accountBLL.deleteAccount(myAccount);
					JOptionPane.showMessageDialog(panel, "Account deleted");
					setVisible(false);
					System.exit(0);
				}
				catch(Exception ex)
				{
					JOptionPane.showMessageDialog(panel, ex);
				}
			}
		});
		panel.add(btnDeleteAccount);
		
		getContentPane().add(panel);
	}

	
	class AddEditCustomerListener implements ActionListener{
		@Override
		public void actionPerformed(ActionEvent arg0) {
			// TODO Auto-generated method stub
			try
			{
				Customer c = editProfile.getCustomer();
				customerBLL.updateCustomer(c);
				
				editProfile.setVisible(false);
				editProfile.dispose();
				
				JOptionPane.showMessageDialog(panel, "Profile edited successfully");
			}
			catch(Exception ex)
			{
				JOptionPane.showMessageDialog(panel, ex.toString());
			}
		}
		
	}
}
