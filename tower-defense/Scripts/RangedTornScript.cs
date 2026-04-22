using Godot;
using System;
using System.Collections.Generic;

public partial class RangedTorn : StaticBody2D
{

	[Export] private List<Node2D> enemies = new List<Node2D>();
	public override void _Ready() {
		

	}


	public override void _Process(double delta) {
		
		
	}

	public void OnArea2dBodyEntered(Node2D body) {
		
		enemies.Add(body);
	}

	public void OnArea2dBodyExited(Node2D body) {
		
		enemies.Remove(body);
	}
}
