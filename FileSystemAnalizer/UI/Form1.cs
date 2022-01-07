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
        private readonly ScannerApp scannerApp;
        public FileAnalizerForm(ScannerApp scannerApp)
        {
            InitializeComponent();
            this.scannerApp = scannerApp;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            FileHierarchyTree.AfterSelect += FileHierarchyTree_AfterSelect;
        }

        private void SelectFolderButton_Click(object sender, EventArgs e)
        {
            using(var dialog = new FolderBrowserDialog())
            {
                var result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    FileHierarchyTree.ImageList = IconPool.GetImageList();
                    var firstFolderScanData = scannerApp.Scan(dialog.SelectedPath);
                    //var scanner = new FolderScanner() as Scanner<string, FolderScanData>;
                    var hierarchy = new FileSystemScanDataTree(FileHierarchyTree);
                    hierarchy.Clear();
                    hierarchy.AddNode(new FolderDataNode(firstFolderScanData));
                }
            }
        }

        private void FileHierarchyTree_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
