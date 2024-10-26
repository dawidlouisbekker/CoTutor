namespace CoTutor;

public class Login : ContentPage
{
    public Login()
    {
        var apiData = ApiData.Instance!;
        if (apiData._loggedin == false)
        {

            var logginButton = new Button
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Margin = 10
            };


            VerticalStackLayout _logginstack = new VerticalStackLayout { VerticalOptions = LayoutOptions.Fill, HorizontalOptions = LayoutOptions.Fill };




            Label heading = new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Margin = 10, Text = "Login" };
            Label userNameLabel = new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Margin = 10, Text = "Username:" };
            Entry userName = new Entry { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Margin = 5, MinimumWidthRequest = 225 };
            Label passwordLabel = new Label { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Margin = 10, Text = "Password:" };
            Entry password = new Entry { IsPassword = true, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Margin = 5, MinimumWidthRequest = 225 };
            Button loginButton = new Button { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center, Margin = 10, Text = "Login" };

            loginButton.Clicked += async (sender, args) =>
            {
                await apiData.SaveUserCredentialsAsync(userName.Text, password.Text);
            };

            _logginstack.Add(heading);
            _logginstack.Add(userNameLabel);
            _logginstack.Add(userName);
            _logginstack.Add(passwordLabel);
            _logginstack.Add(password);
            _logginstack.Add(loginButton);

            Content = _logginstack;

        }
      
    }
}