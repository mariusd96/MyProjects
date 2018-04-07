package start;

import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;

import presentation.*;
import bll.AccountBLL;
import bll.CustomerBLL;
import model.Account;
import model.Customer;

import java.lang.reflect.Field;

public class Start {

	protected static final Logger LOGGER = Logger.getLogger(Start.class.getName()); 
	private Login login;
	
	public Start()
	{
		login = new Login("Login");
		login.setVisible(true);
	}
	
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Start t = new Start();	
		
		int indice = 0;
		//while(true) System.out.println(indice++);
	}

}
