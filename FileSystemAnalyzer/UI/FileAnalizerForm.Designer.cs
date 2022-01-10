using System.Windows.Forms;
namespace FileSystemAnalyzer.UI
{
    partial class FileAnalizerForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.fileHierarchyTree = new System.Windows.Forms.TreeView();
            this.selectFolderButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selectedNodeTitleLabel = new System.Windows.Forms.Label();
            this.selectedNodePropertiesBox = new System.Windows.Forms.ListBox();
            this.selectedNodeIconBox = new System.Windows.Forms.PictureBox();
            this.sortButton = new System.Windows.Forms.Button();
            this.selectedNodeSizeLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedNodeIconBox)).BeginInit();
            this.SuspendLayout();
            // 
            // fileHierarchyTree
            // 
            this.fileHierarchyTree.Location = new System.Drawing.Point(42, 52);
            this.fileHierarchyTree.Name = "fileHierarchyTree";
            this.fileHierarchyTree.Size = new System.Drawing.Size(329, 361);
            this.fileHierarchyTree.TabIndex = 0;
            // 
            // selectFolderButton
            // 
            this.selectFolderButton.Location = new System.Drawing.Point(42, 12);
            this.selectFolderButton.Name = "selectFolderButton";
            this.selectFolderButton.Size = new System.Drawing.Size(126, 23);
            this.selectFolderButton.TabIndex = 1;
            this.selectFolderButton.Text = "Выбрать каталог";
            this.selectFolderButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Window;
            this.groupBox1.Controls.Add(this.selectedNodeSizeLabel);
            this.groupBox1.Controls.Add(this.selectedNodeTitleLabel);
            this.groupBox1.Controls.Add(this.selectedNodePropertiesBox);
            this.groupBox1.Controls.Add(this.selectedNodeIconBox);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(420, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(336, 361);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация об элементе";
            this.groupBox1.Visible = false;
            // 
            // selectedNodeTitleLabel
            // 
            this.selectedNodeTitleLabel.AutoSize = true;
            this.selectedNodeTitleLabel.Location = new System.Drawing.Point(150, 30);
            this.selectedNodeTitleLabel.Name = "selectedNodeTitleLabel";
            this.selectedNodeTitleLabel.Size = new System.Drawing.Size(88, 23);
            this.selectedNodeTitleLabel.TabIndex = 2;
            this.selectedNodeTitleLabel.Text = "Название";
            // 
            // selectedNodePropertiesBox
            // 
            this.selectedNodePropertiesBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.selectedNodePropertiesBox.FormattingEnabled = true;
            this.selectedNodePropertiesBox.HorizontalScrollbar = true;
            this.selectedNodePropertiesBox.ItemHeight = 19;
            this.selectedNodePropertiesBox.Location = new System.Drawing.Point(11, 174);
            this.selectedNodePropertiesBox.Name = "selectedNodePropertiesBox";
            this.selectedNodePropertiesBox.Size = new System.Drawing.Size(313, 175);
            this.selectedNodePropertiesBox.TabIndex = 1;
            // 
            // selectedNodeIconBox
            // 
            this.selectedNodeIconBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.selectedNodeIconBox.Location = new System.Drawing.Point(11, 27);
            this.selectedNodeIconBox.Name = "selectedNodeIconBox";
            this.selectedNodeIconBox.Size = new System.Drawing.Size(128, 128);
            this.selectedNodeIconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.selectedNodeIconBox.TabIndex = 0;
            this.selectedNodeIconBox.TabStop = false;
            // 
            // sortButton
            // 
            this.sortButton.Location = new System.Drawing.Point(193, 12);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(144, 23);
            this.sortButton.TabIndex = 1;
            this.sortButton.Text = "Сортировать по размеру";
            this.sortButton.UseVisualStyleBackColor = true;
            // 
            // selectedNodeSizeLabel
            // 
            this.selectedNodeSizeLabel.AutoSize = true;
            this.selectedNodeSizeLabel.Location = new System.Drawing.Point(150, 77);
            this.selectedNodeSizeLabel.Name = "selectedNodeSizeLabel";
            this.selectedNodeSizeLabel.Size = new System.Drawing.Size(39, 23);
            this.selectedNodeSizeLabel.TabIndex = 2;
            this.selectedNodeSizeLabel.Text = "Вес";
            // 
            // FileAnalizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.selectFolderButton);
            this.Controls.Add(this.fileHierarchyTree);
            this.Name = "FileAnalizerForm";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedNodeIconBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TreeView fileHierarchyTree;
        private Button selectFolderButton;
        private GroupBox groupBox1;
        private PictureBox selectedNodeIconBox;
        private ListBox selectedNodePropertiesBox;
        private Button sortButton;
        private Label selectedNodeTitleLabel;
        private Label selectedNodeSizeLabel;
    }
}

