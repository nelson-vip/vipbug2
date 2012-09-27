using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

using Emgu.CV;

namespace vipbug2
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        public App()
            : base()
        {
            /*
            AppDomainSetup appdomSetup = new AppDomainSetup()
            {
                ApplicationBase = Environment.CurrentDirectory,
                PrivateBinPath = @"bin\aforge;bin\emgu"
            };


            AppDomain newDomain = AppDomain.CreateDomain("VipbugDomain", null, appdomSetup);

            List<string> dlls = new List<string>();
            //列举所有可用探索目录           
            Console.WriteLine("***********seeking usable dir");
            foreach (var s in GetAvailablePath(newDomain.SetupInformation))
            {
                Console.WriteLine(s); Console.WriteLine();
                dlls.AddRange(Directory.GetFiles(s,"*.dll"));
            }
            foreach(var dll in dlls)
                newDomain.Load(Path.GetFileNameWithoutExtension(dll));

            //输出新AppDomain加载的程序集的信息     
            foreach (var ass in newDomain.GetAssemblies())
                Console.WriteLine("***********loaded process：" + ass.FullName);
            //Console.ReadKey();

            /*
            bool authenticated = false;
            LoginWindow login;
            while (!authenticated)
            {
                login = new LoginWindow();
                login.ShowDialog();
                authenticated = ValidUser(login.username, login.password);
            }
            
            MainWindow main = new MainWindow(login.username);
            main.ShowDialog();
             * */
        }
    

        static IEnumerable<string> GetAvailablePath(AppDomainSetup set)
        {
            if (set.ApplicationBase == null)
                return Enumerable.Empty<string>();
            if (set.PrivateBinPath != null)
                return set.PrivateBinPath.Split(';').Select(s => Path.Combine(set.ApplicationBase, s));
            return new string[] { set.ApplicationBase };
        }
    }
}
