using Godot;
using System;

public partial class Coin : Area2D
{
	public void _on_body_entered(Node2D node){
		//If we collide with a player we call GameManager function to pick up one coin and we delete this coin
		if(node.Name=="Player"){
			GameManager.PickUp(1);
			QueueFree();
		}
	}
}
