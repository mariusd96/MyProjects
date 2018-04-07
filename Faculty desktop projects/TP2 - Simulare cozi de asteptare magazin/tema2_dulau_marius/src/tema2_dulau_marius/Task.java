package tema2_dulau_marius;

import java.util.*;

public class Task{

	private int arrivalTime;
	private int processingPeriod;
	private int nr;
	
	public Task(int arrTime, int procTime, int number)
	{
		this.arrivalTime = arrTime;
		this.processingPeriod = procTime;
		this.nr = number;
	}
	
	public void setArrivalTime(int arrTime)
	{
		this.arrivalTime = arrTime;
	}
	
	public int getArrivalTime()
	{
		return this.arrivalTime;
	}
	
	public void setProcessingPeriod(int procTime)
	{
		this.arrivalTime = procTime;
	}
	
	public int getProcessingPeriod()
	{
		return this.processingPeriod;
	}
	
	public int getName()
	{
		return this.nr;
	}
}
