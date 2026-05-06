using Godot;
using System;


public partial class Main : Node2D
{

	Node2D lvl;
	[Export] private PackedScene rangedTower;
	[Export] private PackedScene valkyrieTower;

	StaticBody2D tower;
	Vector2 mousePosition;

	bool isPlacing = false;
	bool isplaced = false;

	private float towerIndex;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		lvl = GetNode<Node2D>("banna1");
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
		
		if (towerIndex == 1) {
				tower = rangedTower.Instantiate<RangedTornScript>();

			} else if (towerIndex == 2) {
				tower = valkyrieTower.Instantiate<ValkyrieTornScript>();
			}
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



}
