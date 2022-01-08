using FileSystemAnalizer.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FileSystemAnalizer.App;

namespace FileSystemAnalizer.UI
{
    public partial class FileAnalizerForm : Form
    {
        private ScannerApp scannerApp => lazyScannerApp.Value;
        private readonly Lazy<ScannerApp> lazyScannerApp;
        public TreeView ScanHierarchyTree => FileHierarchyTree;

        public FileAnalizerForm(Lazy<ScannerApp> scannerApp)
        {
            InitializeComponent();
            lazyScannerApp = scannerApp;
            //scanDataTree = new ScanDataTreeBuilder(FileHierarchyTree, IconPool.ImageList);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            FileHierarchyTree.AfterSelect += FileHierarchyTree_AfterSelect;
        }

        private void SelectFolderButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                var result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    scannerApp.OnStartScanButtonClick(
                        dialog.SelectedPath, 
                        folderData => new FolderDataNode(folderData),
                        fileData => new FileDataNode(fileData));
                }
            }
        }

        private void FileHierarchyTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //var ee = e.Node is FileDataNode;
            //var a = e.Node is IFileDataNode;
            //var b = e.Node is IDataNode<IFileScanData>;
            //var c = e.Node is IDataNode<IScanData>;
            //var d = e.Node is IDataNode<FileScanData>;//false
            scannerApp.OnSelectNode((IDataNode<IScanData>)e.Node);
        }
    }
}