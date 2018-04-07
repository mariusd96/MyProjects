package bll;

import java.util.ArrayList;
import java.util.List;
import java.util.NoSuchElementException;

import bll.validators.Validator;
import bll.validators.CustomerAgeValidator;
import bll.validators.EmailValidator;

import dao.ReflectionDAO;
import model.Account;
import model.Customer;

public class CustomerBLL {

	public List<Validator<Customer>> validators;
	
	public CustomerBLL()
	{
		validators = new ArrayList<Validator<Customer>>();
		validators.add(new EmailValidator());
		validators.add(new CustomerAgeValidator());
	}
	
	public Customer findCustomerByUser(Customer c, Object[] campuri)
	{
		Customer o = (Customer) ReflectionDAO.select(c, campuri);
		
		if(o == null)
		{
			throw new NoSuchElementException("Customer with username = " + c.getUsername() + "not found");
		}
		
		return o;
	}
	
	public void insertCustomer(Customer customer)
	{
		for(Validator<Customer> v : validators)
		{
			v.validate(customer);
		}
		
		ReflectionDAO.insert(customer);
	}
	
	public void updateCustomer(Customer customer)
	{
		ReflectionDAO.update(customer);
	}
}
