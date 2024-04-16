using Godot;

public partial class Ship : Rotable
{
	public Ship() : base(0.01f) { }
	private float _acceleration_speed = 0.01f;
	private void _on_visible_on_screen_enabler_3d_screen_exited()
	{
		GD.Print("got out");
		this.Position = new Vector3(0, 0, 0);
	}

	public override void _PhysicsProcess(double delta)
	{
		base._PhysicsProcess(delta);
	}

}
