using Godot;
using System.Collections.Generic;

public partial class RangedTornScript : StaticBody2D
{

	[Export] private PackedScene bulletScene;
	[Export] private Node2D weapon;
	[Export] private float bulletSpeed = 10;

	private List<EnemyScript> enemies;
	public override void _Ready() {
 			enemies= new List<EnemyScript>();
	}


	public override void _Process(double delta) {
		
		if (enemies.Count > 0) {

			
		}

		if (Input.IsKeyPressed(Key.E)) {
			
			ShootEnemy();
		}
	}

	public void OnArea2dBodyEntered(Node2D body) {
		GD.Print(body.GetClass());
		if (body is EnemyScript enemy){
			enemies.Add(enemy);
			GD.Print("Body Entered");
		}
	}

	public void OnArea2dBodyExited(Node2D body) {
		/*
		enemies.Remove(body);
		GD.Print("Body Exited");
		*/
	}


	private void ShootEnemy() {
		
		var bullet = bulletScene.Instantiate<Bullet>();

		bullet.GlobalPosition = weapon.GlobalPosition;

		bullet.Velocity = (enemies[0].GlobalPosition - bullet.GlobalPosition).Normalized() * bulletSpeed;


		GetTree().CurrentScene.AddChild(bullet);
	}
}
