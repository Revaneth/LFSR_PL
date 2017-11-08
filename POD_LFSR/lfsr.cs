using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace POD_LFSR
{
    class lfsr
    {
       // List<byte> rejestr;
      public  byte[] rejestr;
      public  int [][][] odczepy ;
      public  byte[] wynik;
      public int[] tablodczepow;

      public int tiny = 0;
//.............................

        public lfsr() : this(3,500) { }
        public lfsr(int dlugosc,int ciag)
        {

            if (dlugosc < 3) { dlugosc = 3; };


            //this.rejestr = new List<byte>(dlugosc);
            this.rejestr = new byte[dlugosc];

  /*!!*/       this.odczepy = new int[16][][]; //6 wpisane 'n +3' = all
            
            this.wynik = new byte[ciag];
            

            initial(dlugosc);


    //        magic(0); //!!

        }
//.............................   
     
        public void rejestRND (int dl){

            this.rejestr = new byte[dl];

            Random rnd = new Random();

            int Z=0, J = 0;


            for (int i = 0; i < dl; i++)
            {
                // rejestr.Add((byte)rnd.Next(2));
                rejestr[i] = (byte)rnd.Next(2);

                if (rejestr[i] == 1)
                { J++; }
                else { Z++; }

             //   Debug.WriteLine("rej:" + i + " " + rejestr[i]);

            }

            if (J == 0)
            {rejestr[rnd.Next(rejestr.Count())] = 1;}
            if (Z == 0)
            { rejestr[rnd.Next(rejestr.Count())] = 0; }

        }


        private void initial(int dl) {

            rejestRND(dl);

//------------------------odczepy--------------------------------------


            //0= 3 aka n - 3 = i
                odczepy[0] = new int[][] 
                {
                    new int[] {0,1,2}
                };     
            //--------4-----------
                odczepy[1] = new int[][] 
                {
                    new int[] {0,1,3}
                };
                //--------5-----------
                odczepy[2] = new int[][] 
                {
                    new int[] {0,1,4}
                };
                //--------6-----------
                odczepy[3] = new int[][] 
                {
                    new int[] {0,2,5}
                };
                //--------7-----------
                odczepy[4] = new int[][] 
                {
                    new int[] {0,1,6}
                }; 
              //--------8-----------
                odczepy[5] = new int[][] 
                {
                    new int[] {0,1,7},
                    new int[] {0,3,7}
                };

              //--------9-----------
                odczepy[6] = new int[][] 
                {
                    new int[] {0,2,3,4,8}
                };
  //--------10-----------
                odczepy[7] = new int[][] 
                {
                    new int[] {0,4,9}
                 
                };
  //--------11-----------
                odczepy[8] = new int[][] 
                {
                    new int[] {0,3,10}
                    
                };

	  //--------12-----------
                odczepy[9]= new int[][] 
                {
                    new int[] {0,2,11}
                };
				
	  //--------13-----------
                odczepy[10] =new int[][] 
                {
                    new int[] {0,1,4,6,12}
                };			
				
	  //--------14-----------
                odczepy[11] = new int[][] 
                {
                    new int[] {0,1,3,4,13}
                };			
				
				
	  //--------15-----------
                odczepy[12] =new int[][] 
                {
                    new int[] {0,1,3,5,14}
                };			
				
	  //--------16-----------
                odczepy[13] =new int[][] 
                {
                    new int[] {0,1,15}
                };			
				











        }
//-------------------------------------------------------------------------------
        public void magic(int va) //combobox va
        {
            tiny = 0;
            //    wynik = rejestr;

            int REJ = rejestr.Count();

          

       //     tablodczepow = new int[odczepy[((REJ) - 3)][va].Count()];

       //     tablodczepow = odczepy[((REJ) - 3)][va];

     //       for (int i = 0; i < tablodczepow.Count(); i++)
     //       {
    // /           Debug.Write(tablodczepow[i] + " , ");
    ///        }


            byte zmienna = 0;


            int intiny = wynik.Count() / 100;
            //20k,100
            for (int i = 0; i < wynik.Count(); i++)
            {
                if (i > intiny) { tiny += intiny;
                intiny += intiny;
                }
                  
                zmienna = bitty(this.rejestr, this.tablodczepow);
                    
                wynik[i] = zmienna;//(byte)rejestr[REJ-1];
                
                rejestr = przesun(rejestr, zmienna);


            }

        }


        private byte bitty(byte[] REJESTR, int [] ODCZEPY) 
        {
           int iloscOdczepow = ODCZEPY.Count();

            byte nowy = REJESTR[0];

            for (int i = 1; i < iloscOdczepow; i++)
            {
                nowy ^= REJESTR[ODCZEPY[i]];
            }



            return nowy;
        }


        private
      //  public
            byte[] przesun(byte[] MAIN, byte wstaw)
        {

            int dlugosci =MAIN.Count();
            byte[] POMOC = new byte[dlugosci];

            for (int i = 0; i < dlugosci; i++)
            {
                POMOC[i] = MAIN[i];
            }



            for (int i = 0; i < dlugosci; i++) 
            {
                if (i == (dlugosci - 1))
                {
                    MAIN[0] = wstaw;
                }
                else
                {
                    MAIN[i+1] = POMOC[i];
                }

            }

            
                return MAIN;
        }








    }
}
