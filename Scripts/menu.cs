using Godot;
using System;

public partial class menu : Node2D
{
	public TextureButton StartButton;

	private void _on_leave_button_pressed()
	{
		GetTree().Quit();
	}

	private void _on_start_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/level.tscn");
	}
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
