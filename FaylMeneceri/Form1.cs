using System.IO;

namespace FaylMeneceri
{
    public partial class Form1 : Form
    {
        private string cariQovluq = "";

        public Form1()
        {
            InitializeComponent();
            StatusYenile();
        }

        // ---------- Qovluq seç ----------
        private void btnQovluq_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Qovluğu seçin";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    cariQovluq = fbd.SelectedPath;
                    txtYol.Text = cariQovluq;
                    FayllariYukle();
                }
            }
        }

        private void FayllariYukle()
        {
            lstFayllar.Items.Clear();
            txtMetn.Clear();
            lblMelumat.Text = "Fayl seçilməyib";

            if (!Directory.Exists(cariQovluq)) return;

            try
            {
                foreach (string yol in Directory.GetFiles(cariQovluq))
                    lstFayllar.Items.Add(Path.GetFileName(yol));
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("Bu qovluğa giriş icazəsi yoxdur.", "Xəta",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            StatusYenile();
        }

        // ---------- Seçilmiş faylın məlumatı ----------
        private void lstFayllar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string yol = SecilmisYol();
            if (yol == null || !File.Exists(yol))
            {
                lblMelumat.Text = "Fayl seçilməyib";
                return;
            }
            var fi = new FileInfo(yol);
            lblMelumat.Text = $"Ad: {fi.Name}      Ölçü: {fi.Length / 1024.0:F1} KB      " +
                              $"Yaranma tarixi: {fi.CreationTime:dd.MM.yyyy}";
        }

        // ---------- Aç ----------
        private void btnAc_Click(object sender, EventArgs e)
        {
            string yol = SecilmisYol();
            if (yol == null)
            {
                MessageBox.Show("Zəhmət olmasa siyahıdan fayl seçin.", "Xəbərdarlıq",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (Path.GetExtension(yol).Equals(".rtf", StringComparison.OrdinalIgnoreCase))
                    txtMetn.LoadFile(yol, RichTextBoxStreamType.RichText);
                else
                    txtMetn.Text = File.ReadAllText(yol);

                lblStatus.Text = $"Açıldı: {Path.GetFileName(yol)}  |  Fayl sayı: {lstFayllar.Items.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fayl oxunmadı: " + ex.Message, "Xəta",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ---------- Yadda saxla (fayl yaradır) ----------
        private void btnSaxla_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Title = "Yeni fayl yarat";
                sfd.Filter = "Mətn faylı (*.txt)|*.txt|RTF faylı (*.rtf)|*.rtf";
                sfd.DefaultExt = "txt";
                if (Directory.Exists(cariQovluq))
                    sfd.InitialDirectory = cariQovluq;

                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    if (Path.GetExtension(sfd.FileName).Equals(".rtf", StringComparison.OrdinalIgnoreCase))
                        txtMetn.SaveFile(sfd.FileName, RichTextBoxStreamType.RichText);
                    else
                        File.WriteAllText(sfd.FileName, txtMetn.Text);

                    // Fayl cari qovluqda yaradılıbsa siyahını yenilə
                    if (string.IsNullOrEmpty(cariQovluq))
                    {
                        cariQovluq = Path.GetDirectoryName(sfd.FileName);
                        txtYol.Text = cariQovluq;
                    }
                    string metn = txtMetn.Rtf; // yenilənmədən əvvəl mətni saxla
                    FayllariYukle();
                    txtMetn.Rtf = metn;

                    int index = lstFayllar.Items.IndexOf(Path.GetFileName(sfd.FileName));
                    if (index >= 0) lstFayllar.SelectedIndex = index;

                    MessageBox.Show("Fayl uğurla yaradıldı.", "Məlumat",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fayl yaradılmadı: " + ex.Message, "Xəta",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ---------- Sil ----------
        private void btnSil_Click(object sender, EventArgs e)
        {
            string yol = SecilmisYol();

            // Fayl seçilməyibsə silmə
            if (yol == null)
            {
                MessageBox.Show("Silmək üçün əvvəlcə fayl seçin.", "Xəbərdarlıq",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult cavab = MessageBox.Show(
                $"\"{Path.GetFileName(yol)}\" faylı silinsin?\n\nYol: {yol}",
                "Silməni təsdiqlə",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cavab == DialogResult.Yes)
            {
                try
                {
                    File.Delete(yol); // C: və ya digər diskdə olan seçilmiş fayl silinir
                    FayllariYukle();
                    lblStatus.Text = $"Fayl silindi  |  Fayl sayı: {lstFayllar.Items.Count}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fayl silinmədi: " + ex.Message, "Xəta",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ---------- Köməkçi metodlar ----------
        private string SecilmisYol()
        {
            if (lstFayllar.SelectedItem == null || string.IsNullOrEmpty(cariQovluq))
                return null;
            return Path.Combine(cariQovluq, lstFayllar.SelectedItem.ToString());
        }

        private void StatusYenile()
        {
            lblStatus.Text = $"Hazırdır  |  Fayl sayı: {lstFayllar.Items.Count}";
        }
    }
}
