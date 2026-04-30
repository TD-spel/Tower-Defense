using Godot;
using System.Collections.Generic;
using System.Numerics;
using System.Threading.Tasks.Dataflow;

public partial class RangedTornScript : StaticBody2D
{

	[Export] private PackedScene bulletScene;
	[Export] private Node2D weapon;
	[Export] private float fireRate = 1f;
	[Export] private float bulletMoveSpeed = 10f;

	private AnimatedSprite2D animatedSprite2D;
	private Timer shootTimer;
	private List<EnemyScript> enemies;
	public override void _Ready() {
		enemies= new List<EnemyScript>();
		animatedSprite2D = GetNode<AnimatedSprite2D>("rangedTornSprite");
		shootTimer = new Timer();
		shootTimer.Timeout += OnTimerTimeout;

		AddChild(shootTimer);
		
	}


	public override void _Process(double delta) {
		
		if (enemies.Count > 0) {
			if (shootTimer.IsStopped())
			{
				shootTimer.Start();
				
			}
			this.LookAt(enemies[0].GlobalPosition);
			animatedSprite2D.Play("shot");
		} 
		else { 
			
			shootTimer.Stop();
			animatedSprite2D.Stop();
		 }

	}

	public void OnArea2dBodyEntered(Node2D body) {

		if (body is EnemyScript enemy) {

			enemies.Add(enemy);
			GD.Print("Body Entered");
		}
	}

	public void OnArea2dBodyExited(Node2D body) {
		if (body is EnemyScript enemy) {

			enemies.Remove(enemy);
			GD.Print("Body Exited");
		}
		
	}

	private void OnTimerTimeout() {
		ShootEnemy();
	}

	private void ShootEnemy() {
		
		if (enemies.Count > 0) {
			var bullet = bulletScene.Instantiate<Bullet>();

			bullet.GlobalPosition = weapon.GlobalPosition;

			bullet.Velocity = (enemies[0].GlobalPosition - bullet.GlobalPosition).Normalized() * bulletMoveSpeed;
			GetTree().CurrentScene.AddChild(bullet);	
		}
	}
}
