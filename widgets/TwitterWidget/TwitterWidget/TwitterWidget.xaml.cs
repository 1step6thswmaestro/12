using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using DotNetOpenAuth.OAuth;
using System.Threading;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

using LinqToTwitter;
using System.Windows.Threading;

namespace TwitterWidget
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();

            Timeline.Children.Clear();
            refresh();
            stream();
        }
        
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        private SingleUserAuthorizer authorizer = new SingleUserAuthorizer
        {
            CredentialStore = new SingleUserInMemoryCredentialStore
            {
                ConsumerKey = "Ag6SLQ18wa2VxFukDkisjvllf",
                ConsumerSecret = "wIARhN2BpcgqSTB3nMS9NDm5ktaapNeTKZCv4K07ShL9tuBX2W",
                AccessToken = "1310844906-JAoo9N8MqUQ8SWjPmjf1gozgNFomsMZaFmBA5kO",
                AccessTokenSecret = "RYSRcdHFTNcxLbA5n199BwWSMef5YK5sLifK5QO5oe8wB"
            }
        };

        private void refreshTimeLine(object sender, EventArgs e)
        {
            Timeline.Children.Clear();
            refresh();
        }

        private void addTweet(string name, string id, string text)
        {
            _flag = true;

            StackPanel _newTweet = new StackPanel { Width = 56 };
            Grid _innerGrid = new Grid();

            StackPanel _userInfo = new StackPanel { Orientation = Orientation.Horizontal };
            _userInfo.Children.Add(new TextBlock
            {
                Text = name,
                Style = Resources["UserName"] as Style
            });
            _userInfo.Children.Add(new TextBlock
            {
                Text = " @" + id,
                Style = Resources["UserID"] as Style
            });
            _innerGrid.Children.Add(new TextBlock
            {
                Text = "no time",
                Style = Resources["Timespan"] as Style
            });

            _innerGrid.Children.Add(_userInfo);
            _newTweet.Children.Add(_innerGrid);
            string _replacedTweet = text.Replace("\n", "");
            _newTweet.Children.Add(new TextBlock
            {
                Text = _replacedTweet.Substring(0,
                        (_replacedTweet.Length > 40 ?
                                40 :
                                _replacedTweet.Length)),
                Style = Resources["Tweet"] as Style
            });
            _newTweet.Children.Add(new TextBlock { Text = "", FontSize = 1 });

            Timeline.Children.Insert(0, _newTweet);
            while (Timeline.Children.Count > 10)
            {
                Timeline.Children.RemoveAt(10);
            }
            _flag = false;
        }

        private void addTweet(Status status)
        {
            _flag = true;

            StackPanel _newTweet = new StackPanel { Width = 56 };
            Grid _innerGrid = new Grid();

            StackPanel _userInfo = new StackPanel { Orientation = Orientation.Horizontal };
            _userInfo.Children.Add(new TextBlock
            {
                Text = status.User.Name,
                Style = Resources["UserName"] as Style
            });
            _userInfo.Children.Add(new TextBlock
            {
                Text = status.User.ScreenName,
                Style = Resources["UserID"] as Style
            });
            _innerGrid.Children.Add(new TextBlock
            {
                Text = status.CreatedAt.ToShortTimeString(),
                Style = Resources["Timespan"] as Style
            });

            _innerGrid.Children.Add(_userInfo);
            _newTweet.Children.Add(_innerGrid);
            string _replacedTweet = status.Text.Replace("\n", "");
            _newTweet.Children.Add(new TextBlock
            {
                Text = _replacedTweet.Substring(0,
                        (_replacedTweet.Length > 40 ?
                                40 :
                                _replacedTweet.Length)),
                Style = Resources["Tweet"] as Style
            });
            _newTweet.Children.Add(new TextBlock { Text = "", FontSize = 1 });

            Timeline.Children.Insert(0, _newTweet);
            while (Timeline.Children.Count > 10) {
                Timeline.Children.RemoveAt(10);
            }
            _flag = false;
        }

        bool _flag = false;

        private async void stream()
        {
            var twitterContext = new TwitterContext(authorizer);

            int count = 0;

            await
                (from strm in twitterContext.Streaming
                 where strm.Type == StreamingType.User
                 select strm)
                .StartAsync(async strm =>
                {
                    string message =
                        string.IsNullOrEmpty(strm.Content) ?
                            "Keep-Alive" : strm.Content;

                    if (message.Contains("created_at")) {

                        while (_flag != false);

                        Dispatcher.Invoke(DispatcherPriority.Normal, new Action(delegate
                        {
                            dynamic obj = JsonConvert.DeserializeObject(message);
                            string name = obj.user.name;
                            string id = obj.user.screen_name;
                            string text = obj.text;
                            addTweet(name, id, text);
                        }));
                    }

                    if (count++ == 10)
                    {
                        strm.CloseStream();
                    }
                });
        }

        private async void refresh()
        {
            try
            {
                var twitterContext = new TwitterContext(authorizer);
                var tweets = from tweet in twitterContext.Status
                             where tweet.Type == StatusType.Home
                             && tweet.Count == 20
                             select tweet;

                foreach (Status status in tweets)
                {
                    addTweet(status);
                }
            }
            catch (Exception e){
                Console.WriteLine(e.ToString());
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }
    }
}
