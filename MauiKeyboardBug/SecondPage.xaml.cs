namespace MauiKeyboardBug;

public partial class SecondPage : ContentPage
{
	public SecondPage()
	{
		InitializeComponent();
	}

  private void OnBackBtnClicked(object sender, EventArgs e)
  {
		Application.Current.MainPage.Navigation.PopModalAsync();
  }
}