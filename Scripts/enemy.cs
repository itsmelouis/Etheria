using Godot;
using System;

public partial class enemy : CharacterBody2D
{
	private const float Speed = 300.0f;
	private ProgressBar _progressBar;
	public double Hp = 50;
    
	public override void _Ready()
	{
		//UpdateHealthBar();
	}

	public void Damage(double damage)
	{
		if (Hp <= 0) return;
		Hp -= damage;
		//UpdateHealthBar();
	}

	public void Regen(double regen)
	{
		if (Hp >= 100) return;
		Hp += regen;
		//UpdateHealthBar();
	}

	public override void _PhysicsProcess(double delta)
	{
		/*Vector2 velocity = Velocity;
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();*/
		
		
	}
}
