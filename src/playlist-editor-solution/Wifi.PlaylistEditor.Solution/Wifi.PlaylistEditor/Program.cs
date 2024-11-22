using Autofac;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Wifi.PlaylistEditor.CommonTypes;
using Wifi.PlaylistEditor.Core;
using Wifi.PlaylistEditor.Factories;

namespace Wifi.PlaylistEditor
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<frm_CreateNewPlaylist>().As<ICreatePlaylist>();
            builder.RegisterType<PlaylistFactory>().As<IPlaylistFactory>();
            builder.RegisterType<DynamicRepositoryFactory>().As<IRepositoryFactory>();            
            builder.RegisterType<PlaylistItemFactory>().As<IPlaylistItemFactory>();
            builder.RegisterType<frm_main>();

            RegisterFromAssemblies(builder);

            var container = builder.Build();


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<frm_main>());
        }

        private static void RegisterFromAssemblies(ContainerBuilder builder)
        {
            var filePath = Assembly.GetExecutingAssembly().Location;

            DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(filePath));
            var files = directoryInfo.EnumerateFiles("Wifi.*.dll");
            
            foreach (var assemblyPath in files)
            {
                var dataAccess = Assembly.LoadFile(assemblyPath.FullName);

                builder.RegisterAssemblyTypes(dataAccess)
                    .Where(t => t.Name.EndsWith("Repository"))
                    .AsImplementedInterfaces();
            }
        }
    }
}
