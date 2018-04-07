package bll;

import java.util.NoSuchElementException;

import bll.validators.Validator;
import dao.ReflectionDAO;
import model.Customer;
import model.OrderDetail;

public class OrderDetailBLL {

	public OrderDetailBLL()
	{
		
	}

	/*public Customer findCustomerByUser(Customer c, Object[] campuri)
	{
		Customer o = (Customer) ReflectionDAO.select(c, campuri);
		
		if(o == null)
		{
			throw new NoSuchElementException("Customer with username = " + c.getUsername() + "not found");
		}
		
		return o;
	}*/
	
	public void insertOrderDetail(OrderDetail od)
	{
		ReflectionDAO.insert(od);
	}
}
