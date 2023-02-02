namespace MauiKeyboardBug;

public partial class MainPage : ContentPage
{
  public MainPage()
  {
    InitializeComponent();
    myWebView.Source = new UrlWebViewSource() { Url = "https://www.bing.com" };
//    myWebView.Source = new HtmlWebViewSource() { Html = @"<html>
//<head>
//<meta name=""viewport"" content=""width=320, user-scalable=no"" />
//</head>
//<body style='background-color:yellow'><h1>Input inside webview</h1><input id='myinput'><br><br>After tapping the timer button tap into the input field to open the keyboard.</body></html>" };

  }

  private async void Button_Clicked(object sender, EventArgs e)
  {
    TimerButton.Text = "3";
    await Task.Delay(1000).ContinueWith(async _ =>
    {
      await MainThread.InvokeOnMainThreadAsync(async () =>
      {
        TimerButton.Text= "2";
        await Task.Delay(1000).ContinueWith(async _ =>
        {
          await MainThread.InvokeOnMainThreadAsync(async () =>
          {
            TimerButton.Text = "1";
            await Task.Delay(1000).ContinueWith(async _ =>
            {
              await MainThread.InvokeOnMainThreadAsync(async () =>
              {
                await Navigation.PushModalAsync(new SecondPage());
                TimerButton.Text = "Open new Page in 3 seconds";
              });
            });
          });
        });
      });
    });
  }
}

