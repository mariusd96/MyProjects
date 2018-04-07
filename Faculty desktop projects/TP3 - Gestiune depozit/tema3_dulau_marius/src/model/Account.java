package model;

public class Account {

	private String username;
	private String pass;
	private char role;
	
	public Account(String username, String pass, char role)
	{
		this.username = username;
		this.pass = pass;
		this.role = role;
	}
	
	public String getUsername()
	{
		return this.username;
	}
	
	public void setUsername(String username)
	{
		this.username = username;
	}
	
	public String getPass()
	{
		return this.pass;
	}
	
	public void setPass(String pass)
	{
		this.pass = pass;
	}
	
	public char getRole()
	{
		return this.role;
	}
	
	public void setRole(char role)
	{
		this.role = role;
	}
	
	@Override
	public String toString() 
	{
		return "Account [username=" + username + ", pass=" + pass + ", role=" + role + "]";
	}
}
