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
        ExportMetadata("Name", "Relationship Attributes Mapping Editor"),
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