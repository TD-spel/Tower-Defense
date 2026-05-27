using Godot;
using System;

public partial class DeathZone : Area2D
{

	[Signal]
	public delegate void EnemyReachedGoalEventHandler();

	public void _on_area_entered(Area2D area) {
		
		if (area.GetParent() is EnemyScript enemy) {

			EmitSignal(SignalName.EnemyReachedGoal);
			enemy.QueueFree();
		}
	}
}
