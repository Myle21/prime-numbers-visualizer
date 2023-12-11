using Godot;
using System;
using System.Drawing;

public partial class number : Node2D
{
	public ulong Num;

	public override void _Ready()
	{
		GetNode<Sprite2D>("Sprite2D").Position = Vector2.Right * Num;
		Rotation = Num;
	}

	public void SetNum(uint x)
	{
		Num = x;
	}
}
