using Godot;

namespace Game;

public partial class Pipes : Node2D
{
	private float SCROLL_SPEED = 120.0f;
	[Export] private VisibleOnScreenNotifier2D _notifier;
	private Vector2 _position;

	public override void _Ready()
	{
		_notifier.ScreenExited += OnScreenExited;
		_position = Position;
	}

	public override void _Process(double delta)
	{
		Position -= new Vector2(SCROLL_SPEED * (float)delta, 0.0f);
	}

	private void OnScreenExited()
	{
		QueueFree();
	}
}
