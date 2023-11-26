using Godot;
using System;
using static Godot.GD;
public partial class Player : CharacterBody2D
{
    private const float Speed = 300.0f;
    private AnimationPlayer _anim;
    private ProgressBar _progressBar;
    public double Hp = 100;
    
    public override void _Ready()
    {
        _anim = GetNode<AnimationPlayer>("AnimationPlayer");
        _progressBar = GetNode<ProgressBar>("ProgressBar");
        UpdateHealthBar();
    }

    public void Damage(double damage)
    {
        if (Hp <= 0) return;
        Hp -= damage;
        UpdateHealthBar();
    }

    public void Regen(double regen)
    {
        if (Hp >= 100) return;
        Hp += regen;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        _progressBar.Value = Hp;
    }

    private void ExecuteBattle()
    {
        for (int i = 0; i < GetSlideCollisionCount(); i++)
        {
            KinematicCollision2D collision = GetSlideCollision(i);
            var collisionToNode = collision.GetCollider() as Node;
            var collisionToString = collisionToNode.Name;
            if (collisionToString == "Enemy") GetTree().ChangeSceneToFile("res://Scenes/battle.tscn");
        }
    }

    private Color UpdateColorHealthBar()
    {
        if (Hp >= 50) return new Color(94, 209, 58, 255);
        else if (Hp >= 20) return new Color(249, 191, 59, 255);
        else return new Color(207, 0, 15, 255);
    }
    public override void _PhysicsProcess(double delta)
    {
        ExecuteBattle();
        Vector2 velocity = Velocity;
        Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        if (direction != Vector2.Zero)
        {
            if (direction.Y < 0)
            {
                _anim.Play("walkUp");
            }

            if (direction.Y > 0)
            {
                _anim.Play("walkDown");
            }

            if (direction.X > 0)
            {
                _anim.Play("walkRight");
            }

            if (direction.X < 0)
            {
                _anim.Play(("walkLeft"));
            }
            velocity.Y = direction.Y * Speed;
            velocity.X = direction.X * Speed;
        }
        else
        {
            _anim.Play("Idle");
            velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);

        }

        Velocity = velocity;
        MoveAndSlide();
    }
}