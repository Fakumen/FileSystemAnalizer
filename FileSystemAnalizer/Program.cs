using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileSystemAnalizer.App;
using FileSystemAnalizer.UI;
using Ninject;
using System.IO;

namespace FileSystemAnalizer
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
            container.Bind<ScannerApp>().ToSelf().InSingletonScope();
            container.Bind<IScanDataTreeBuilder>().To<ScanDataTreeBuilder>().InSingletonScope();
            container.Bind<FileAnalizerForm>().ToSelf().InSingletonScope();
            container.Bind<ImageList>().ToConstant(IconPool.ImageList).InSingletonScope();

            var form = container.Get<FileAnalizerForm>();

            container.Bind<TreeView>().ToConstant(form.ScanHierarchyTree).WhenInjectedInto<IScanDataTreeBuilder>();
            container.Bind<PictureBox>().ToConstant(form.SelectedNodeIconBox).WhenInjectedInto<IScanDataInspector>();
            container.Bind<ListBox>().ToConstant(form.SelectedNodePropertiesBox).WhenInjectedInto<IScanDataInspector>();
            container.Bind<Label>().ToConstant(form.SelectedNodeTitleLabel).WhenInjectedInto<IScanDataInspector>();
            container.Bind<IScanDataInspector>().To<ScanDataInspector>().InSingletonScope();
            container.Bind<ScanDataInspector>().ToSelf();
            Application.Run(form);
        }
    }
}
