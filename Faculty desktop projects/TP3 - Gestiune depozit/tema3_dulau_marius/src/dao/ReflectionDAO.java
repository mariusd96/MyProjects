package dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;

import javax.swing.JTable;

import connection.ConnectionFactory;

import java.lang.reflect.Field;
import java.lang.reflect.InvocationTargetException;
import java.util.ArrayList;
import java.util.List;
import java.lang.reflect.Constructor;
import model.*;

public class ReflectionDAO {

	protected static final Logger LOGGER = Logger.getLogger(CustomerDAO.class.getName());
	
	public static String insertQuery(Object object)
	{
		String insertStatementString = "insert into " + object.getClass().getSimpleName() + "(";
		int nrFields = object.getClass().getDeclaredFields().length - 1;
		int copyNrFields = nrFields;
		
		for(Field field : object.getClass().getDeclaredFields())
		{
			field.setAccessible(true);
			
			insertStatementString = insertStatementString + field.getName();
			if(copyNrFields > 0)
			{
				insertStatementString = insertStatementString + ",";
				copyNrFields--;
			}
		}
		
		insertStatementString = insertStatementString + ") values (";
		
		for(Field field : object.getClass().getDeclaredFields())
		{
			field.setAccessible(true);
			
			insertStatementString = insertStatementString + "?";
			if(nrFields > 0)
			{
				insertStatementString = insertStatementString + ",";
				nrFields--;
			}
		}
		
		insertStatementString = insertStatementString + ")";
		
		return insertStatementString;
	}
	
	public static String selectQuery(Object object, Object[] campuri)
	{
		String selectStatementString = "select * from " + object.getClass().getSimpleName();
		
		if(campuri != null)
		{
			int nrFields = campuri.length - 1;
			if(nrFields >= 0) selectStatementString = selectStatementString + " where ";
			
			for(int i = 0; i < campuri.length; i++)
			{
				selectStatementString = selectStatementString + campuri[i] + " = ?";
				if(nrFields > 0)
				{
					selectStatementString = selectStatementString + " and ";
					nrFields--;
				}
			}
		}
		
		return selectStatementString;
	}
	
	public static String updateQuery(Object object)
	{
		String updateStatementString = "update " + object.getClass().getSimpleName() + " SET ";
		int nrFields = object.getClass().getDeclaredFields().length - 1;
		
		for(Field field : object.getClass().getDeclaredFields())
		{
			field.setAccessible(true);
			Object value;
			
			try 
			{
				value = field.get(object);
				if(value instanceof String) updateStatementString = updateStatementString + field.getName() + " = '" + value + "'";
				else updateStatementString = updateStatementString + field.getName() + " = " + value;
				if(nrFields > 0)
				{
					updateStatementString = updateStatementString + ", ";
					nrFields--;
				}
			}
			catch (IllegalArgumentException e) 
			{
				e.printStackTrace();
			} 
			catch (IllegalAccessException e) 
			{
				e.printStackTrace();
			}
		}
		
		updateStatementString = updateStatementString + " where ";
		for(Field field : object.getClass().getDeclaredFields())
		{
			field.setAccessible(true);
			Object value;
			
			try 
			{
				value = field.get(object);
				updateStatementString = updateStatementString + field.getName() + " = " + value;
			}
			catch (IllegalArgumentException e) 
			{
				e.printStackTrace();
			} 
			catch (IllegalAccessException e) 
			{
				e.printStackTrace();
			}
			
			break;
		}
		
		return updateStatementString;
	}
	
	public static String deleteQuery(Object object)
	{
		String deleteStatementString = "delete from " + object.getClass().getSimpleName() + " where ";
		
		for(Field field : object.getClass().getDeclaredFields())
		{
			field.setAccessible(true);
			Object value;
			
			try {
				value = field.get(object);
				if(value instanceof String) deleteStatementString = deleteStatementString + field.getName() + " = '" + value + "'";
				else deleteStatementString = deleteStatementString + field.getName() + " = " + value;
			} catch (IllegalArgumentException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			} catch (IllegalAccessException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
			
			break;
		}
		
		return deleteStatementString;
	}
	
	public static void insert(Object object)
	{
		Connection dbConnection = ConnectionFactory.getConnection();
		PreparedStatement insertStatement = null;
		String insertStatementString = insertQuery(object);
		
		try
		{
			insertStatement = dbConnection.prepareStatement(insertStatementString);
			
			int i = 1;
			for(Field field : object.getClass().getDeclaredFields())
			{
				field.setAccessible(true);
				Object value;
				
				try 
				{
					value = field.get(object);
					if(value.getClass() == String.class) insertStatement.setString(i, (String)value);
					else if(value.getClass() == Integer.class) insertStatement.setInt(i, (int)value);
					else if(value.getClass() == Character.class) insertStatement.setString(i, String.valueOf(value));
					else if(value.getClass() == Double.class) insertStatement.setDouble(i, (double)value);
					
					i++;
				}
				catch (IllegalArgumentException e) 
				{
					e.printStackTrace();
				} 
				catch (IllegalAccessException e) 
				{
					e.printStackTrace();
				}
			}
			
			insertStatement.executeUpdate();
		}
		catch(SQLException e)
		{
			LOGGER.log(Level.WARNING, "ReflectionDAO : insert " + e.getMessage());
		}
		finally
		{
			ConnectionFactory.close(insertStatement);
			ConnectionFactory.close(dbConnection);
		}
	}
	
	public static Object select(Object object, Object[] campuri)
	{
		Object toReturn = null;
		
		Connection dbConnection = ConnectionFactory.getConnection();
		PreparedStatement selectStatement = null;
		String selectStatementString = selectQuery(object, campuri);
		ResultSet rs = null;
		
		try
		{
			selectStatement = dbConnection.prepareStatement(selectStatementString);
			
			int index = 1;
			for(Field field : object.getClass().getDeclaredFields())
			{
				field.setAccessible(true);
				
				for(int i = 0; i < campuri.length; i++)
				{
					if(field.getName().compareTo((String) campuri[i]) == 0)
					{
						Object value;
						
						try 
						{
							value = field.get(object);
							selectStatement.setString(index, String.valueOf(value));
							index++;
						}
						catch (IllegalArgumentException e) 
						{
							e.printStackTrace();
						} 
						catch (IllegalAccessException e) 
						{
							e.printStackTrace();
						}
						
						break;
					}
				}
			}
			
			rs = selectStatement.executeQuery();
			rs.next();
			
			Object[] variables = new Object[object.getClass().getDeclaredFields().length];
			index = 0;
			for(Field field : object.getClass().getDeclaredFields())
			{
				variables[index++] = rs.getString(field.getName());
				//System.out.println(variables[index - 1]);
			}
			
			Account a = null;
			Customer c = null;
			OrderDetail od = null;
			Orders o = null;
			Product p = null;
			Stock s = null;
			
			try 
			{
				if(object.getClass().getSimpleName().compareTo("Account") == 0)
				{
					a = Account.class.getConstructor(String.class, String.class, char.class).newInstance(variables[0], variables[1], String.valueOf(variables[2]).charAt(0));
					toReturn = a;
				}
				else if(object.getClass().getSimpleName().compareTo("Customer") == 0)
				{
					c = Customer.class.getConstructor(int.class, String.class, String.class, String.class, int.class, String.class, String.class, String.class).newInstance(Integer.parseInt((String)variables[0]), variables[1], variables[2], variables[3], Integer.parseInt((String)variables[4]), variables[5], variables[6], variables[7]);
					toReturn = c;
				}
				else if(object.getClass().getSimpleName().compareTo("Product") == 0)
				{
					p = Product.class.getConstructor(int.class, String.class, double.class).newInstance(Integer.parseInt((String)variables[0]), variables[1], Double.valueOf((String)variables[2]));
					toReturn = p;
				}
				else if(object.getClass().getSimpleName().compareTo("Stock") == 0)
				{
					s = Stock.class.getConstructor(int.class, int.class).newInstance(Integer.parseInt((String)variables[0]), Integer.parseInt((String)variables[1]));
					toReturn = s;
				}
				else if(object.getClass().getSimpleName().compareTo("Orders") == 0)
				{
					o = Orders.class.getConstructor(int.class, int.class, String.class, double.class).newInstance(Integer.parseInt((String)variables[0]), Integer.parseInt((String)variables[1]), variables[2], Double.parseDouble((String)variables[3]));
					toReturn = o;
				}
				else if(object.getClass().getSimpleName().compareTo("OrderDetail") == 0)
				{
					od = OrderDetail.class.getConstructor(int.class, int.class, double.class, int.class).newInstance(Integer.parseInt((String)variables[0]), Integer.parseInt((String)variables[1]), Double.valueOf((String)variables[2]), Integer.parseInt((String)variables[3]));
					toReturn = od;
				}
			} 
			catch (InstantiationException | IllegalAccessException | IllegalArgumentException | InvocationTargetException | NoSuchMethodException | SecurityException e) 
			{
				e.printStackTrace();
			}
			
			return toReturn;
		}
		catch(SQLException e)
		{
			LOGGER.log(Level.WARNING, "ReflectionDAO : find " + e.getMessage());
		}
		finally
		{
			ConnectionFactory.close(rs);
			ConnectionFactory.close(selectStatement);
			ConnectionFactory.close(dbConnection);
		}
		
		return toReturn;
	}
	
	public static void update(Object object)
	{
		Connection dbConnection = ConnectionFactory.getConnection();
		PreparedStatement updateStatement = null;
		String updateStatementString = updateQuery(object);
		
		try
		{
			updateStatement = dbConnection.prepareStatement(updateStatementString);
			updateStatement.executeUpdate();
		}
		catch(SQLException e)
		{
			LOGGER.log(Level.WARNING, "ReflectionDAO : update " + e.getMessage());
		}
		finally
		{
			ConnectionFactory.close(updateStatement);
			ConnectionFactory.close(dbConnection);
		}
	}
	
	public static void delete(Object object)
	{
		Connection dbConnection = ConnectionFactory.getConnection();
		PreparedStatement deleteStatement = null;
		String deleteStatementString = deleteQuery(object);
		System.out.println(deleteStatementString);
		try
		{
			deleteStatement = dbConnection.prepareStatement(deleteStatementString);
			deleteStatement.executeUpdate();
		}
		catch(SQLException e)
		{
			LOGGER.log(Level.WARNING, "ReflectionDAO : update " + e.getMessage());
		}
		finally
		{
			ConnectionFactory.close(deleteStatement);
			ConnectionFactory.close(dbConnection);
		}
	}
	
	public static List createListOfObject(Object obj)
	{
		List<Object> objects = new ArrayList<Object>();
		Connection dbConnection = ConnectionFactory.getConnection();
		PreparedStatement selectStatement = null;
		String selectStatementString = selectQuery(obj, null);
		
		ResultSet rs = null;
		
		try
		{
			selectStatement = dbConnection.prepareStatement(selectStatementString);
			rs = selectStatement.executeQuery();
			
			Account a = null;
			Customer c = null;
			OrderDetail od = null;
			Orders o = null;
			Product p = null;
			Stock s = null;
			Object toReturn = null;
			
			while(rs.next())
			{
				int index = 0;
				Object[] variables = new Object[obj.getClass().getDeclaredFields().length];
				for(Field field : obj.getClass().getDeclaredFields())
				{
					variables[index++] = rs.getString(field.getName());
				}
				
				try 
				{
					if(obj.getClass().getSimpleName().compareTo("Account") == 0)
					{
						a = Account.class.getConstructor(String.class, String.class, char.class).newInstance(variables[0], variables[1], String.valueOf(variables[2]).charAt(0));
						toReturn = a;
					}
					else if(obj.getClass().getSimpleName().compareTo("Customer") == 0)
					{
						c = Customer.class.getConstructor(int.class, String.class, String.class, String.class, int.class, String.class, String.class, String.class).newInstance(Integer.parseInt((String)variables[0]), variables[1], variables[2], variables[3], Integer.parseInt((String)variables[4]), variables[5], variables[6], variables[7]);
						toReturn = c;
					}
					else if(obj.getClass().getSimpleName().compareTo("Product") == 0)
					{
						p = Product.class.getConstructor(int.class, String.class, double.class).newInstance(Integer.parseInt((String)variables[0]), variables[1], Double.valueOf((String)variables[2]));
						toReturn = p;
					}
					else if(obj.getClass().getSimpleName().compareTo("Stock") == 0)
					{
						s = Stock.class.getConstructor(int.class, int.class).newInstance(Integer.parseInt((String)variables[0]), Integer.parseInt((String)variables[1]));
						toReturn = s;
					}
					else if(obj.getClass().getSimpleName().compareTo("Orders") == 0)
					{
						o = Orders.class.getConstructor(int.class, int.class, String.class, double.class).newInstance(Integer.parseInt((String)variables[0]), Integer.parseInt((String)variables[1]), variables[2], Double.parseDouble((String)variables[3]));
						toReturn = o;
					}
					else if(obj.getClass().getSimpleName().compareTo("OrderDetail") == 0)
					{
						od = OrderDetail.class.getConstructor(int.class, int.class, double.class, int.class).newInstance(Integer.parseInt((String)variables[0]), Integer.parseInt((String)variables[1]), Double.valueOf((String)variables[2]), Integer.parseInt((String)variables[3]));
						toReturn = od;
					}
					
					objects.add(toReturn);
				} 
				catch (InstantiationException | IllegalAccessException | IllegalArgumentException | InvocationTargetException | NoSuchMethodException | SecurityException e) 
				{
					e.printStackTrace();
				}
			}
		}
		catch(SQLException e)
		{
			LOGGER.log(Level.WARNING, "ReflectionDAO : find " + e.getMessage());
		}
		finally
		{
			ConnectionFactory.close(rs);
			ConnectionFactory.close(selectStatement);
			ConnectionFactory.close(dbConnection);
		}
		
		return objects;
	}
	
	public static JTable createTable(List<Object> objects)
	{
		Object[] columnNames = new Object[objects.get(0).getClass().getDeclaredFields().length];
		Object[][] rowData = new Object[objects.size()][objects.get(0).getClass().getDeclaredFields().length];
		
		int index = 0;
		for(Field field : objects.get(0).getClass().getDeclaredFields())
		{
			columnNames[index++] = field.getName().toString();
		}
		
		index = 0;
		for(int i = 0; i < objects.size(); i++)
		{
			index = 0;
			for(Field field : objects.get(i).getClass().getDeclaredFields())
			{
				field.setAccessible(true);
				Object value;
				
				try 
				{
					value = field.get(objects.get(i));
					rowData[i][index++] = value;
				}
				catch (IllegalArgumentException e) 
				{
					e.printStackTrace();
				} 
				catch (IllegalAccessException e) 
				{
					e.printStackTrace();
				}
			}
		}
		
		JTable table = new JTable(rowData, columnNames);
		return table;
	}
}
