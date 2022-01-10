using FileSystemAnalizer.App;
using FileSystemAnalizer.Domain;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using FileSystemAnalizer.Infrastructure;

namespace FileSystemAnalizer.UI
{
    public class ScanDataInspector : IScanDataInspector
    {
        private readonly PictureBox iconBox;
        private readonly ListBox propertiesBox;
        private readonly Label titleLabel;

        public ScanDataInspector(PictureBox iconBox, ListBox propertiesBox, Label titleLabel)
        {
            this.iconBox = iconBox;
            this.propertiesBox = propertiesBox;
            this.titleLabel = titleLabel;
        }

        public void DisplayDetailedScanDataInformation(IFolderDataNode folderDataNode)
        {
            var data = folderDataNode.ScanData;
            iconBox.Image = IconPool.GetIconByKey(IconPool.FolderIconKey);
            titleLabel.Text = data.Name;
            propertiesBox.Items.Clear();
            AddProperties(data);
        }

        public void DisplayDetailedScanDataInformation(IFileDataNode fileDataNode)
        {
            var data = fileDataNode.ScanData;
            using (var icon = Icon.ExtractAssociatedIcon(data.Path))
                iconBox.Image = icon.ToBitmap();
            titleLabel.Text = data.Name;
            propertiesBox.Items.Clear();
            AddProperties(data);
        }

        private void AddProperties<TData>(TData data)
            where TData : IFileSystemScanData
        {
            var properties = data.GetType().GetProperties();
            var isInspected = false;
            //var properties = new PropertyInfo[0];
            //if (data is IFileScanData)
            //{
            //    properties = typeof(IFileScanData).GetProperties();
            //}
            //else if (data is IFolderScanData)
            //{
            //    properties = typeof(IFolderScanData).GetProperties();
            //}
            if (data is IFolderScanData folderData)
            {
                isInspected = folderData.IsInspected;
            }
            foreach (var p in properties)
            {
                var hasLazyDataAttribute = p.GetCustomAttributes<LazyDataAttribute>().Count() > 0;
                var dataIsUnknown = hasLazyDataAttribute && !isInspected;
                var propertyValue = dataIsUnknown ? "???" : p.GetValue(data).ToString();
                propertiesBox.Items.Add($"{p.Name}: {propertyValue}");
            }
        }
    }
}