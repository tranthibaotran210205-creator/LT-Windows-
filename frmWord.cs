using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB03_002
{
    public partial class frmEditor : Form
    {
        private string currentFile = ""; // lưu tên file hiện tại

        public frmEditor()
        {
            InitializeComponent();
        }

        private void frmEditor_Load(object sender, EventArgs e)
        {
            // Nạp font chữ thủ công (một số font thông dụng)
            string[] fonts = { "Tahoma", "Times New Roman", "Arial", "Courier New", "Verdana" };
            cmbFont.Items.AddRange(fonts);
            cmbFont.SelectedItem = "Tahoma";

            // Nạp size thủ công
            int[] sizes = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (int size in sizes)
            {
                cmbSize.Items.Add(size.ToString());
            }
            cmbSize.SelectedItem = "14";

            // Font mặc định
            richTextBox1.Font = new Font("Tahoma", 14);
        }

        // ---------------- File Menu ----------------

        // New
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Font = new Font("Tahoma", 14);
            cmbFont.SelectedItem = "Tahoma";
            cmbSize.SelectedItem = "14";
            currentFile = "";
        }

        // Open
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Files|*.txt|Rich Text Format|*.rtf";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName.EndsWith(".txt"))
                    richTextBox1.LoadFile(ofd.FileName, RichTextBoxStreamType.PlainText);
                else
                    richTextBox1.LoadFile(ofd.FileName, RichTextBoxStreamType.RichText);

                currentFile = ofd.FileName;
            }
        }

        // Save
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFile))
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Text Files|*.txt|Rich Text Format|*.rtf";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (sfd.FileName.EndsWith(".txt"))
                        richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText);
                    else
                        richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.RichText);

                    currentFile = sfd.FileName;
                }
            }
            else
            {
                if (currentFile.EndsWith(".txt"))
                    richTextBox1.SaveFile(currentFile, RichTextBoxStreamType.PlainText);
                else
                    richTextBox1.SaveFile(currentFile, RichTextBoxStreamType.RichText);
            }
        }

        // Exit
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // ---------------- Format Menu ----------------

        // Font Dialog
        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            fd.Font = richTextBox1.SelectionFont;
            if (fd.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fd.Font;
            }
        }

        // ---------------- ToolStrip Buttons ----------------

        private void btnBold_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Bold);
        }

        private void btnItalic_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Italic);
        }

        private void btnUnderline_Click(object sender, EventArgs e)
        {
            ToggleFontStyle(FontStyle.Underline);
        }

        private void ToggleFontStyle(FontStyle style)
        {
            if (richTextBox1.SelectionFont != null)
            {
                Font currentFont = richTextBox1.SelectionFont;
                FontStyle newStyle;

                if (richTextBox1.SelectionFont.Style.HasFlag(style))
                    newStyle = currentFont.Style & ~style; // bỏ style
                else
                    newStyle = currentFont.Style | style;  // thêm style

                richTextBox1.SelectionFont = new Font(currentFont.FontFamily, currentFont.Size, newStyle);
            }
        }

        // ---------------- ComboBox ----------------

        private void cmbFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFont.SelectedItem != null && cmbSize.SelectedItem != null)
            {
                float size = float.Parse(cmbSize.SelectedItem.ToString());
                richTextBox1.SelectionFont = new Font(cmbFont.SelectedItem.ToString(), size);
            }
        }

        private void cmbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFont.SelectedItem != null && cmbSize.SelectedItem != null)
            {
                float size = float.Parse(cmbSize.SelectedItem.ToString());
                richTextBox1.SelectionFont = new Font(cmbFont.SelectedItem.ToString(), size);
            }
        }
    }
}