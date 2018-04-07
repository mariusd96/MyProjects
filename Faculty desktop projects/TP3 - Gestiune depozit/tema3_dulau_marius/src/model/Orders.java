package model;

public class Orders {

	private int orderId;
	private int customerId;
	private String orderDate;
	private double totalPrice;
	
	public Orders(int id, int idCustomer, String date, double priceT)
	{
		this.orderId = id;
		this.customerId = idCustomer;
		this.orderDate = date;
		this.totalPrice = priceT;
	}

	public Orders(int idCustomer, String date, double priceT)
	{
		this.customerId = idCustomer;
		this.orderDate = date;
		this.totalPrice = priceT;
	}
	
	public int getOrderId() 
	{
		return orderId;
	}

	public void setOrderId(int orderId) 
	{
		this.orderId = orderId;
	}

	public int getCustomerId() 
	{
		return customerId;
	}

	public void setCustomerId(int customerId) 
	{
		this.customerId = customerId;
	}

	public String getOrderDate() 
	{
		return orderDate;
	}

	public void setOrderDate(String orderDate) 
	{
		this.orderDate = orderDate;
	}

	public double getTotalPrice() 
	{
		return totalPrice;
	}

	public void setTotalPrice(double totalPrice) 
	{
		this.totalPrice = totalPrice;
	}

	@Override
	public String toString() 
	{
		return "Orders [orderId=" + orderId + ", customerId=" + customerId + ", orderDate=" + orderDate
				+ ", totalPrice=" + totalPrice + "]";
	}
	
	
}
