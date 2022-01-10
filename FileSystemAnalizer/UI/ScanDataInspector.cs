using FileSystemAnalizer.App;
using FileSystemAnalizer.Domain;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using FileSystemAnalizer.Infrastructure;
using Ninject;

namespace FileSystemAnalizer.UI
{
    public class ScanDataInspector : IScanDataInspector
    {
        private readonly PictureBox iconBox;
        private readonly ListBox propertiesBox;
        private readonly Label titleLabel;

        public ScanDataInspector(
            [Named("SelectedNodeIcon")] PictureBox iconBox,
            [Named("SelectedNodeProperties")] ListBox propertiesBox, 
            [Named("SelectedNodeTitle")] Label titleLabel)
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