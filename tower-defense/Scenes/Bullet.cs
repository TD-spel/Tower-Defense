using Godot;
using System;

public partial class Bullet : CharacterBody2D
{


	public override void _PhysicsProcess(double delta)
	{

		MoveAndSlide();
	}
}
