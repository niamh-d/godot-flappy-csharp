using Godot;

namespace Game;

public partial class Game : Node2D
{

	[Export] private Marker2D _spawnUpper;
	[Export] private Marker2D _spawnLower;
	[Export] private Timer _timer;
	[Export] private Node2D _pipesHolder;
	private PackedScene _pipes = GD.Load<PackedScene>("res://scenes/pipes/Pipes.tscn");

	public override void _Ready()
	{
		_timer.Timeout += SpawnPipes;
	}

	public override void _Process(double delta)
	{
	}

	private void SpawnPipes()
	{
		var instance = _pipes.Instantiate<Pipes>();
		var position = new Vector2(_spawnUpper.Position.X, GetSpawnY());
		instance.Position = position;
		_pipesHolder.AddChild(instance);
	}

	private float GetSpawnY()
	{
		return (float)GD.RandRange(_spawnUpper.Position.Y, _spawnLower.Position.Y);
	}
}