using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Reflection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;

namespace MscrmTools.RelationshipMappingEditor
{
    // Do not forget to update version number and author (company attribute) in AssemblyInfo.cs class
    // To generate Base64 string for Images below, you can use https://www.base64-image.de/
    [Export(typeof(IXrmToolBoxPlugin)),
        ExportMetadata("Name", "Relationship Mapping Editor"),
        ExportMetadata("Description", "This tool allows to edit attributes mappings for relationships"),
        // Please specify the base64 content of a 32x32 pixels image
        ExportMetadata("SmallImageBase64", "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"),
        // Please specify the base64 content of a 80x80 pixels image
        ExportMetadata("BigImageBase64", "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"),
        ExportMetadata("BackgroundColor", "#606060"),
        ExportMetadata("PrimaryFontColor", "White"),
        ExportMetadata("SecondaryFontColor", "White")]
    public class RelationshipMappingEditorPlugin : PluginBase, IPayPalPlugin
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public RelationshipMappingEditorPlugin()
        {
            // If you have external assemblies that you need to load, uncomment the following to
            // hook into the event that will fire when an Assembly fails to resolve
            // AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(AssemblyResolveEventHandler);
        }

        public string DonationDescription => "Donation for Relationship Mapping Editor";
        public string EmailAccount => "tanguy92@hotmail.com";

        public override IXrmToolBoxPluginControl GetControl()
        {
            return new RelationshipMappingEditorPluginControl();
        }

        /// <summary>
        /// Event fired by CLR when an assembly reference fails to load
        /// Assumes that related assemblies will be loaded from a subfolder named the same as the Plugin
        /// For example, a folder named Sample.XrmToolBox.MyPlugin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        private Assembly AssemblyResolveEventHandler(object sender, ResolveEventArgs args)
        {
            Assembly loadAssembly = null;
            Assembly currAssembly = Assembly.GetExecutingAssembly();

            // base name of the assembly that failed to resolve
            var argName = args.Name.Substring(0, args.Name.IndexOf(","));

            // check to see if the failing assembly is one that we reference.
            List<AssemblyName> refAssemblies = currAssembly.GetReferencedAssemblies().ToList();
            var refAssembly = refAssemblies.Where(a => a.Name == argName).FirstOrDefault();

            // if the current unresolved assembly is referenced by our plugin, attempt to load
            if (refAssembly != null)
            {
                // load from the path to this plugin assembly, not host executable
                string dir = Path.GetDirectoryName(currAssembly.Location).ToLower();
                string folder = Path.GetFileNameWithoutExtension(currAssembly.Location);
                dir = Path.Combine(dir, folder);

                var assmbPath = Path.Combine(dir, $"{argName}.dll");

                if (File.Exists(assmbPath))
                {
                    loadAssembly = Assembly.LoadFrom(assmbPath);
                }
                else
                {
                    throw new FileNotFoundException($"Unable to locate dependency: {assmbPath}");
                }
            }

            return loadAssembly;
        }
    }
}