using System.ComponentModel;
using System.Diagnostics;
using System.Text.Json;
using System.Text;
using System.Windows.Input;
using CoTutor;
using Microsoft.Maui.Controls;
using Microsoft.VisualBasic;
//using eqonecs;
using CoTutor.encryption;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

public class ApiData : INotifyPropertyChanged
{

    private static ApiData _instance;

    private ApiData()
    {
        Client = new HttpClient();
        UpdateCommand = new Command(Update);
        credentials = new Credentials();
        _loggedin = false;
        //token from textfile
    }

    public static ApiData Instance // Public property to access the singleton instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ApiData();
            }
            return _instance;
        }
    }

    public void SetLoggedInShellContent()
    {
        var shell = Shell.Current;
        var tabBar = shell.Items.OfType<TabBar>().FirstOrDefault();

        if (tabBar != null)
        {
            // Clear existing ShellContent
            foreach (var tab in tabBar.Items)
            {
                tab.Items.Clear();
            }


            var friendContenpage = new ShellContent
            {
                Title = "Settings",
                ContentTemplate = new DataTemplate(typeof(Friends))
            };
            tabBar.Items.Add(friendContenpage);

            var chatsContent = new ShellContent
            {
                Title = "Chats",
                ContentTemplate = new DataTemplate(typeof(chats)),
            };
            tabBar.Items.Add(chatsContent);

        }
    }

    const string HttpServerUrl = "http://13.246.49.85:8080/";
    SymmetricEncryption _symmetricEncryption;
    HttpClient Client { get; set; } = new HttpClient();
    public Credentials credentials;



    public bool _loggedin;
    public ICommand UpdateCommand { get; }


    private void Update()
    {
        // Logic to update the model or perform actions based on user input
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


    public async Task<string> SaveUserCredentialsAsync(string Password, string Username)
    {

        credentials.password = Password;
        credentials.username = Username;
        _symmetricEncryption = new SymmetricEncryption();
        try
        {


            //Eqone calc = new Eqone();
            //credentials.password = calc.Eqautions(1, 2, 3, 4, 0, 1023282783);
            byte[] encryptedUsernameBytes = _symmetricEncryption.EncryptString(credentials.username);
            credentials.username = Convert.ToBase64String(encryptedUsernameBytes);


            string json = JsonSerializer.Serialize(credentials);
            StringContent content = new StringContent(json, Encoding.Unicode, "application/json");
            HttpResponseMessage response = await Client.PostAsync(HttpServerUrl + "login", content);
            if (response.IsSuccessStatusCode)
            {
                var response_data = await response.Content.ReadAsStringAsync();
                SetLoggedInShellContent();
                return response_data;
            }
            else
            {
                // Handle unsuccessful responses
                return "none";
            }
        }
        catch (Exception ex)
        {
            return "hello";
        }
    }

    public class Credentials
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}






//if we implement OAuth2.0 but it is pain in the ass
public class OAuth2
{
    public required string token { get; set; }
}



