using MailChimp.Net.Models;
using Marten;
using System.Configuration;
using System.Windows;


namespace CustomerManager
{
    public partial class App : Application
    {
        public App()
        {
            //Store = DocumentStore.For(ConfigurationManager.ConnectionStrings["CustomerDb"].ConnectionString);
            Store = DocumentStore.For(configure =>
           {
               configure.Connection(ConfigurationManager.ConnectionStrings["CustomerDb"].ConnectionString);
               configure.Schema.For<Customer>().ForeignKey<AccountManager>(Key => Key.AccountManagerId);
           });
        }
        public static IDocumentStore Store { get; private set; }
    }
}
