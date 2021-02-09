// ***GitHub added a new security feature w/c can affect the testing of this program
//    In first attempt, login to the test account before running
//    https://github.community/t/new-security-feature-device-verification/10216/3
// ------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Dynamic;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace GithubSecurityLogPuller
{
    public partial class FormMain : Form
    {
        private readonly ILogger<FormMain> _log;
        private readonly IConfiguration _config;
        private string email, password;

        public FormMain(ILogger<FormMain> log, IConfiguration config)
        {
            _log = log;
            _config = config;
            InitializeComponent();
        }



        private async void ButtonLogin_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                TxtBoxResult.Clear();
                if (IsOkToProceed())
                {
                    await GetSecurityLogs();
                }
            }
            catch (Exception err)
            {
                _log.LogInformation($"{err.GetBaseException()}");
                MessageBox.Show(err.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private async Task GetSecurityLogs()
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string responseBody = await client.GetStringAsync(new Uri(_config.GetValue<string>("Github:LoginPage")));
                    var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                    htmlDoc.LoadHtml(responseBody);

                    string authenticityToken = htmlDoc.DocumentNode.SelectSingleNode("//input[@name='authenticity_token']")?.GetAttributeValue("value", "") ?? "";
                    string signInButtonValue = htmlDoc.DocumentNode.SelectSingleNode("//input[@name='commit'][@type='submit']")?.GetAttributeValue("value", "") ?? "";

                    if (IsOkToProceed(true, authenticityToken, signInButtonValue))
                    {
                        HttpContent payload = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>()
                        {
                            new KeyValuePair<string, string>("login", email),
                            new KeyValuePair<string, string>("password", password),
                            new KeyValuePair<string, string>("authenticity_token", authenticityToken),
                            new KeyValuePair<string, string>("commit", signInButtonValue)
                        });

                        await LoginAndProcess(client, payload);
                    }
                }
                catch (Exception err)
                {
                    _log.LogInformation($"{err.GetBaseException()}");
                    MessageBox.Show(err.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private async Task LoginAndProcess(HttpClient client, HttpContent payload)
        {
            using (HttpResponseMessage response = await client.PostAsync(new Uri(_config.GetValue<string>("Github:Session")), payload))
            {
                try
                {
                    if (response.IsSuccessStatusCode)
                    {
                        bool isLoggedIn = await IsAbleToLogIn(response);
                        if (isLoggedIn)
                        {
                            string responseBody = await client.GetStringAsync(new Uri(_config.GetValue<string>("Github:SecurityLogs")));
                            var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                            htmlDoc.LoadHtml(responseBody);

                            string accountName = htmlDoc.DocumentNode.SelectSingleNode("//meta[@name='user-login']")?.GetAttributeValue("content", "") ?? "";
                            var logNodes = htmlDoc.DocumentNode.SelectNodes("//div[@id='audit-log-search']//div[contains(@class, 'TableObject')][contains(@class, 'Box-row')]/div[2]")?.ToList() ?? new List<HtmlNode>();
                            var logs = new List<Dictionary<string, string>>();

                            // get log events w/ their corresponding time
                            logNodes.ForEach(log =>
                            {
                                logs.Add(new Dictionary<string, string>()
                                {
                                    { "event", log.SelectSingleNode(".//span[@class='audit-type']")?.InnerText.Trim() ?? "" },
                                    { "time", log.SelectSingleNode(".//relative-time")?.InnerText.Trim() ?? "" }
                                });
                            });

                            dynamic result = new ExpandoObject();
                            result.Account = accountName;
                            result.Logs = logs;

                            // display the result
                            TxtBoxResult.Clear();
                            TxtBoxResult.Text = JsonConvert.SerializeObject(result);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Failed!  {response.ReasonPhrase}", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception err)
                {
                    _log.LogInformation($"{err.GetBaseException()}");
                    MessageBox.Show(err.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private async Task<bool> IsAbleToLogIn(HttpResponseMessage response)
        {
            bool isLoggedIn = false;
            using (HttpContent content = response.Content)
            {
                try
                {
                    string responseBody = await content.ReadAsStringAsync();
                    var htmlDoc = new HtmlAgilityPack.HtmlDocument();
                    htmlDoc.LoadHtml(responseBody);

                    HtmlNode loginFailedMsg = htmlDoc.DocumentNode.SelectSingleNode("//div[@id='js-flash-container']//div[text()[contains(., 'Incorrect username or password')]]");
                    if (loginFailedMsg == null)
                    {
                        isLoggedIn = true;
                        TxtBoxResult.Text += "Logged in successfully";
                    }
                    else
                    {
                        MessageBox.Show("Login failed!  Incorrect username or password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception err)
                {
                    _log.LogInformation($"{err.GetBaseException()}");
                    MessageBox.Show(err.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return isLoggedIn;
        }



        private bool IsOkToProceed(bool isSignInFormPayloadValidation = false, string authenticityToken = null, string signInButtonValue = null)
        {
            if (isSignInFormPayloadValidation)
            {
                if (string.IsNullOrWhiteSpace(authenticityToken))
                {
                    MessageBox.Show("Unable to retrieve authenticity token value", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (string.IsNullOrWhiteSpace(signInButtonValue))
                {
                    MessageBox.Show("Unable to retrieve sign-in button value", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                email = TxtBoxEmail.Text;
                password = TxtBoxPassword.Text;

                if (string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("Please provide your email address", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (string.IsNullOrWhiteSpace(password))
                {
                    MessageBox.Show("Please provide your password", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

    }
}
