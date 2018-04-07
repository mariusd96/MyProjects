package tema2_dulau_marius;

import java.util.List;

public class ConcreteStrategyQueue implements Strategy {

	@Override
	public void addTask(List<Server> servers, Task t) {
		// TODO Auto-generated method stub
		
		int index = 0, minim = Integer.MAX_VALUE;
		
		for(int i = 0; i < servers.size(); i++)
		{
			int serverSize = servers.get(i).getTasks().length;
			if(serverSize < minim) 
			{
				minim = serverSize;
				index = i;
			}
		}
		
		servers.get(index).addTask(t);
	}
}
