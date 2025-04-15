namespace ImpiccatoFunzionante
{
    public partial class Form1 : Form
    {
        string parolaCasuale = "";
        string parolaCriptata = "";
        string CercaParola(string filePath)
        {
            filePath = "ParoleImpiccato.txt";

            string[] parole = File.ReadAllLines(filePath);

            if (parole.Length == 0)
            {
                Console.WriteLine("Il file delle parole è vuoto.");
                return null; // Restituisce null se il file è vuoto
            }

            Random rand = new Random();
            return parole[rand.Next(0, parole.Length)];
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void LetteraQ_Click(object sender, EventArgs e)
        {
            Testo.Text += "Q";
        }

        private void LetteraE_Click(object sender, EventArgs e)
        {
            Testo.Text += "E";
        }

        private void LetteraR_Click(object sender, EventArgs e)
        {
            Testo.Text += "R";
        }

        private void LetteraT_Click(object sender, EventArgs e)
        {
            Testo.Text += "T";
        }

        private void LetteraU_Click(object sender, EventArgs e)
        {
            Testo.Text += "U";
        }

        private void LetteraI_Click(object sender, EventArgs e)
        {
            Testo.Text += "I";
        }

        private void LetteraO_Click(object sender, EventArgs e)
        {
            Testo.Text += "O";
        }

        private void LetteraP_Click(object sender, EventArgs e)
        {
            Testo.Text += "P";
        }

        private void LetteraL_Click(object sender, EventArgs e)
        {
            Testo.Text += "L";
        }

        private void LetteraM_Click(object sender, EventArgs e)
        {
            Testo.Text += "M";
        }

        private void LetteraA_Click(object sender, EventArgs e)
        {
            Testo.Text += "A";
        }

        private void LetteraS_Click(object sender, EventArgs e)
        {
            Testo.Text += "S";
        }

        private void LetteraD_Click(object sender, EventArgs e)
        {
            Testo.Text += "D";
        }

        private void LetteraF_Click(object sender, EventArgs e)
        {
            Testo.Text += "F";
        }

        private void LetteraG_Click(object sender, EventArgs e)
        {
            Testo.Text += "G";
        }

        private void LetteraH_Click(object sender, EventArgs e)
        {
            Testo.Text += "H";
        }

        private void LetteraJ_Click(object sender, EventArgs e)
        {
            Testo.Text += "J";
        }

        private void LetteraK_Click(object sender, EventArgs e)
        {
            Testo.Text += "K";
        }

        private void LetteraZ_Click(object sender, EventArgs e)
        {
            Testo.Text += "Z";
        }

        private void LetteraX_Click(object sender, EventArgs e)
        {
            Testo.Text += "X";
        }

        private void LetteraC_Click(object sender, EventArgs e)
        {
            Testo.Text += "C";
        }

        private void LetteraV_Click(object sender, EventArgs e)
        {
            Testo.Text += "V";
        }

        private void LetteraB_Click(object sender, EventArgs e)
        {
            Testo.Text += "B";
        }

        private void LetteraN_Click(object sender, EventArgs e)
        {
            Testo.Text += "N";
        }

        private void Invia_Click(object sender, EventArgs e)
        {
            bool letteraIndovinata = false;
            string lettereInserite = Testo.Text;
            char[] parolaCriptataArray = parolaCriptata.ToCharArray();

            if (int.Parse(ContaTentativi.Text) > 0)
            {
                if (lettereInserite.Length == 1)
                {
                    char lettera = lettereInserite[0];

                    if (LettereProvate1.Text.Contains(lettera) == false)
                    {
                        LettereProvate1.Text += lettera + ", ";
                    }

                    if (parolaCasuale.Length == parolaCriptataArray.Length)
                    {
                        int j = 0;
                        while (j < parolaCasuale.Length)
                        {
                            if (parolaCasuale[j] == lettera && parolaCriptataArray[j] == '_')
                            {
                                parolaCriptataArray[j] = lettera;
                                letteraIndovinata = true;
                            }
                            j++;
                        }

                    }
                }

                if (!letteraIndovinata)
                {
                    Random random = new Random();
                    int PunteggioCasuale = random.Next(1, 6);

                    if (int.Parse(ContaPunteggio.Text) <= 0)
                    {
                        PunteggioCasuale = 0;
                        ContaPunteggio.Text = "0";
                    }

                    ContaTentativi.Text = (int.Parse(ContaTentativi.Text) - 1).ToString();
                    ContaPunteggio.Text = (int.Parse(ContaPunteggio.Text) - PunteggioCasuale).ToString();
                }

                if (letteraIndovinata)
                {
                    Random random = new Random();
                    int PunteggioCasuale = random.Next(1, 6);
                    ContaMonete.Text = (int.Parse(ContaMonete.Text) + 5).ToString();
                    ContaPunteggio.Text = (int.Parse(ContaPunteggio.Text) + PunteggioCasuale).ToString();
                }
            }

            parolaCriptata = new string(parolaCriptataArray);

            if (parolaCriptata == parolaCasuale)
            {
                Random random = new Random();
                int PunteggioCasuale = random.Next(8, 16);
                ContaParoleGiuste.Text = (int.Parse(ContaParoleGiuste.Text) + 1).ToString();
                ContaMonete.Text = (int.Parse(ContaMonete.Text) + 10).ToString();
                ContaPunteggio.Text = (int.Parse(ContaPunteggio.Text) + PunteggioCasuale).ToString();
            }

            Testo.Text = "";
            ParolaGenerata.Text = parolaCriptata;
        }


        void GeneraLettera_Click(object sender, EventArgs e)
        {
            string filePath = "ParoleImpiccato.txt";

            parolaCasuale = CercaParola(filePath);

            if (parolaCasuale == null)
            {
                return; // Se non viene trovata una parola (file vuoto), esci dal programma
            }

            parolaCriptata = new string('_', parolaCasuale.Length);

            ParolaGenerata.Text = parolaCriptata;
        }


        private void LetteraJolly_Click(object sender, EventArgs e)
        {
            if (int.Parse(ContaMonete.Text) >= 25)
            {
                ContaMonete.Text = (int.Parse(ContaMonete.Text) - 25).ToString();

                Random random = new Random();
                int posizioneJolly = random.Next(0, parolaCasuale.Length);

                while (parolaCriptata[posizioneJolly] != '_')
                {
                    posizioneJolly = random.Next(0, parolaCasuale.Length);
                }

                parolaCriptata = parolaCriptata.Remove(posizioneJolly, 1).Insert(posizioneJolly, parolaCasuale[posizioneJolly].ToString());

                ParolaGenerata.Text = parolaCriptata;
                LettereProvate1.Text = "";
            }
        }


    }
}

