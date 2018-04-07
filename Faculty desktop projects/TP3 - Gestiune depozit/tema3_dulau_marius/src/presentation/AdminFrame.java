package presentation;

import javax.swing.*;
import javax.swing.table.AbstractTableModel;
import javax.swing.table.DefaultTableModel;
import javax.swing.table.TableModel;

import java.awt.event.ActionListener;
import java.util.List;
import java.awt.event.ActionEvent;
import java.awt.Color;
import java.awt.event.*;

import model.Customer;
import model.Product;
import model.Stock;
import bll.ProductBLL;
import bll.StockBLL;
import dao.ReflectionDAO;

public class AdminFrame extends JFrame{

	private static int WIDTH = 800, HEIGHT = 400;
	private JPanel panel = new JPanel();
	private JTable table = new JTable();
	private JScrollPane scrollPane;
	private JButton btnAddProduct = new JButton("Add product");
	private JButton btnEditProduct = new JButton("Edit/Delete product");
	private JButton btnLogout = new JButton("Logout");
	
	private AdaugaProdus adaugaProdus;
	private EditProduct editProduct;
	private List<Object> objects;
	private Product test = new Product("test", 1);
	private Customer testCustomer = new Customer(0, "test", "test", "test", 30, "test", "test@test.com", "0123456789");
	private JButton btnTabel = new JButton("Show customers");
	
	private ProductBLL productBLL = new ProductBLL();
	private StockBLL stockBLL = new StockBLL();
	private Product p = null;
	private Stock s = null;
	
	public AdminFrame(String name)
	{
		super(name);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setResizable(false);
		this.setSize(WIDTH, HEIGHT);
		
		panel.setLayout(null);
		
		table.setBounds(232, 30, 540, 310);
		//panel.add(table);
		
		btnAddProduct.setBounds(20, 78, 150, 35);
		btnAddProduct.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent arg0) 
			{
				// TODO Auto-generated method stub
				adaugaProdus = new AdaugaProdus("Adauga produs");
				adaugaProdus.setVisible(true);
				adaugaProdus.addProductListener(new AddProductListener());
			}
			
		});
		
		panel.add(btnAddProduct);
		
		btnEditProduct.setBounds(20, 124, 150, 35);
		btnEditProduct.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent arg0) 
			{
				// TODO Auto-generated method stub
				editProduct = new EditProduct("Edit product");
				editProduct.setVisible(true);
				editProduct.addUpdateProductListener(new AddUpdateProductListener());
				editProduct.addDeleteProductListener(new AddDeleteProductListener());
			}
			
		});
		panel.add(btnEditProduct);
		
		btnLogout.setBounds(20, 170, 150, 35);
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
		getContentPane().add(panel);
		
		btnTabel.setBounds(20, 32, 150, 35);
		btnTabel.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent arg0) {
				// TODO Auto-generated method stub
				if(btnTabel.getText().compareTo("Show customers") == 0)
				{
					objects = ReflectionDAO.createListOfObject(testCustomer);
					btnTabel.setText("Show products");
				}
				else
				{
					objects = ReflectionDAO.createListOfObject(test);
					btnTabel.setText("Show customers");
				}
				
				table = ReflectionDAO.createTable(objects);
				table.setFillsViewportHeight(true);
				scrollPane.setViewportView(table);
			}
			
		});
		panel.add(btnTabel);
	}
	
	class AddProductListener implements ActionListener
	{
		@Override
		public void actionPerformed(ActionEvent arg0) {
			// TODO Auto-generated method stub
			ProductBLL productBLL = new ProductBLL();
			Product p = new Product(adaugaProdus.getProduct(), adaugaProdus.getPrice());
			Object[] campuri = {"productName"};
			
			try
			{
				productBLL.insertProduct(p);
				p = (Product)productBLL.find(p, campuri);
				Stock s = new Stock(p.getProductId(), adaugaProdus.getStock());
				StockBLL stockBLL = new StockBLL();
				stockBLL.insert(s);
				adaugaProdus.setVisible(false);
				adaugaProdus.dispose();
				
				objects = ReflectionDAO.createListOfObject(p);
				table = ReflectionDAO.createTable(objects);
				table.setFillsViewportHeight(true);
				scrollPane.setViewportView(table);
				JOptionPane.showMessageDialog(panel, "Product successfully added");
				//System.out.println(p.getProductId());
			}
			catch(Exception ex)
			{
				JOptionPane.showMessageDialog(panel, ex);
			}
			//System.out.println("Merge admin");
		}
	}
	
	class AddUpdateProductListener implements ActionListener
	{
		@Override
		public void actionPerformed(ActionEvent arg0) {
			// TODO Auto-generated method stub			
			try
			{
				p = editProduct.getProductUpdate();
				productBLL.updateProduct(p);
				s = editProduct.getStockUpdate();
				stockBLL.update(s);
				
				objects = ReflectionDAO.createListOfObject(p);
				table = ReflectionDAO.createTable(objects);
				table.setFillsViewportHeight(true);
				scrollPane.setViewportView(table);
				
				editProduct.setVisible(false);
				editProduct.dispose();
				
				JOptionPane.showMessageDialog(panel, "Product/Stock successfully edited");
				//System.out.println(p.getProductId());
			}
			catch(Exception ex)
			{
				JOptionPane.showMessageDialog(panel, ex);
			}
			//System.out.println("Merge admin");
		}
	}
	
	class AddDeleteProductListener implements ActionListener
	{
		@Override
		public void actionPerformed(ActionEvent arg0) {
			// TODO Auto-generated method stub
			try
			{
				p = editProduct.getProductUpdate();
				productBLL.deleteProduct(p);
						
				objects = ReflectionDAO.createListOfObject(p);
				table = ReflectionDAO.createTable(objects);
				table.setFillsViewportHeight(true);
				scrollPane.setViewportView(table);
				
				editProduct.setVisible(false);
				editProduct.dispose();
				
				JOptionPane.showMessageDialog(panel, "Product successfully deleted");
				//System.out.println(p.getProductId());
			}
			catch(Exception ex)
			{
				JOptionPane.showMessageDialog(panel, ex);
			}
		}
	}
}
