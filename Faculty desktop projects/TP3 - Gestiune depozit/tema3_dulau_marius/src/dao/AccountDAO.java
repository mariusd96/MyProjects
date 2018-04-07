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

public class AccountDAO {

protected static final Logger LOGGER = Logger.getLogger(CustomerDAO.class.getName());
	
	private static final String insertStatementString = "insert into Account(username, pass, role) values(?, ?, ?)";
	private static final String findStatementString = "select * from Account where username = ? and pass = ?";
	
	public static String insert(Account a)
	{
		Connection dbConnection = ConnectionFactory.getConnection();
		PreparedStatement insertStatement = null;
		String username = null;
		
		try
		{
			insertStatement = dbConnection.prepareStatement(insertStatementString, Statement.RETURN_GENERATED_KEYS);
			insertStatement.setString(1, a.getUsername());
			insertStatement.setString(2, a.getPass());
			insertStatement.setString(3, String.valueOf(a.getRole()));
			insertStatement.executeUpdate();
			
			ResultSet rs = insertStatement.getGeneratedKeys();
			if(rs.next())
			{
				username = rs.getString("username");
			}
		}
		catch(SQLException e)
		{
			LOGGER.log(Level.WARNING, "AccountDAO : insert " + e.getMessage());
		}
		finally
		{
			ConnectionFactory.close(insertStatement);
			ConnectionFactory.close(dbConnection);
		}
		
		return username;
	}
	
	public static boolean findByUserAndPass(String username, String pass)
	{
		boolean state = false;
		
		Connection dbConnection = ConnectionFactory.getConnection();
		PreparedStatement findStatement = null;
		ResultSet rs = null;
		
		try
		{
			findStatement = dbConnection.prepareStatement(findStatementString);
			findStatement.setString(1, username);
			findStatement.setString(2, pass);
			rs = findStatement.executeQuery();
			if(rs.next()) state = true;
		}
		catch(SQLException e)
		{
			LOGGER.log(Level.WARNING, "AccountDAO : insert " + e.getMessage());
		}
		finally
		{
			ConnectionFactory.close(rs);
			ConnectionFactory.close(findStatement);
			ConnectionFactory.close(dbConnection);
		}
		
		return state;
	}
}
