namespace CarListApp.Controls;

public partial class FlyOutHeader : StackLayout
{
	public FlyOutHeader()
	{
		InitializeComponent();

		SetValues();
	}

    private void SetValues()
    {
        if(App.userInfo != null)
		{
			lblUsername.Text = App.userInfo.UserName;
			lblRole.Text = App.userInfo.Role;
		}
    }
}