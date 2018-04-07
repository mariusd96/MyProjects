package tema1_dulau_marius;

public class Monom {
	
	private double coeficient;
	private int grad;
	
	public Monom()
	{
		this.coeficient = 0.0f;
		this.grad = 0;
	}
	
	public void setCoeficient(double coef)
	{
		this.coeficient = coef;
	}
	
	public double getCoeficient()
	{
		return this.coeficient;
	}
	
	public void setGrad(int gr)
	{
		this.grad = gr;
	}
	
	public int getGrad()
	{
		return this.grad;
	}
	
}
