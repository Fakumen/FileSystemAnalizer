using FileSystemAnalyzer.Domain;
using System;
using System.Windows.Forms;
using FileSystemAnalyzer.App;

namespace FileSystemAnalyzer.UI
{
    public partial class FileAnalizerForm : Form
    {
        private AnalyzerApp scannerApp => lazyScannerApp.Value;
        private readonly Lazy<AnalyzerApp> lazyScannerApp;
        public TreeView ScanHierarchyTree => fileHierarchyTree;
        public PictureBox SelectedNodeIconBox => selectedNodeIconBox;
        public ListBox SelectedNodePropertiesBox => selectedNodePropertiesBox;
        public Label SelectedNodeTitleLabel => selectedNodeTitleLabel;
        public Label SelectedNodeSizeLabel => selectedNodeSizeLabel;

        public FileAnalizerForm(Lazy<AnalyzerApp> scannerApp)
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