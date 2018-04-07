package model;

public class OrderDetail {

	private int orderId;
	private int productId;
	private double price;
	private int quantity;
	
	public OrderDetail(int orderId, int productId, double price, int quantity) 
	{
		this.orderId = orderId;
		this.productId = productId;
		this.price = price;
		this.quantity = quantity;
	}

	public int getOrderId() 
	{
		return orderId;
	}

	public void setOrderId(int orderId) 
	{
		this.orderId = orderId;
	}

	public int getProductId() 
	{
		return productId;
	}

	public void setProductId(int productId) 
	{
		this.productId = productId;
	}
	
	public double getPrice() 
	{
		return price;
	}

	public void setPrice(double price) 
	{
		this.price = price;
	}

	public int getQuantity() 
	{
		return quantity;
	}

	public void setQuantity(int quantity) 
	{
		this.quantity = quantity;
	}

	@Override
	public String toString() 
	{
		return "OrderDetail [orderId=" + orderId + ", productId=" + productId + ", price=" + price + ", quantity="
				+ quantity + "]";
	}
	
	
}
