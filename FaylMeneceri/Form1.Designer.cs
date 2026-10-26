namespace FaylMeneceri
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelUst = new Panel();
            btnQovluq = new Button();
            btnAc = new Button();
            btnSaxla = new Button();
            btnSil = new Button();
            txtYol = new TextBox();
            grpFayllar = new GroupBox();
            lstFayllar = new ListBox();
            lblMetn = new Label();
            txtMetn = new RichTextBox();
            pnlMelumat = new Panel();
            lblMelumat = new Label();
            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            panelUst.SuspendLayout();
            grpFayllar.SuspendLayout();
            pnlMelumat.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();

            // panelUst
            panelUst.BackColor = Color.FromArgb(38, 50, 56);
            panelUst.Dock = DockStyle.Top;
            panelUst.Height = 70;
            panelUst.Controls.Add(btnQovluq);
            panelUst.Controls.Add(btnAc);
            panelUst.Controls.Add(btnSaxla);
            panelUst.Controls.Add(btnSil);
            panelUst.Controls.Add(txtYol);

            // buttons
            ConfigButton(btnQovluq, "btnQovluq", "Qovluq seç", 15, Color.FromArgb(0, 150, 136));
            ConfigButton(btnAc, "btnAc", "Aç", 145, Color.FromArgb(33, 150, 243));
            ConfigButton(btnSaxla, "btnSaxla", "Yadda saxla", 275, Color.FromArgb(76, 175, 80));
            ConfigButton(btnSil, "btnSil", "Sil", 405, Color.FromArgb(229, 57, 53));
            btnQovluq.Click += btnQovluq_Click;
            btnAc.Click += btnAc_Click;
            btnSaxla.Click += btnSaxla_Click;
            btnSil.Click += btnSil_Click;

            // txtYol
            txtYol.Name = "txtYol";
            txtYol.ReadOnly = true;
            txtYol.Location = new Point(545, 22);
            txtYol.Size = new Size(330, 27);
            txtYol.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtYol.Text = @"C:\Users\...\Documents";

            // grpFayllar
            grpFayllar.Text = "Fayllar";
            grpFayllar.Location = new Point(15, 85);
            grpFayllar.Size = new Size(270, 400);
            grpFayllar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpFayllar.Controls.Add(lstFayllar);

            // lstFayllar
            lstFayllar.Name = "lstFayllar";
            lstFayllar.Dock = DockStyle.Fill;
            lstFayllar.BorderStyle = BorderStyle.None;
            lstFayllar.Font = new Font("Segoe UI", 10F);
            lstFayllar.SelectedIndexChanged += lstFayllar_SelectedIndexChanged;
            lstFayllar.DoubleClick += btnAc_Click;

            // lblMetn
            lblMetn.Text = "Mətn";
            lblMetn.AutoSize = true;
            lblMetn.Location = new Point(300, 90);
            lblMetn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // txtMetn (RichTextBox)
            txtMetn.Name = "txtMetn";
            txtMetn.Location = new Point(300, 115);
            txtMetn.Size = new Size(575, 370);
            txtMetn.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtMetn.ScrollBars = RichTextBoxScrollBars.Vertical;
            txtMetn.Font = new Font("Segoe UI", 11F);
            txtMetn.BorderStyle = BorderStyle.FixedSingle;

            // pnlMelumat
            pnlMelumat.BackColor = Color.White;
            pnlMelumat.BorderStyle = BorderStyle.FixedSingle;
            pnlMelumat.Location = new Point(15, 495);
            pnlMelumat.Size = new Size(860, 40);
            pnlMelumat.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlMelumat.Controls.Add(lblMelumat);

            // lblMelumat
            lblMelumat.Name = "lblMelumat";
            lblMelumat.Dock = DockStyle.Fill;
            lblMelumat.TextAlign = ContentAlignment.MiddleLeft;
            lblMelumat.Padding = new Padding(8, 0, 0, 0);
            lblMelumat.Text = "Fayl seçilməyib";

            // statusStrip1
            statusStrip1.Items.Add(lblStatus);
            lblStatus.Name = "lblStatus";
            lblStatus.Text = "Hazırdır";

            // Form1
            AutoScaleMode = AutoScaleMode.Font;
            AutoScaleDimensions = new SizeF(8F, 20F);
            ClientSize = new Size(890, 585);
            MinimumSize = new Size(800, 520);
            BackColor = Color.FromArgb(236, 239, 241);
            Text = "Fayl Meneceri";
            StartPosition = FormStartPosition.CenterScreen;
            Controls.Add(panelUst);
            Controls.Add(grpFayllar);
            Controls.Add(lblMetn);
            Controls.Add(txtMetn);
            Controls.Add(pnlMelumat);
            Controls.Add(statusStrip1);
            Name = "Form1";

            panelUst.ResumeLayout(false);
            panelUst.PerformLayout();
            grpFayllar.ResumeLayout(false);
            pnlMelumat.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void ConfigButton(Button b, string name, string text, int x, Color color)
        {
            b.Name = name;
            b.Text = text;
            b.Location = new Point(x, 17);
            b.Size = new Size(115, 36);
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = color;
            b.ForeColor = Color.White;
            b.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            b.Cursor = Cursors.Hand;
        }

        private Panel panelUst;
        private Button btnQovluq;
        private Button btnAc;
        private Button btnSaxla;
        private Button btnSil;
        private TextBox txtYol;
        private GroupBox grpFayllar;
        private ListBox lstFayllar;
        private Label lblMetn;
        private RichTextBox txtMetn;
        private Panel pnlMelumat;
        private Label lblMelumat;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;
    }
}
