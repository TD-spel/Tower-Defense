using Godot;
using System;


public partial class Main : Node2D
{
	

	Node2D lvl;

	[Export] private Label moneyText;
	[Export] private int money;
	[Export] private Label healthPointsText;
	[Export] private int healthPoints;

	[Export] private PackedScene rangedTower;
	[Export] private int rangedTowerPrice = 30;
	[Export] private PackedScene valkyrieTower;
	[Export] private int valkyrieTowerPrice = 45;

	[Export] private Button valacryUpgade;

	[Export] private Label GameOver;
	
	float _fireRate;
	StaticBody2D tower;
	Vector2 mousePosition;

	bool isPlacing = false;
	bool isplaced = false;

	private float towerIndex;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		lvl = GetNode<Node2D>("banna1");
		healthPointsText.Text = healthPoints.ToString();

		DeathZone deathZone = GetNode<DeathZone>("banna1/deathZone");

		deathZone.EnemyReachedGoal += OnEnemyReachedGoal;

		Wavemaniger waveManager = GetNode<Wavemaniger>("banna1/WaveManager");

		waveManager.SpawnEnemy += OnEnemySpawn;

		_fireRate = rangedTower.Instantiate<RangedTornScript>().fireRate;
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{ 
		moneyText.Text = "$" + money.ToString();
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
				tower = valkyrieTower.Instantiate<StaticBody2D>();
				money -= valkyrieTowerPrice;
			} else { return; }
			tower.Position = mousePosition;
			

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

	public void _on_rangetorn_upgade_pressed()
	{
		
		if(money >= 100)
		{
		_fireRate-=0.025f;
		money-=100;	
		
		}
	}

	/*public void _on_button_pressed()
	{
		GD.Print("valkyrie upgraderas");
		Node parent =valkyrieTower.Instantiate<StaticBody2D>();

    	Node nyChild = valkyrieTower.Instantiate<StaticBody2D>().GetNode("Valkyrie").Duplicate();

    	parent.AddChild(nyChild);
	}*/
	

	private void OnEnemyReachedGoal() {
		
		healthPoints --;
		healthPointsText.Text = healthPoints.ToString();

		if(healthPoints < 1)
		{
			GameOver.Visible = true;
			
		}
	}

	private void OnEnemySpawn() {
		
		
		EnemyScript enemyScript = GetNode<EnemyScript>("banna1/enemypath1/Enemy");

		enemyScript.EnemyDeath += OnEnemyDeath;
	}

	private void OnEnemyDeath() {
		
		money += 10;
		moneyText.Text = "$" + money.ToString();
	}

}
