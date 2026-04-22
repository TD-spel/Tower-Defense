using Godot;
using System;

public partial class EnemyScript : StaticBody2D
{
	public override void _Ready() {

		
	}

	public override void _Process(double delta) {

		
	}

	public override void _Input(InputEvent @event) {
		
		if (Input.IsKeyPressed(Key.D)) {
			
			this.Position = new Vector2(1, 0);
		}

		if (Input.IsKeyPressed(Key.A)) {
			
			this.Position = new Vector2(-1, 0);
		}
	}
}
