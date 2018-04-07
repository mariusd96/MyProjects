package bll;

import java.util.NoSuchElementException;

import dao.ReflectionDAO;
import model.Orders;

public class OrdersBLL {
	
	public OrdersBLL()
	{
		
	}

	public Orders findOrder(Orders o, Object[] campuri)
	{
		Orders o2 = (Orders) ReflectionDAO.select(o, campuri);
		
		if(o2 == null)
		{
			throw new NoSuchElementException("Order with orderId = " + o2.getOrderId() + " customerID = " + o2.getCustomerId() + " not found");
		}
		
		return o2;
	}
	
	public void insertOrder(Orders o)
	{
		ReflectionDAO.insert(o);
	}
}
