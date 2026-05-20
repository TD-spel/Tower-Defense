using Godot;
using System;

public partial class DeathZone : Area2D
{

	[Signal]
	public delegate void EnemyReachedGoalEventHandler();

	public void _on_body_entered(Node2D body) {
			
		EmitSignal(SignalName.EnemyReachedGoal);
	}
}
