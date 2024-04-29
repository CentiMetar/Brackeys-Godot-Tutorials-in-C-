using Godot;
using System;
using System.Numerics;

public partial class Enemy : AnimatedSprite2D
{
	[Export]
	public int speed;
	public int dir = 1;

	[Export]
	public RayCast2D rayright;

	[Export]
	public RayCast2D rayleft;
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//We move enemy in direction its pointed
		Position = new Godot.Vector2(Position.X+speed*dir,Position.Y);
		//If we collide with a wall we turn right or left depending on which ray hit the wall
		//We also have to change collision layers of the rays to ignore player but hit terrain in the editor
		if(rayleft.IsColliding()){
			dir = 1;
			FlipH = false;
		}
		if(rayright.IsColliding()){
			dir=-1;
			FlipH = true;
		}
	}
}
