using Godot;
using System;

public partial class EnemyScript : CharacterBody2D
{
	[Export]
	private int enemyHP = 3;
	
	[Export]
	private float enemyMoveSpeed = 5f;




	public override void _Ready() {

		
	}

	public override void _Process(double delta) {

		if (Input.IsKeyPressed(Key.D)) {
			
			this.Position += new Vector2(enemyMoveSpeed, 0);
		}

		if (Input.IsKeyPressed(Key.A)) {
			
			this.Position += new Vector2(-enemyMoveSpeed, 0);
		}

		if (Input.IsKeyPressed(Key.W)) {
			
			this.Position += new Vector2(0, -enemyMoveSpeed);
		}

		if (Input.IsKeyPressed(Key.S)) {
			
			this.Position += new Vector2(0, enemyMoveSpeed);
		}
	}
}
