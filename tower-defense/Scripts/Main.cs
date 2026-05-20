using Godot;
using System;


public partial class Main : Node2D
{
	

	Node2D lvl;

	[Export] private Label moneyText;
	[Export] public int money;
	[Export] private Label healthPointsText;
	[Export] private int healthPoints;

	[Export] private PackedScene rangedTower;
	[Export] private int rangedTowerPrice = 30;
	[Export] private PackedScene valkyrieTower;
	[Export] private int valkyrieTowerPrice = 45;
	

	StaticBody2D tower;
	Vector2 mousePosition;

	bool isPlacing = false;
	bool isplaced = false;

	private float towerIndex;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		lvl = GetNode<Node2D>("banna1");
		moneyText.Text = "$" + money.ToString();
		healthPointsText.Text = healthPoints.ToString();

		DeathZone deathZone = GetNode<DeathZone>("banna1/deathZone");

		deathZone.EnemyReachedGoal += OnEnemyReachedGoal;

		//EnemyScript enemyScript = GetNode<EnemyScript>("Enemy");

		//enemyScript.EnemyDeath += OnEnemyDeath;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{ 

		mousePosition = GetGlobalMousePosition();
		if( isPlacing == true  && Input.IsActionJustPressed("leftClick"))
		{
			//tabort sprite
			
			PlaceTower();
		}
	}

	public void PlaceTower() {
		
		//Kollar vilket värde towerIndex har och bestämmer därefter vilket torn som ska placeras.
		//Den kollar också ifall man har råd att köpa tornet.
		if (towerIndex == 1 && money >= rangedTowerPrice) {
				tower = rangedTower.Instantiate<RangedTornScript>();
				money -= rangedTowerPrice;
			} else if (towerIndex == 2 && money > valkyrieTowerPrice) {
				tower = valkyrieTower.Instantiate<ValkyrieTornScript>();
				money -= valkyrieTowerPrice;
			} else { return; }
			tower.Position = mousePosition;
			
			moneyText.Text = "$" + money.ToString();
			lvl.AddChild(tower);
			isPlacing= false;
	}
	

	public void _on_ranged_torn_button_pressed(){
		
		//ändra för att se pengar
		if (true)
		{
			towerIndex = 1;
			isPlacing = true;
			//lägg en ikon som flöjer musen	
		}
	
	}

	public void _on_valkyrie_torn_button_pressed() {
		
		if (true) {
			
			towerIndex = 2;
			isPlacing = true;
		}
	}

	private void OnEnemyReachedGoal() {
		
		healthPoints--;
		healthPointsText.Text = healthPoints.ToString();
	}

	private void OnEnemyDeath() {
		
		HandleMoney();
	}

	private void HandleMoney() {
		
		money += 10;
		moneyText.Text = money.ToString();
	}



}
