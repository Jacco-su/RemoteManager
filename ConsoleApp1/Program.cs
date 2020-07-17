using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using Twoxzi.RemoteManager.Tools;

namespace ConsoleApp1
{
    [Export]
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
            DirectoryCatalog catalog = new DirectoryCatalog(AppDomain.CurrentDomain.BaseDirectory);
            CompositionContainer container = new CompositionContainer(catalog);
            

            Program program = new Program();
            container.ComposeParts(program);
            //foreach(var item in container.GetExports<IRemoteTool,IRemoteToolMetadata>())
            foreach(var item in program.List)
            {
                Console.WriteLine($"{item.Metadata.ToolCode}_{item.Metadata.ToolName}");
            }
            Console.WriteLine("End");
            Console.ReadKey();
        }

        [ImportMany(typeof(IRemoteTool))]
        //[ImportMany]
        public List<Lazy<IRemoteTool, IRemoteToolMetadata>> List { get; set; }
    }
}
