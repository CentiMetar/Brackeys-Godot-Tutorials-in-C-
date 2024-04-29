using Godot;
using System;

public partial class GameManager : Node
{
	//We save number of coins collected
	public static int CoinNum = 0;
	
	//We have to give label static property so we can access it in PickUp function
	public static Label label;
	
	//We call this function when we want to increase number of coins collected
	public static void PickUp(int num){
		//We increase number of coins collected 
		CoinNum+=num;
		//We change the text of the label
		label.Text = "You have collected: " + Convert.ToString(CoinNum) + " coins"; 
	}
    public override void _Ready()
    {
		//We get the label node and save it
	    label = GetNode<Label>("CoinNumLabel");
	}
    
}
