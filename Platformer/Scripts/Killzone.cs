using Godot;
using System;

public partial class Killzone : Area2D
{
	public void _on_body_entered(Node2D node){
		//If we collide with a node called Player
		if(node.Name=="Player"){
			//Deletes collider
			node.GetNode<CollisionShape2D>("CollisionShape2D").QueueFree();
			//Slow down engine time
			Engine.TimeScale = 0.2;
			//We get the timer and start it
			GetNode<Timer>("Timer").Start();
		}
	}
	public void Die(){
		//Return engine time to normal
		Engine.TimeScale = 1;
		//We reload the current scene if we die
		GetTree().ReloadCurrentScene();

	}
	public void _on_timer_timeout(){
		//We call function Die on timeout
		Die();
	}
}
