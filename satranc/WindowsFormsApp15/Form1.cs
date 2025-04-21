using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp15
{
    public partial class Form1 : Form
    {
        Button[,] Tahta = new Button[8, 8];
        bool ProgramAcilisi = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Yerlestir();
        }

        private void Yerlestir()
        {
            for (int ii = 0; ii < 8; ii++)
            {
                for (int jj = 0; jj < 8; jj++)
                {
                    if (ProgramAcilisi)
                    {
                        Tahta[ii, jj] = new Button();
                        this.Controls.Add(Tahta[ii, jj]);
                    }

                    Tahta[ii, jj].Width = 80;
                    Tahta[ii, jj].Height = 80;
                    Tahta[ii, jj].Left = (jj * 80);
                    Tahta[ii, jj].Top = (ii * 80);

                    if (ii % 2 == 1)        // Satırlar: 1, 3, 5, 7.
                    {
                        if (jj % 2 == 1)    // Tek sütunlar.
                        {
                            Tahta[ii, jj].BackColor = Color.White;
                        }
                        else                // Çift sütunlar.
                        {
                            Tahta[ii, jj].BackColor = Color.DarkGray;
                        }
                    }
                    else                    // Satırlar: 0, 2, 4, 6.
                    {
                        if (jj % 2 == 1)    // Tek sütunlar.
                        {
                            Tahta[ii, jj].BackColor = Color.DarkGray;
                        }
                        else                // Çift sütunlar.
                        {
                            Tahta[ii, jj].BackColor = Color.White;
                        }
                    }

                    Tahta[ii, jj].BackgroundImage = System.Drawing.Image.FromFile(@"Bos.png");
                    Tahta[ii, jj].BackgroundImageLayout = ImageLayout.Stretch;

                    Point koordinat = new Point();
                    koordinat.X = ii;
                    koordinat.Y = jj;
                    Tahta[ii, jj].Tag = (Object)koordinat;

                    // Demo için: Fil (Beyaz Sağ) tıklanabilir olsun.
                    if (ii == 7 && jj == 5)
                    {
                        Tahta[ii, jj].Click += filHareketGoster_Click;
                    }
                }
            }

            if (ProgramAcilisi)
            {
                ProgramAcilisi = false;
            }

            // Piyonlar:
            for (int jj = 0; jj < 8; jj++)
            {
                Tahta[1, jj].BackgroundImage = System.Drawing.Image.FromFile(@"Piyon_Siyah.png");
            }
            for (int jj = 0; jj < 8; jj++)
            {
                Tahta[6, jj].BackgroundImage = System.Drawing.Image.FromFile(@"Piyon_Beyaz.png");
            }
            // Kaleler:
            Tahta[0, 0].BackgroundImage = System.Drawing.Image.FromFile(@"Kale_Siyah.png");
            Tahta[0, 7].BackgroundImage = System.Drawing.Image.FromFile(@"Kale_Siyah.png");
            Tahta[7, 0].BackgroundImage = System.Drawing.Image.FromFile(@"Kale_Beyaz.png");
            Tahta[7, 7].BackgroundImage = System.Drawing.Image.FromFile(@"Kale_Beyaz.png");
            // Atlar:
            Tahta[0, 1].BackgroundImage = System.Drawing.Image.FromFile(@"At_Siyah.png");
            Tahta[0, 6].BackgroundImage = System.Drawing.Image.FromFile(@"At_Siyah.png");
            Tahta[7, 1].BackgroundImage = System.Drawing.Image.FromFile(@"At_Beyaz.png");
            Tahta[7, 6].BackgroundImage = System.Drawing.Image.FromFile(@"At_Beyaz.png");
            // Filler:
            Tahta[0, 2].BackgroundImage = System.Drawing.Image.FromFile(@"Fil_Siyah.png");
            Tahta[0, 5].BackgroundImage = System.Drawing.Image.FromFile(@"Fil_Siyah.png");
            Tahta[7, 2].BackgroundImage = System.Drawing.Image.FromFile(@"Fil_Beyaz.png");
            Tahta[7, 5].BackgroundImage = System.Drawing.Image.FromFile(@"Fil_Beyaz.png");
            // Vezir ve Şah:
            Tahta[0, 3].BackgroundImage = System.Drawing.Image.FromFile(@"Vezir_Siyah.png");
            Tahta[0, 4].BackgroundImage = System.Drawing.Image.FromFile(@"Sah_Siyah.png");
            Tahta[7, 3].BackgroundImage = System.Drawing.Image.FromFile(@"Vezir_Beyaz.png");
            Tahta[7, 4].BackgroundImage = System.Drawing.Image.FromFile(@"Sah_Beyaz.png");
        }

        private void sifirla_Click(object sender, EventArgs e)
        {
            Yerlestir();
        }

        private void filHareketGoster()
        {
            // Kuzey batı çapraz.
            Tahta[7, 5].BackColor = Color.Yellow;
            Tahta[6, 4].BackColor = Color.Yellow;
            Tahta[5, 3].BackColor = Color.Yellow;
            Tahta[4, 2].BackColor = Color.Yellow;
            Tahta[3, 1].BackColor = Color.Yellow;
            Tahta[2, 0].BackColor = Color.Yellow;
            // Kuzey doğu çapraz.
            Tahta[6, 6].BackColor = Color.Yellow;
            Tahta[5, 7].BackColor = Color.Yellow;
        }

        private void filHareketGoster_Click(object sender, EventArgs e)
        {
            filHareketGoster();
        }
    }
}