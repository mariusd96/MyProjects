package connection;

import java.sql.*;
import java.util.logging.Level;
import java.util.logging.Logger;

import java.io.File;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class ConnectionFactory {

	private static final Logger LOGGER = Logger.getLogger(ConnectionFactory.class.getName());
	private static final String DRIVER = "com.mysql.jdbc.Driver";
	private static final String DBURL = "jdbc:mysql://localhost:3306/warehouseDB";
	
	private static String USER;
	private static String PASS;
	private static final String Path = "C:/TP_tema3.txt";
	private Scanner scan;
	
	private static ConnectionFactory singleInstance = new ConnectionFactory();
	
	private ConnectionFactory()
	{
		try
		{
			scan = new Scanner(new File("C:/TP_tema3.txt"));
			USER = scan.nextLine();
			PASS = scan.nextLine();
		}
		catch(FileNotFoundException e)
		{
			e.printStackTrace();
		}
		
		try
		{
			Class.forName(DRIVER);
		}catch(ClassNotFoundException e)
		{
			e.printStackTrace();
		}
	}
	
	private Connection createConnection()
	{
		Connection connection = null;
		
		try
		{
			connection = DriverManager.getConnection(DBURL, USER, PASS);
		}catch(SQLException e)
		{
			LOGGER.log(Level.WARNING, "An error occured while trying to connect to the database");
			e.printStackTrace();
		}
		
		return connection;
	}
	
	
	public static Connection getConnection()
	{
		return singleInstance.createConnection();
	}
	
	public static void close(Connection connection)
	{
		if(connection != null)
		{
			try
			{
				connection.close();
			} catch(SQLException e)
			{
				LOGGER.log(Level.WARNING, "An error occured while trying to connect to the database");
			}
		}
	}
	
	public static void close(Statement statement)
	{
		if(statement != null)
		{
			try
			{
				statement.close();
			} catch(SQLException e)
			{
				LOGGER.log(Level.WARNING, "An error occured while trying to close the statement");
			}
		}
	}
	
	public static void close(ResultSet resultSet)
	{
		if(resultSet != null)
		{
			try
			{
				resultSet.close();
			}
			catch(SQLException e)
			{
				LOGGER.log(Level.WARNING, "An error occured while trying to close the ResultSet");
			}
		}
	}
}
