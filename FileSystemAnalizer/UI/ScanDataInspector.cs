using FileSystemAnalyzer.App;
using FileSystemAnalyzer.Domain;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using FileSystemAnalyzer.Infrastructure;
using Ninject;

namespace FileSystemAnalyzer.UI
{
    public class ScanDataInspector : IScanDataInspector
    {
        private readonly PictureBox iconBox;
        private readonly ListBox propertiesBox;
        private readonly Label titleLabel;
        private readonly Label sizeLabel;

        public ScanDataInspector(
            [Named("SelectedNodeIcon")] PictureBox iconBox,
            [Named("SelectedNodeProperties")] ListBox propertiesBox, 
            [Named("SelectedNodeTitle")] Label titleLabel,
            [Named("SelectedNodeSize")] Label sizeLabel)
        {
            this.iconBox = iconBox;
            this.propertiesBox = propertiesBox;
            this.titleLabel = titleLabel;
            this.sizeLabel = sizeLabel;
        }

        public void DisplayDetailedScanDataInformation(IFolderDataNode folderDataNode)
        {
            var data = folderDataNode.ScanData;
            iconBox.Image = IconPool.GetIconByKey(IconPool.FolderIconKey);
            DisplayCommonInformation(data);
        }

        public void DisplayDetailedScanDataInformation(IFileDataNode fileDataNode)
        {
            var data = fileDataNode.ScanData;
            using (var icon = Icon.ExtractAssociatedIcon(data.Path))
                iconBox.Image = icon.ToBitmap();
            DisplayCommonInformation(data);
        }

        private void DisplayCommonInformation<TData>(TData data)
            where TData : IFileSystemScanData
        {
            titleLabel.Text = data.Name;
            var size = data.Size.ToString();
            if (data is IFolderScanData folderData)
            {
                size = folderData.IsInspected ? size : "??? Byte";
            }
            sizeLabel.Text = size;
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
                //Временный костыль для игнорирования ненужных свойств
                if (p.Name == "Folders" || p.Name == "Files" || p.Name == "IsDataReady")
                    continue;
                //Для замены, возможно использовать аттрибуты для отображаемых свойств в Domain
                //Либо дублировать свойства в DataNode и ставить аттрибуты им, уже в слое App/UI

                var hasLazyDataAttribute = p.GetCustomAttributes<LazyDataAttribute>().Count() > 0;
                var dataIsUnknown = hasLazyDataAttribute && !isInspected;
                var propertyValue = dataIsUnknown ? "???" : p.GetValue(data).ToString();
                propertiesBox.Items.Add($"{p.Name}: {propertyValue}");
            }
        }
    }
}