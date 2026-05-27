using Godot;
using System;
using System.Collections.Generic;

public partial class Wavemaniger : Node2D
{

	[Signal]
	public delegate void SpawnEnemyEventHandler();

	[Export]
	private Timer enemyspwantimer;
	[Export]
	public PackedScene enemyT1 {get; set;}
	[Export]
	public PackedScene enemyT2 {get; set;}
	int currentWavePosision;

	struct EnemyData
	{
		public Texture2D sprite;
		public int enemyHP;

		public float enemyMoveSpeed;

	}
	private List<EnemyData> _enemyType = new()
	{
		new EnemyData{sprite=GD.Load<Texture2D>("res://Assets/sprites/Cannon.png") , enemyHP = 2, enemyMoveSpeed = 2},
		new EnemyData{sprite=GD.Load<Texture2D>("res://Assets/sprites/Ballong.png"), enemyHP = 5, enemyMoveSpeed = 3},
	};
	private List<int> _waveData =new();
	Path2D enemypath;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		/*enemytype.Add(enemyT1.Instantiate<EnemyScript>());
		enemytype.Add(enemyT2.Instantiate<EnemyScript>());*/
		enemypath =	GetNode<Path2D>("../enemypath1");
		_startWave(0);

	}

	private void _startWave(int waveIndex)
	{
	_waveData.Clear();
	foreach((int type, int count) in waves[waveIndex])
		{
			for (int i = 0 ; i< count; i++)
			{
				_waveData.Add(type);
			}
		}
		currentWavePosision =0;

		enemyspwantimer.Start();
		
	}
	private List<(int,int)[]> waves = new()
	{
		new (int , int)[]{ (0,4), (0,7), (1,2)},
		new (int , int)[]{ (0,6), (0,7), (1,4), (1,5)},
	};
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _OnSpwanEnemy()
	{
		if (currentWavePosision>= _waveData.Count) return;
		int enemyType = _waveData[currentWavePosision];
	

		/*switch (_waveData[currentWavePosision])
		{
			case 0: 
		enemypath.AddChild(enemyT1);	break;

			case 1: 
			enemypath.AddChild(enemy_2); break;
		}*/
		
		EnemyScript enemy = enemyT1.Instantiate<EnemyScript>();
		enemypath.AddChild(enemy);
		EnemyData d = _enemyType[enemyType];
		enemy.Initialize(d.sprite, d.enemyHP, d.enemyMoveSpeed);
		currentWavePosision++;

		EmitSignal(SignalName.SpawnEnemy);
		
	}
}
