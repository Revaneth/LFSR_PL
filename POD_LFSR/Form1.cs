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
using System.Diagnostics;
using System.Threading;
using System.Dynamic;


namespace POD_LFSR
{
    public partial class Form1 : Form
    {
        lfsr one;
       

        public Form1()
        {
            InitializeComponent();

            one = new lfsr();
            takietam();
            String rjstr = "";
            foreach (byte i in one.rejestr) { rjstr += i; }
            textBox2.Text = rjstr;

            MTextBox1.Text = "500";

   

            }



        public void takietam()
        {
            if (one.odczepy[((one.rejestr.Count()) - 3)].Count() != 2)
            {
               // NUD2.Value = 1;
                NUD2.BackColor = System.Drawing.Color.Red;
                NUD2.Maximum = 1;
            }
            else { NUD2.BackColor = System.Drawing.Color.Lime;
            NUD2.Maximum = 2;
            }
                int REJ = one.rejestr.Count();
             one.tablodczepow = new int[one.odczepy[((REJ) - 3)][((int)NUD2.Value-1)].Count()];
               one.tablodczepow = one.odczepy[((REJ) - 3)][((int)NUD2.Value - 1)];
            

            String T3=" ";

            foreach (byte B in one.tablodczepow){
                T3 += B + ", ";
            }
            textBox3.Text = T3;
            
        }

     
        

        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
                      
            save(textBox1.Text);
            saveBIN(one.wynik);
        
        }
        private void save(string s)
        {


            SaveFileDialog savefiledialog1 = new SaveFileDialog();
            savefiledialog1.Filter = "Text files|*.txt";
            savefiledialog1.Title = " Zapisz wynik ";
            //  savefiledialog1.AddExtension = true;


          //  savefiledialog1.CreatePrompt = true;
            savefiledialog1.OverwritePrompt = true;

            if (savefiledialog1.ShowDialog() == DialogResult.OK)
            {

                try
                {

                    // using (StreamWriter sw = new StreamWriter(savefiledialog1.FileName)){



                    //    sw.Write(s);

                    File.WriteAllText(savefiledialog1.FileName, s);

                    //  }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Nie moge zapisać pliku! \n" + ex.Message + ex.StackTrace);
                }
            }//if



            savefiledialog1.Dispose();





        }

        private void saveBIN(byte [] b) {



            SaveFileDialog savefiledialog1 = new SaveFileDialog();
            savefiledialog1.Filter = "Binary files|*.bin";
            savefiledialog1.Title = " Zapisz wynik ";
            //  savefiledialog1.AddExtension = true;


            //  savefiledialog1.CreatePrompt = true;
            savefiledialog1.OverwritePrompt = true;

            if (savefiledialog1.ShowDialog() == DialogResult.OK)
            {

                try
                {

                    // using (StreamWriter sw = new StreamWriter(savefiledialog1.FileName)){



                    //    sw.Write(s);
                    File.WriteAllBytes(savefiledialog1.FileName, b);
                //    File.WriteAllText(savefiledialog1.FileName, s);

                    //  }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Nie moge zapisać pliku! \n" + ex.Message + ex.StackTrace);
                }
            }//if



            savefiledialog1.Dispose();

        
        
        
        
        }




        public void Threadstart() { one.magic(((int)(NUD2.Value) - 1)); }
     

        private void Start_Click(object sender, EventArgs e)
        {


            one.wynik = new byte[Convert.ToInt32(MTextBox1.Text)];
            takietam();
            

            Thread thread = new Thread(
               new ThreadStart(this.Threadstart));
        
            thread.Start();
     


            String Wynik = "";
            for (int i = 0; i < one.wynik.Count(); i++)
            {
               
                Wynik += one.wynik[i];
                textBox1.Text= Wynik;
                

            }

            String rjstr = "";
            foreach (byte i in one.rejestr) { rjstr += i; }
            textBox2.Text = rjstr;

   
           }

        private void button1_Click(object sender, EventArgs e)
        {
            
            one.rejestRND((int) UDnumeric.Value);
            takietam();
            String rjstr = "";
            foreach (byte i in one.rejestr) { rjstr += i; }
            textBox2.Text = rjstr;

            
        }

        private void NUD2_ValueChanged(object sender, EventArgs e)
        {
            takietam();
        }

        
    
             
    }
}
