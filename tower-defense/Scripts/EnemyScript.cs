using Godot;
using System;

public partial class EnemyScript : PathFollow2D
{
	[Signal]
	public delegate void EnemyDeathEventHandler();


	[Export]
	private int enemyIndex = 1;

	[Export]
	private int enemyHP = 3;
	
	[Export]
	private float enemyMoveSpeed = 5f;


	public override void _Ready() {

		
	}

	public override void _Process(double delta)
    {
        TempMovement();

		ProgressRatio += enemyMoveSpeed * (float) delta * 0.05f;
       // EnemyDeath();
    }

   /* private void EnemyDeath()
    {
        if (enemyHP <= 0)
        {

			//EmitSignal(SignalName.EnemyDeath);

			//QueueFree();

            //Temporär test kod
            GlobalPosition = new Vector2(0, 50);
            enemyHP = 3;
        }
    }*/

    public void _on_area_2d_body_entered(Node2D body) {
		
		if (body is Bullet bullet) {
			enemyHP--;
			bullet.QueueFree();

		}

		if (body is ValkyrieTornScript) {
			
			enemyHP -= 2;
			GD.Print("hit");
		}


	}

    private void TempMovement()
    {
        if (Input.IsKeyPressed(Key.D))
        {

            this.Position += new Vector2(enemyMoveSpeed, 0);
        }

        if (Input.IsKeyPressed(Key.A))
        {

            this.Position += new Vector2(-enemyMoveSpeed, 0);
        }

        if (Input.IsKeyPressed(Key.W))
        {

            this.Position += new Vector2(0, -enemyMoveSpeed);
        }

        if (Input.IsKeyPressed(Key.S))
        {

            this.Position += new Vector2(0, enemyMoveSpeed);
        }
    }

}
