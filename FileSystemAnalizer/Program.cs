using System;
using System.IO;
using System.Windows.Forms;
using FileSystemAnalyzer.App;
using FileSystemAnalyzer.Domain;
using FileSystemAnalyzer.UI;
using Ninject;
using Ninject.Extensions.Conventions;

namespace FileSystemAnalyzer
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var container = new StandardKernel();
            container.Bind(c => c.FromThisAssembly().SelectAllClasses().BindAllInterfaces());
            //container.Bind<IScanDataTreeBuilder>().To<ScanDataTreeBuilder>().InSingletonScope();
            //container.Bind<IScanDataInspector>().To<ScanDataInspector>().InSingletonScope();
            container.Bind<Scanner<IFolderScanData>>().ToSelf().WithConstructorArgument((Func<DirectoryInfo, IFolderScanData>)(info => new FolderScanData(info)));

            var form = container.Get<FileAnalizerForm>();
            container.Bind<TreeView>().ToConstant(form.ScanHierarchyTree).WhenInjectedInto<ScanDataTreeBuilder>().Named("ScanHierarchyTree");
            container.Bind<PictureBox>().ToConstant(form.SelectedNodeIconBox).WhenInjectedInto<ScanDataInspector>().Named("SelectedNodeIcon");
            container.Bind<ListBox>().ToConstant(form.SelectedNodePropertiesBox).WhenInjectedInto<ScanDataInspector>().Named("SelectedNodeProperties");
            container.Bind<Label>().ToConstant(form.SelectedNodeTitleLabel).WhenInjectedInto<ScanDataInspector>().Named("SelectedNodeTitle");
            container.Bind<Label>().ToConstant(form.SelectedNodeSizeLabel).WhenInjectedInto<ScanDataInspector>().Named("SelectedNodeSize");
            container.Bind<ImageList>().ToConstant(IconPool.ImageList).WhenInjectedInto<ScanDataTreeBuilder>();
            Application.Run(form);
        }
    }
}
