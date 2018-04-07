package bll;

import java.util.NoSuchElementException;
import model.Stock;
import dao.ReflectionDAO;

public class StockBLL {

	public StockBLL()
	{
		
	}
	
	public void insert(Stock s)
	{
		ReflectionDAO.insert(s);
	}
	
	public void update(Stock s)
	{
		ReflectionDAO.update(s);
	}
	
}
