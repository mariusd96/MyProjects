package presentation;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.util.List;

import javax.swing.*;

import dao.ReflectionDAO;
import model.Product;
import model.Stock;

public class EditProduct extends JFrame{

	private static int WIDTH = 350, HEIGHT = 250;
	private JPanel panel = new JPanel();
	
	private JLabel lblProduct = new JLabel("Product");
	private JLabel lblPrice = new JLabel("Price");
	private JLabel lblStock = new JLabel("Stock");
	
	private JComboBox cbProduct = new JComboBox();
	private JTextField tfPrice = new JTextField();
	private JTextField tfStock = new JTextField();
	private JButton btnUpdate = new JButton("Update");
	
	private List<Object> objects;
	private Product test = new Product("test", 1);
	private List<Object> objects2;
	private Stock test2 = new Stock(1, 1);
	private final JButton btnDelete = new JButton("Delete");
	
	public EditProduct(String name)
	{
		super(name);
		this.setSize(WIDTH, HEIGHT);
		setResizable(false);
		panel.setLayout(null);
		
		lblProduct.setBounds(20, 30, 100, 25);
		cbProduct.setBounds(120, 30, 200, 25);
		cbProduct.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent arg0) {
				// TODO Auto-generated method stub
				for(int i = 0; i < objects.size(); i++)
				{
					if(cbProduct.getSelectedItem().toString().compareTo(((Product)objects.get(i)).getProductName()) == 0)
					{
						tfPrice.setText(String.valueOf(((Product)objects.get(i)).getPrice()));
						tfStock.setText(String.valueOf(((Stock)objects2.get(i)).getQuantity()));
					}
				}
			}
		});
		
		lblPrice.setBounds(20, 70, 100, 25);
		tfPrice.setBounds(120, 70, 200, 25);
		lblStock.setBounds(20, 110, 100, 25);
		tfStock.setBounds(120, 110, 200, 25);
		
		panel.add(lblProduct);
		panel.add(lblPrice);
		panel.add(lblStock);
		
		panel.add(cbProduct);
		panel.add(tfPrice);
		panel.add(tfStock);
		
		btnUpdate.setBounds(20, 165, 130, 35);
		panel.add(btnUpdate);
		btnDelete.setBounds(190, 165, 130, 35);
		panel.add(btnDelete);
		
		populateComboBox();
		getContentPane().add(panel);
	}
	
	private void populateComboBox()
	{
		objects = ReflectionDAO.createListOfObject(test);
		objects2 = ReflectionDAO.createListOfObject(test2);
		
		for(int i = 0; i < objects.size(); i++)
		{
			cbProduct.addItem(((Product)objects.get(i)).getProductName());
		}
	}
	
	public String getProduct()
	{
		return cbProduct.getSelectedItem().toString();
	}
	
	public double getPrice()
	{
		return Double.parseDouble(tfPrice.getText());
	}
	
	public int getStock()
	{
		return Integer.parseInt(tfStock.getText());
	}
	
	public void addUpdateProductListener(ActionListener upl)
	{
		btnUpdate.addActionListener(upl);
	}
	
	public void addDeleteProductListener(ActionListener dpl)
	{
		btnDelete.addActionListener(dpl);
	}
	
	public Product getProductUpdate()
	{
		Product p = null;
		
		for(int i = 0; i < objects.size(); i++)
		{
			if(cbProduct.getSelectedItem().toString().compareTo(((Product)objects.get(i)).getProductName()) == 0)
			{
				p = (Product)objects.get(i);
			}
		}
		p.setPrice(getPrice());
		
		return p;
	}
	
	public Stock getStockUpdate()
	{
		Stock s = null;
		
		for(int i = 0; i < objects.size(); i++)
		{
			if(cbProduct.getSelectedItem().toString().compareTo(((Product)objects.get(i)).getProductName()) == 0)
			{
				s = (Stock)objects2.get(i);
			}
		}
		s.setQuantity(getStock());
		
		return s;
	}
}
