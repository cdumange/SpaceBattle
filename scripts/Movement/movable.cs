using System;
using System.Numerics;
using Godot;
using Vector3 = Godot.Vector3;

public partial class GravityLikeMouvement : Node3D
{
	protected Vector3 _accelerationSpeed;
	protected readonly float DecelerationSpeed = 0.01f;
	public GravityLikeMouvement(Vector3 accelerationSpeed)
	{
		_accelerationSpeed = accelerationSpeed;
	}
	protected Vector3 TranslationSpeed = new Vector3(0, 0, 0);
	protected Vector3 RotationSpeed = new Vector3(0, 0, 0);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	private void ManageDeceleration(ref float value)
	{
		if (value == 0)
		{
			return;
		}

		if (Math.Abs(value) <= DecelerationSpeed)
		{
			value = 0f;
			return;
		}

		if (value > 0)
		{
			value -= DecelerationSpeed;
			return;
		}

		if (value < 0)
		{
			value += DecelerationSpeed;
			return;
		}
	}

	private void ManageDecelerations()
	{
		ManageDeceleration(ref this.TranslationSpeed.X);
		ManageDeceleration(ref this.TranslationSpeed.Y);
		ManageDeceleration(ref this.TranslationSpeed.Z);
	}

	public override void _PhysicsProcess(double delta)
	{
		ManageDecelerations();

		this.GlobalTranslate(TranslationSpeed);

		RotateObjectLocal(new Vector3
		{
			X = 0,
			Y = 0,
			Z = 1,
		}, RotationSpeed.Z);

		RotateObjectLocal(new Vector3
		{
			X = 1,
			Y = 0,
			Z = 0,
		}, RotationSpeed.X);

		RotateObjectLocal(new Vector3
		{
			X = 0,
			Y = 1,
			Z = 0,
		}, RotationSpeed.Y);
	}

}
