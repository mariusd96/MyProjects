package bll;

import model.Product;

import java.util.NoSuchElementException;

import dao.ReflectionDAO;

public class ProductBLL {

	public ProductBLL()
	{
		
	}
	
	public void insertProduct(Product product)
	{
		ReflectionDAO.insert(product);
	}
	
	public void updateProduct(Product product)
	{
		ReflectionDAO.update(product);
	}
	
	public void deleteProduct(Product product)
	{
		ReflectionDAO.delete(product);
	}
	
	public Object find(Product p, Object[] campuri)
	{
		Object o = (Product) ReflectionDAO.select(p, campuri);
		
		if(o == null)
		{
			throw new NoSuchElementException("Product not found");
		}
		
		return o;
	}
	
}
