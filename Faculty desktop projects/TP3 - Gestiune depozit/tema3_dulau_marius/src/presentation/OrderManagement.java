package presentation;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.List;

import javax.swing.*;

import bll.OrderDetailBLL;
import bll.OrdersBLL;
import bll.StockBLL;
import dao.ReflectionDAO;
import mail.SendMail;
import model.Customer;
import model.OrderDetail;
import model.Orders;
import model.Product;
import model.Stock;

import java.util.ArrayList;
import java.util.Date;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;

import com.itextpdf.text.Anchor;
import com.itextpdf.text.BadElementException;
import com.itextpdf.text.BaseColor;
import com.itextpdf.text.Chapter;
import com.itextpdf.text.Document;
import com.itextpdf.text.DocumentException;
import com.itextpdf.text.Element;
import com.itextpdf.text.Font;
import com.itextpdf.text.ListItem;
import com.itextpdf.text.Paragraph;
import com.itextpdf.text.Phrase;
import com.itextpdf.text.Section;
import com.itextpdf.text.pdf.PdfPCell;
import com.itextpdf.text.pdf.PdfPTable;
import com.itextpdf.text.pdf.PdfWriter;

public class OrderManagement extends JFrame{

	private static int WIDTH = 750, HEIGHT = 350;
	private JPanel panel = new JPanel();
	
	private JLabel lblProduct = new JLabel("Product");
	private JLabel lblPrice = new JLabel("Price");
	private JLabel lblStock = new JLabel("Stock");
	
	private JComboBox cbProduct = new JComboBox();
	private JTextField tfPrice = new JTextField();
	private JTextField tfStock = new JTextField();
	private JButton btnAddToCart = new JButton("Add");
	
	private List<Object> objects;
	private Product test = new Product("test", 1);
	private List<Object> objects2;
	private Stock test2 = new Stock(1, 1);
	private JTextField tfQuantity = new JTextField();
	private JLabel lblYourQuantity = new JLabel("Your quantity");
	private JTextArea textArea = new JTextArea();
	private JScrollPane scrollPane = new JScrollPane();
	private JButton btnOrder = new JButton("Order");
	private JLabel lblTotalPrice = new JLabel("Total price = ");
	
	private Product p;
	private Stock s;
	private Customer myCustomer;
	
	private OrderDetail orderDetail;
	private Orders order;
	private OrdersBLL ordersBLL = new OrdersBLL();
	private OrderDetailBLL orderDetailBLL = new OrderDetailBLL();
	private StockBLL stockBLL = new StockBLL();
	private List<Object> orderObjects = new ArrayList<Object>();
	private List<String> productName = new ArrayList<String>();
	private List<OrderDetail> orderDetailObjects = new ArrayList<OrderDetail>();
	DateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
	Date date = new Date();
	private double totalPrice;
	private Object[] campuri = {"customerId", "orderDate"};
	
	private static Font myFont = new Font(Font.FontFamily.TIMES_ROMAN, 12, Font.NORMAL);
	
	public OrderManagement(String name, Customer c)
	{
		super(name);
		this.setSize(WIDTH, HEIGHT);
		setResizable(false);
		panel.setLayout(null);
		totalPrice = 0.0f;
		myCustomer = c;
		
		lblProduct.setBounds(20, 30, 100, 25);
		cbProduct.setBounds(120, 30, 200, 25);
		comboBoxActionListener();
		
		lblPrice.setBounds(20, 70, 100, 25);
		tfPrice.setEditable(false);
		tfPrice.setBounds(120, 70, 200, 25);
		lblStock.setBounds(20, 110, 100, 25);
		tfStock.setEditable(false);
		tfStock.setBounds(120, 110, 200, 25);
		
		panel.add(lblProduct);
		panel.add(lblPrice);
		panel.add(lblStock);
		
		panel.add(cbProduct);
		panel.add(tfPrice);
		panel.add(tfStock);
		textArea.setEditable(false);
		
		textArea.setBounds(350, 30, 380, 150);
		//panel.add(textArea);
		scrollPane.setBounds(350, 30, 380, 150);
		scrollPane.setViewportView(textArea);
		panel.add(scrollPane);
		
		btnAddToCart.setBounds(20, 240, 130, 35);
		setAddToCartActionListener();
		panel.add(btnAddToCart);
		
		populateComboBox();
		
		lblYourQuantity.setBounds(20, 146, 100, 25);
		panel.add(lblYourQuantity);
		
		tfQuantity.setBounds(120, 146, 200, 25);
		panel.add(tfQuantity);
		
		btnOrder.setBounds(600, 246, 130, 35);
		setOrderActionListener();
		panel.add(btnOrder);
		
		lblTotalPrice.setBounds(350, 190, 150, 20);
		panel.add(lblTotalPrice);
		
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
	
	private void comboBoxActionListener()
	{
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
						p = (Product)objects.get(i);
						s = (Stock)objects2.get(i);
						//System.out.println(s.getQuantity());
						break;
					}
				}
			}
		});
	}
	
	private void setOrderActionListener()
	{
		btnOrder.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if(textArea.getText().length() != 0)
				{
					order = new Orders(myCustomer.getId(), dateFormat.format(date).toString(), totalPrice);
					try
					{
						ordersBLL.insertOrder(order);
						order = (Orders)ordersBLL.findOrder(order, campuri);
					
						for(Object o : orderObjects)
						{
							orderDetail = new OrderDetail(order.getOrderId(), ((OrderDetail) o).getProductId(), ((OrderDetail) o).getPrice(), ((OrderDetail) o).getQuantity());
							orderDetailObjects.add(orderDetail);
							orderDetailBLL.insertOrderDetail(orderDetail);
							//System.out.println(((OrderDetail) o).getQuantity());
						}
						
						for(Object st : objects2)
						{
							stockBLL.update((Stock)st);
						}
						
						createPDF("resources/" + order.getOrderId() + ".pdf");
						new SendMail().sendMail(myCustomer.getEmail(), "resources/" + order.getOrderId() + ".pdf");
						JOptionPane.showMessageDialog(null, "Email with bill has been sent.");
						
						setVisible(false);
						dispose();
					}
					catch(Exception ex)
					{
						JOptionPane.showMessageDialog(panel, ex);
					}
				}
			}
		});
	}
	
	private void setAddToCartActionListener()
	{
		btnAddToCart.addActionListener(new ActionListener() {
			public void actionPerformed(ActionEvent arg0) {
				if(tfQuantity.getText() != null)
				{
					if(Integer.valueOf(tfQuantity.getText()) > s.getQuantity())
					{
						JOptionPane.showMessageDialog(panel, "Not enough products. Max quantity is " + s.getQuantity());
					}
					else
					{
						orderDetail = new OrderDetail(0, p.getProductId(), p.getPrice(), Integer.valueOf(tfQuantity.getText()));
						orderObjects.add(orderDetail);
						productName.add(p.getProductName());
						s.setQuantity(s.getQuantity() - Integer.valueOf(tfQuantity.getText()));
						tfStock.setText(String.valueOf(s.getQuantity()));
						textArea.append(p.getProductName() + "   x" + Integer.valueOf(tfQuantity.getText()) + "\n");
						totalPrice += p.getPrice() * Integer.valueOf(tfQuantity.getText());
						lblTotalPrice.setText("Total price = " + totalPrice);
					}
					
					tfQuantity.setText("");
				}			
			}
		});
	}
	
	private void createPDF(String FILE)
	{
		Document doc = new Document();
		try {
			PdfWriter.getInstance(doc, new FileOutputStream(FILE));
			doc.open();
			doc.add(new Paragraph("Bill id : " + order.getOrderId() + "\n\n", myFont));
			doc.add(new Paragraph(myCustomer.getFirstName() + " " + myCustomer.getLastName() + "\n", myFont));
			doc.add(new Paragraph(myCustomer.getAddress() + "\n\n", myFont));
			
			PdfPTable table = new PdfPTable(4);

            PdfPCell c1 = new PdfPCell(new Phrase("Produs"));
            c1.setHorizontalAlignment(Element.ALIGN_CENTER);
            table.addCell(c1);

            c1 = new PdfPCell(new Phrase("Pret produs"));
            c1.setHorizontalAlignment(Element.ALIGN_CENTER);
            table.addCell(c1);

            c1 = new PdfPCell(new Phrase("Cantitate"));
            c1.setHorizontalAlignment(Element.ALIGN_CENTER);
            table.addCell(c1);
            
            c1 = new PdfPCell(new Phrase("Pret total"));
            c1.setHorizontalAlignment(Element.ALIGN_CENTER);
            table.addCell(c1);
            
            table.setHeaderRows(1);
            table.setHorizontalAlignment(Element.ALIGN_JUSTIFIED);

            for(int i = 0; i < orderObjects.size(); i++)
            {
            	OrderDetail od = (OrderDetail) orderDetailObjects.get(i);
            	table.addCell(productName.get(i));
            	table.addCell(String.valueOf(od.getPrice()));
            	table.addCell(String.valueOf(od.getQuantity()));
            	table.addCell(String.valueOf(od.getPrice() * od.getQuantity()));
            }
            
            doc.add(table);
            
            Paragraph preface = new Paragraph("Total price : " + String.valueOf(totalPrice));
            preface.setAlignment(Element.ALIGN_RIGHT);
            doc.add(preface);
            
			doc.close();
		} catch (FileNotFoundException | DocumentException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
}
