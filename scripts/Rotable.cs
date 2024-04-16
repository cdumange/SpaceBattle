using Godot;
using System;

public partial class Rotable : Movable
{

	private Vector2? lastMousePos;
	public Rotable(float accelerationSpeed) : base(accelerationSpeed) { }
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	private void DefaultUpdateRotation()
	{
		var mpov = GetViewport().GetMousePosition();
		if (lastMousePos is not null)
		{
			var xDelta = mpov.X - lastMousePos.Value.X;
			var yDelta = mpov.Y - lastMousePos.Value.Y;
			var sumDelta = Math.Abs(xDelta) + Math.Abs(yDelta);

			if (sumDelta != 0)
			{
				GD.Print($"oldX {lastMousePos.Value.X} - newX: {mpov.X} - delta: {xDelta} - acceleration factor: {xDelta / sumDelta}");
				base.xRotationSpeed += base._accelerationSpeed * (yDelta / sumDelta);
				base.yRotationSpeed += base._accelerationSpeed * (xDelta / sumDelta);
			}
		}
		lastMousePos = mpov;
	}

	private void CenteredUpdateRotation()
	{
		var mpov = GetViewport().GetMousePosition();
		var display = GetViewport().GetVisibleRect().Size;

		base.xRotationSpeed += base._accelerationSpeed * ((mpov.X - display.X / 2) / display.X);
		base.yRotationSpeed += base._accelerationSpeed * ((mpov.Y - display.Y / 2) / display.Y);

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsMouseButtonPressed(MouseButton.Left))
		{
			Input.MouseMode = Input.MouseModeEnum.Hidden;
			CenteredUpdateRotation();
		}
		else
		{
			Input.MouseMode = Input.MouseModeEnum.Visible;
			if (lastMousePos is not null)
			{
				GetViewport().WarpMouse(new Vector2(0, 0));
				lastMousePos = null;
			}

		}

		if (Input.IsMouseButtonPressed(MouseButton.Right))
		{
			base.xRotationSpeed = 0;
			base.yRotationSpeed = 0;
			base.zRotationSpeed = 0;
		}

		base._PhysicsProcess(delta);
	}

}
