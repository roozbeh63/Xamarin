using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Microsoft.Extensions.Logging;
using BenchTest.Views;
using BenchTest.ViewModels;
using Workstation.ServiceModel.Ua;




namespace BenchTest
{
    public partial class App : Application
    {
        private string discoveryUrl = @"opc.tcp://192.168.0.100:4840";
        private ILoggerFactory loggerFactory;
        private ILogger logger;
        private static UaTcpSessionClient session;
        public static UaTcpSessionClient Session { get { return session; } set { session = value; }  }
        public static Services.INotification Notification { get; set; }

        public App()
        {
            InitializeComponent();
        }

        protected  override void OnStart()
        {
            this.loggerFactory = new LoggerFactory();
            this.loggerFactory.AddDebug(LogLevel.Trace); // new
            this.logger = this.loggerFactory.CreateLogger<App>();

            var appDescription = new ApplicationDescription()
            {
                ApplicationName = "HmiTablet",
                ApplicationUri = $"urn:{System.Net.Dns.GetHostName()}:HmiTablet",
                ApplicationType = ApplicationType.Client,
            };

            var getEndpointsResponse = UaTcpDiscoveryClient.GetEndpointsAsync(
                new GetEndpointsRequest
                {
                    EndpointUrl = this.discoveryUrl,
                    ProfileUris = new[] { TransportProfileUris.UaTcpTransport }
                }).Result;
            var selectedEndpoint = getEndpointsResponse.Endpoints.First(e => e.SecurityMode == MessageSecurityMode.None);

            App.Session = new UaTcpSessionClient(
     appDescription,
     new DirectoryStore(Environment.ExpandEnvironmentVariables(@"%LOCALAPPDATA%\Workstation.ConsoleApp\pki")),
     ProvideUserIdentity,
     selectedEndpoint,
     loggerFactory: this.loggerFactory);


            TabbedPage view = new TabbedPage
            {
                //BindingContext = viewModel,
                Children =
                {
                    new MainPage()
                    {
                        Title = "Main"
                    },
                     new Energy()
                    {
                        Title = "Energy"                        
                    },
                    new TrendingEnergy()
                    {
                        Title = "Trending Energy"
                    },
                     new AlarmPage()
                    {
                        Title = "Alarms"
                    }
                }
            };
            
            this.MainPage = view;
            //MainPage = new BenchTest.Views.MainPage();
        }

        protected override void OnSleep()
        {
            App.session?.SuspendAsync().Wait();
        }

        protected override void OnResume()
        {
            App.session?.Resume();
        }

        private Task<IUserIdentity> ProvideUserIdentity(EndpointDescription endpoint)
        {
            // Due to problem with dns on android emulator, the endpoint url's hostname is rewritten with an ip address.
            endpoint.EndpointUrl = this.discoveryUrl;
            if (endpoint.UserIdentityTokens.Any(p => p.TokenType == UserTokenType.Anonymous))
            {
                return Task.FromResult<IUserIdentity>(new AnonymousIdentity());
            }

            if (endpoint.UserIdentityTokens.Any(p => p.TokenType == UserTokenType.UserName))
            {
                return Task.FromResult<IUserIdentity>(new UserNameIdentity("root", "secret"));
            }

            return Task.FromResult<IUserIdentity>(new AnonymousIdentity());
        }

    }
}
