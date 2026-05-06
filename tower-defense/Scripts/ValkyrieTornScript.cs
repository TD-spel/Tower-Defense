using Godot;
using System;

public partial class ValkyrieTornScript : StaticBody2D
{

	private float hitSpeed = 1f;

	public override void _Ready() {
		base._Ready();
	}
	public override void _Process(double delta) {
		
		Rotate(hitSpeed * .05f);
	}
}
