using Godot;
using System;
using System.Collections.Generic;

public partial class Wavemaniger : Node2D
{

	struct EnemyData
	{
		public Sprite2D sprite;
		public int healthpoints;
		public float speed;
	}

	private List<EnemyData> enemytype = new()
	{
		
	};

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
