using Godot;

public partial class Movable : Node3D
{
	protected float _accelerationSpeed;
	public Movable(float accelerationSpeed)
	{
		_accelerationSpeed = accelerationSpeed;
	}
	protected float xTranslationSpeed = 0f;
	protected float yTranslationSpeed = 0f;
	protected float zTranslationSpeed = 0f;
	protected float xRotationSpeed = 0f;
	protected float yRotationSpeed = 0f;
	protected float zRotationSpeed = 0f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionPressed(Consts.ActionMoveFrontward))
		{
			this.xTranslationSpeed += this._accelerationSpeed;
			this.yTranslationSpeed += this._accelerationSpeed;
			this.zTranslationSpeed += this._accelerationSpeed;
		}

		if (Input.IsActionPressed(Consts.ActionMoveBackward))
		{
			this.xTranslationSpeed -= this._accelerationSpeed;
			this.yTranslationSpeed -= this._accelerationSpeed;
			this.zTranslationSpeed -= this._accelerationSpeed;
		}

		if (Input.IsActionPressed(Consts.ActionRotateZIncrease))
		{
			this.zRotationSpeed += this._accelerationSpeed;
		}

		if (Input.IsActionPressed(Consts.ActionRotateZDecrease))
		{
			this.zRotationSpeed -= this._accelerationSpeed;
		}

		this.GlobalTranslate(new Vector3
		{
			X = xTranslationSpeed,
			Y = yTranslationSpeed,
			Z = zTranslationSpeed,
		});

		RotateObjectLocal(new Vector3
		{
			X = 0,
			Y = 0,
			Z = 1,
		}, zRotationSpeed);

		RotateObjectLocal(new Vector3
		{
			X = 1,
			Y = 0,
			Z = 0,
		}, xRotationSpeed);

		RotateObjectLocal(new Vector3
		{
			X = 0,
			Y = 1,
			Z = 0,
		}, yRotationSpeed);
	}

}
