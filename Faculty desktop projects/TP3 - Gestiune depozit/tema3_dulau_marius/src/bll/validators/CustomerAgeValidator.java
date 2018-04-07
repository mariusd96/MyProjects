package bll.validators;

import model.Customer;

public class CustomerAgeValidator implements Validator<Customer> {

	private static final int MIN_AGE = 14;
	
	@Override
	public void validate(Customer t) {
		// TODO Auto-generated method stub
		if(t.getAge() < MIN_AGE)
		{
			throw new IllegalArgumentException("The customer age is not respected(minimum age = 14)");
		}
	}

}
