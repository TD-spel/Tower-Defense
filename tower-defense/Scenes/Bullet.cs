using Godot;
using System;

public partial class Bullet : CharacterBody2D
{


	public override void _PhysicsProcess(double delta)
	{

		MoveAndSlide();

		if (GetSlideCollisionCount() > 0) {
			
			QueueFree();
		}

	}
}
