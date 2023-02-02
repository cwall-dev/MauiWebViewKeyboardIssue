namespace MauiKeyboardBug;

public partial class MainPage : ContentPage
{
  public MainPage()
  {
    InitializeComponent();
    myWebView.Navigating += MyWebView_Navigating;
    myWebView.Source = new HtmlWebViewSource() { Html = @"<html>
<head>
<meta name=""viewport"" content=""width=320, user-scalable=no"" />
<script>
  function doSomeWork() {
    document.getElementById('myinput').focus();
    location.href=""secondpage"";
  }
</script>
</head>
<body style='background-color:yellow'><input id='myinput'><br/><br/><input type='button' value='click me' onclick='doSomeWork();'/></body></html>" };

  }

  private async void MyWebView_Navigating(object sender, WebNavigatingEventArgs e)
  {
    if (e.Url.EndsWith("secondpage", StringComparison.OrdinalIgnoreCase))
    {
      e.Cancel = true;
      await myWebView.EvaluateJavaScriptAsync(@"");
      await Navigation.PushModalAsync(new SecondPage());
    }
  }
}

