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
        public TreeView ScanHierarchyTree => fileHierarchyTree;
        public PictureBox SelectedNodeIconBox => selectedNodeIconBox;
        public ListBox PropertiesInfoListBox => propertiesInfoListBox;

        public FileAnalizerForm(Lazy<ScannerApp> scannerApp)
        {
            InitializeComponent();
            lazyScannerApp = scannerApp;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            fileHierarchyTree.AfterSelect += FileHierarchyTree_AfterSelect;
            fileHierarchyTree.AfterExpand += FileHierarchyTree_AfterExpand;
            selectFolderButton.Click += OnSelectFolderButtonClick;
            sortButton.Click += OnSortButtonClick;
        }

        private void OnSelectFolderButtonClick(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                var result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    scannerApp.OnStartScanButtonClick(dialog.SelectedPath);
                }
            }
        }

        private void FileHierarchyTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            groupBox1.Visible = true;
            scannerApp.OnSelectDataNode((IDataNode<IFileSystemScanData>)e.Node);
        }

        private void OnSortButtonClick(object sender, EventArgs e)
        {
            scannerApp.OnSortButtonClick();
        }

        private void FileHierarchyTree_AfterExpand(object sender, TreeViewEventArgs e)
        {

        }
    }
}