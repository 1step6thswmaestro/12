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

            TestCode();
        }

        private void TestCode()
        {
            var twitter = new Twitter.Twitter
            {
                OAuthConsumerKey = "Ag6SLQ18wa2VxFukDkisjvllf",
                OAuthConsumerSecret = "wIARhN2BpcgqSTB3nMS9NDm5ktaapNeTKZCv4K07ShL9tuBX2W"
            };
            IEnumerable<string> twitts = twitter.GetTwitts("skyblue_ray", 5).Result;
            foreach (var t in twitts)
            {
                Console.WriteLine(t);
                break;
            }
        }
    }
}
