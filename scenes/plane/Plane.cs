namespace Game;
using Godot;

public partial class Plane : CharacterBody2D
{
	const float GRAVITY = 800.0f;
	const float POWER = -350.0f;
	[Export] private AnimationPlayer _animationPlayer;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		velocity.Y += GRAVITY * (float)delta;

		if (Input.IsActionJustPressed("fly"))
		{
			velocity.Y = POWER;
			_animationPlayer.Play("power");
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}