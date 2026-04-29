using Godot;
using System;


public partial class Main : Node2D
{

	Node2D lvl;
	[Export] private PackedScene rangedTower;

	bool isPlacing = false;
	bool isplaced = false;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		lvl = GetNode<Node2D>("banna1");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{ 
		var mousePosision = GetGlobalMousePosition();
		if( isPlacing == true  && Input.IsActionJustPressed("leftClick"))
		{
			//tabort sprite

			var tower = rangedTower.Instantiate<RangedTornScript>();

		
		tower.Position = mousePosision;
		
		lvl.AddChild(tower);
		isPlacing= false;
		}
	}
	

	public void _on_ranged_torn_button_pressed(){
		
		//ändra för att se pengar
		if (true)
		{
		isPlacing = true;
			//lägg en ikon som flöjer musen	
		}
	
	}

}
