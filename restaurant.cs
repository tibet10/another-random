using System;
					
public class Program
{
	public static void Main()
	{
		var ingredients = new LunchIngredients();
		Console.WriteLine(Restaurant.MakeMeal(ingredients));
		
		var dinnerIngredients = new DinnerIngredients();
		Console.WriteLine(Restaurant.MakeMeal(dinnerIngredients));
	}
}

public static class Restaurant{
	public static string MakeMeal(IIngredients ingredients){
		var food = ingredients.food();
		return food.name;
	}
}
public enum Type { Lunch = 0, Dinner = 1};		

public class Food {
	public Type type;				
	public string name {get; set;}
	public Type foodType {get { return type;} set{ type = value; }}
}
public class LunchIngredients: IIngredients {
	public Food food(){
		var chef = new DayChef();
		return new Food { name = chef.cookRajma() + " & " + chef.cookRice(), foodType = Type.Lunch };
	}
}

public class DinnerIngredients: IIngredients {		
	public Food food(){
		var chef = new NightChef();
		return new Food { name = chef.cookDal() + " & " + chef.cookRice(), foodType = Type.Dinner };
	}
}

public class NightChef: ICookDal, ICookRice{
	public string cookDal(){
		return "Here is the beautiful dal";
	}
	public string cookRice(){
		return "Here is the beautiful rice";
	}
}

public class DayChef: ICookRice, ICookRajma {
	public string cookRice(){
		return "Here is the beautiful rice";
	}

	public string cookRajma(){
		return "Here is the delicious rajma";
	}
}

public interface IIngredients{
	Food food();
}	
public interface ICookDal{
	string cookDal();
}

public interface ICookRice{
	string cookRice();	
}

public interface ICookRajma{
	string cookRajma();
}
