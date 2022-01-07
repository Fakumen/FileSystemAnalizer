﻿using FileSystemAnalizer.Domain;
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
        private readonly FileSystemScanDataTree scanDataTree;
        public FileAnalizerForm(ScannerApp scannerApp)
        {
            InitializeComponent();
            this.scannerApp = scannerApp;
            scanDataTree = new FileSystemScanDataTree(FileHierarchyTree, IconPool.GetImageList());
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
                    Action<IFolderScanData> onScanFinished = CreateNode;
                    scannerApp.OnStartScanButtonClick(dialog.SelectedPath, onScanFinished);
                }
            }
        }

        private void FileHierarchyTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node is IFileDataNode)
            {
                var fileNode = e.Node as IFileDataNode;
                e.Node.Text = $"{fileNode.ScanData.Path}";
            }
        }

        private void CreateNode(IFolderScanData firstFolderScanData)
        {
            scanDataTree.Clear();
            scanDataTree.AddNode(new FolderDataNode(firstFolderScanData));
        }
    }
}