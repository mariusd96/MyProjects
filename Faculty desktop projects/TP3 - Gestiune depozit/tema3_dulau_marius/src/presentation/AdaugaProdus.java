package presentation;

import javax.swing.*;
import java.awt.event.*;

public class AdaugaProdus extends JFrame{

	private static int WIDTH = 350, HEIGHT = 250;
	private JPanel panel = new JPanel();
	
	private JLabel lblProduct = new JLabel("Product");
	private JLabel lblPrice = new JLabel("Price");
	private JLabel lblStock = new JLabel("Stock");
	
	private JTextField tfProduct = new JTextField();
	private JTextField tfPrice = new JTextField();
	private JTextField tfStock = new JTextField();
	private JButton btnAdd = new JButton("Add");
	
	public AdaugaProdus(String name)
	{
		super(name);
		this.setSize(WIDTH, HEIGHT);
		setResizable(false);
		panel.setLayout(null);
		
		lblProduct.setBounds(20, 30, 100, 25);
		tfProduct.setBounds(120, 30, 200, 25);
		lblPrice.setBounds(20, 70, 100, 25);
		tfPrice.setBounds(120, 70, 200, 25);
		lblStock.setBounds(20, 110, 100, 25);
		tfStock.setBounds(120, 110, 200, 25);
		
		panel.add(lblProduct);
		panel.add(lblPrice);
		panel.add(lblStock);
		
		panel.add(tfProduct);
		panel.add(tfPrice);
		panel.add(tfStock);
		
		btnAdd.setBounds(110, 165, 130, 35);
		panel.add(btnAdd);
		
		getContentPane().add(panel);
	}
	
	public String getProduct()
	{
		return tfProduct.getText();
	}
	
	public double getPrice()
	{
		return Double.parseDouble(tfPrice.getText());
	}
	
	public int getStock()
	{
		return Integer.parseInt(tfStock.getText());
	}
	
	public void addProductListener(ActionListener apl)
	{
		btnAdd.addActionListener(apl);
	}
}
