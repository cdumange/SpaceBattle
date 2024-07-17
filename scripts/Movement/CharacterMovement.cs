using Godot;

namespace SpaceBattle.scripts
{
	public partial class CharacterMovement : GravityLikeMouvement
	{

		public CharacterMovement(Vector3 accelerationSpeed) : base(accelerationSpeed)
		{
		}

		public override void _PhysicsProcess(double delta)
		{
			LookAtMouse();

			if (Input.IsMouseButtonPressed(MouseButton.Right))
			{
				base.RotationSpeed = new Vector3();
			}

			if (Input.IsActionPressed(Consts.ActionMoveLeft))
			{
				base.TranslationSpeed.X += _accelerationSpeed.X;
			}

			if (Input.IsActionPressed(Consts.ActionMoveRight))
			{
				base.TranslationSpeed.X -= _accelerationSpeed.X;
			}

			if (Input.IsActionPressed(Consts.ActionMoveFrontward))
			{
				base.TranslationSpeed.Y += _accelerationSpeed.Y;
			}

			if (Input.IsActionPressed(Consts.ActionMoveBackward))
			{
				base.TranslationSpeed.Y -= _accelerationSpeed.Y;
			}

			base._PhysicsProcess(delta);
		}

		private void LookAtMouse()
		{
			//Input.MouseMode = Input.MouseModeEnum.Hidden;
			var camera = GetViewport().GetCamera3D();
			var camPos = GetViewport().GetMousePosition();
			var dropPlane = new Plane(new Vector3(0, 0, 1), -1000f);
			var position3D = dropPlane.IntersectsRay(
				camera.ProjectRayOrigin(camPos),
				camera.ProjectRayNormal(camPos));

			LookAt(position3D.Value, null);
		}
	}
}
