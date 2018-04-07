package dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

import java.util.logging.Level;
import java.util.logging.Logger;

import connection.ConnectionFactory;
import model.Account;
import model.Customer;

public class CustomerDAO {

	protected static final Logger LOGGER = Logger.getLogger(CustomerDAO.class.getName());
	
	private static final String insertStatementString = "insert into Customer(username, firstName, lastName, age, address, email, phoneNumber) values(?, ?, ?, ?, ?, ?, ?)";
	private static final String findStatementString = "select * from Customer where username = ?";
	
	public static int insert(Customer customer)
	{
		Connection dbConnection = ConnectionFactory.getConnection();
		PreparedStatement insertStatement = null;
		int insertedId = -1;
		
		try
		{
			insertStatement = dbConnection.prepareStatement(insertStatementString, Statement.RETURN_GENERATED_KEYS);
			insertStatement.setString(1, customer.getUsername());
			insertStatement.setString(2, customer.getFirstName());
			insertStatement.setString(3, customer.getLastName());
			insertStatement.setInt(4, customer.getAge());
			insertStatement.setString(5, customer.getAddress());
			insertStatement.setString(6, customer.getEmail());
			insertStatement.setString(7, customer.getPhoneNumber());
			insertStatement.executeUpdate();
			
			ResultSet rs = insertStatement.getGeneratedKeys();
			if(rs.next())
			{
				insertedId = rs.getInt(1);
			}
		}
		catch(SQLException e)
		{
			LOGGER.log(Level.WARNING, "CustomerDAO : insert " + e.getMessage());
		}
		finally
		{
			ConnectionFactory.close(insertStatement);
			ConnectionFactory.close(dbConnection);
		}
		
		return insertedId;
	}
	
	public static Customer findByUsername(Account a)
	{
		Customer toReturn = null;
		
		Connection dbConnection = ConnectionFactory.getConnection();
		PreparedStatement findStatement = null;
		ResultSet rs = null;
		
		try
		{
			findStatement = dbConnection.prepareStatement(findStatementString);
			findStatement.setString(1, a.getUsername());
			rs = findStatement.executeQuery();
			rs.next();
			
			//int id = rs.getInt("customerId");
			String firstName = rs.getString("firstName");
			String lastName = rs.getString("lastName");
			int age = rs.getInt("age");
			String address = rs.getString("address");
			String email = rs.getString("email");
			String phoneNumber = rs.getString("phoneNumber");
			
			toReturn = new Customer(a.getUsername(), firstName, lastName, age, address, email, phoneNumber);
		}
		catch(SQLException e)
		{
			LOGGER.log(Level.WARNING, "CustomerDAO : findByUsername " + e.getMessage());
		}
		finally
		{
			ConnectionFactory.close(rs);
			ConnectionFactory.close(findStatement);
			ConnectionFactory.close(dbConnection);
		}
		
		return toReturn;
	}
}
