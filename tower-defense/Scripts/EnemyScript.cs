using Godot;
using System;

public partial class EnemyScript : PathFollow2D
{
	[Signal]
	public delegate void EnemyDeathEventHandler();


	[Export]
	private int enemyIndex = 1;

	int _enemyHP;
	
	 float _enemyMoveSpeed;

    public void Initialize(Texture2D sprite, int enemyHP, float enemyMoveSpeed)
    {
        GetNode<Sprite2D>("Sprite2D").Texture = sprite;
        _enemyHP =enemyHP;
        _enemyMoveSpeed = enemyMoveSpeed;
    }

	public override void _Process(double delta)
    {
        TempMovement();

<<<<<<< Updated upstream
		ProgressRatio += enemyMoveSpeed * (float) delta * 0.05f;
        OnEnemyDeath();
    }

    private void OnEnemyReachedGoal() {
        
        QueueFree();
=======
		ProgressRatio += _enemyMoveSpeed * (float) delta * 0.05f;
       // EnemyDeath();
>>>>>>> Stashed changes
    }
    
    private void OnEnemyDeath()
    {
        if (_enemyHP <= 0)
        {

			EmitSignal(SignalName.EnemyDeath);

<<<<<<< Updated upstream
			QueueFree();
=======
			//QueueFree();

            //Temporär test kod
            GlobalPosition = new Vector2(0, 50);
            _enemyHP = 3;
>>>>>>> Stashed changes
        }
    }

    public void _on_area_2d_body_entered(Node2D body) {
		if (body is Bullet bullet) {
			_enemyHP--;
			bullet.QueueFree();

		}

		if (body is ValkyrieTornScript) {
			
			_enemyHP -= 2;
			GD.Print("hit");
		}


	}

    private void TempMovement()
    {
        if (Input.IsKeyPressed(Key.D))
        {

            this.Position += new Vector2(_enemyMoveSpeed, 0);
        }

        if (Input.IsKeyPressed(Key.A))
        {

            this.Position += new Vector2(-_enemyMoveSpeed, 0);
        }

        if (Input.IsKeyPressed(Key.W))
        {

            this.Position += new Vector2(0, -_enemyMoveSpeed);
        }

        if (Input.IsKeyPressed(Key.S))
        {

            this.Position += new Vector2(0, _enemyMoveSpeed);
        }
    }

}
