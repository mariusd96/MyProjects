package model;

public class Customer {

	private int customerId;
	private String username;
    private String firstName;
    private String lastName;
    private int age;
    private String address;
    private String email;
    private String phoneNumber;
    
    public Customer(int id, String username, String prenume, String nume, int varsta, String adresa, String mail, String phoneNo)
    {
    	this.customerId = id;
    	this.username = username;
    	this.firstName = prenume;
    	this.lastName = nume;
    	this.age = varsta;
    	this.address = adresa;
    	this.email = mail;
    	this.phoneNumber = phoneNo;
    }
    
    public Customer(String username, String prenume, String nume, int varsta, String adresa, String mail, String phoneNo)
    {
    	this.username = username;
    	this.firstName = prenume;
    	this.lastName = nume;
    	this.age = varsta;
    	this.address = adresa;
    	this.email = mail;
    	this.phoneNumber = phoneNo;
    }
    
    public int getId()
    {
    	return this.customerId;
    }
    
    public String getUsername()
    {
    	return this.username;
    }
    
    public void setUsername(String username)
    {
    	this.username = username;
    }
    
    /*public String getPass()
    {
    	return this.account.getPass();
    }
    
    public void setPass(String pass)
    {
    	this.account.setPass(pass);
    }*/
    
    public String getFirstName()
    {
    	return this.firstName;
    }
    
    public void setFirstName(String firstName)
    {
    	this.firstName = firstName;
    }
    
    public String getLastName()
    {
    	return this.lastName;
    }
    
    public void setLastName(String lastName)
    {
    	this.lastName = lastName;
    }
    
    public int getAge()
    {
    	return this.age;
    }
    
    public void setAge(int age)
    {
    	this.age = age;
    }
    
    public String getAddress()
    {
    	return this.address;
    }
    
    public void setAddress(String address)
    {
    	this.address = address;
    }
    
    public String getEmail()
    {
    	return this.email;
    }
    
    public void setEmail(String email)
    {
    	this.email = email;
    }
    
    public String getPhoneNumber()
    {
    	return this.phoneNumber;
    }
    
    public void setPhoneNumber(String phoneNumber)
    {
    	this.phoneNumber = phoneNumber;
    }

	@Override
	public String toString() 
	{
		return "Customer [username=" + username + ", firstName=" + firstName + ", lastName=" + lastName + ", age=" + age
				+ ", address=" + address + ", email=" + email + ", phoneNumber=" + phoneNumber + "]";
	}
}
