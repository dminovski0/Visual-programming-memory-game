using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// 	УНИВЕРЗИТЕТ „ГОЦЕ ДЕЛЧЕВ” – ШТИП

//ФАКУЛТЕТ ЗА ИНФОРМАТИКА

//СЕМИНАРСКА РАБОТА

//по предметот
//Визуелно програмирање


//Меморија


//Предметен наставник:	   Кандидат(и):


//Доц. д-р Сашо Коцески	   Даниел Миновски 10706
//                         daniel.10706@student.ugd.edu.mk 


//Штип
//Јануари, 2014
namespace WindowsFormsApplication1
{
    public partial class Меморија : Form
    {
        int vreme;//vreme za tajmerot
        Button prvokliknato=null;
        Button vtorokliknato=null;
        private bool button37ekliknato = false;//Uslov za kliknato kopce start

        public Меморија()
        {            
            InitializeComponent();
        }

        private void Меморија_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button37_Click(object sender, EventArgs e)
        {
            button37ekliknato = true;//Se postavuva na tocno
            Random broevi = new Random();//Proizvolen broj
            List<string> sliki = new List<string>() {"1","1","2","2","3","3","4","4",
            "5","5","6","6","7","7","8","8","9","9","10","10","11","11","12","12",
            "13","13","14","14","15","15","16","16","17","17","18","18"};
            label2.Text = "";//Tekstot se brise dokolku veke ima tekst
            timer1.Start();//Start na tajmerot
            vreme = 150;//Se dodava vrednost
            Muzika.URL = @"117-phrase-of-aya.mp3";
            Muzika.settings.setMode("loop", true);//Beskonecen ciklus
            //Se postavuva nova kontrola Windows Media player
            //Muzickiot fajl e staven vo bin debug folderot na proektot            
            Button[] kopce = new Button[] { button1, button2, button3, button4,
            button5, button6, button7, button8, button9, button10, button11,
            button12, button13, button14, button15, button16, button17, button18,
            button19, button20, button21, button22, button23, button24, button25,
            button26, button27, button28, button29, button30, button31, button32,
            button33, button34, button35, button36};//Niza od kopcinja

            foreach (Button kontrola in kopce)
            {
                Button TextButton = kontrola as Button;
                if (TextButton != null)
                {
                    TextButton.BackColor = Color.White;
                    TextButton.ForeColor = Color.Transparent;
                    int randomNumber = broevi.Next(sliki.Count);
                    TextButton.Text = sliki[randomNumber];                    
                    sliki.RemoveAt(randomNumber);
                    //Se dodavaat broevite od listata na kopcinjata i se 
                    //otstranuvaat upotrebenite broevi
                }
            }
        }
        private void kopce_Click(object sender, EventArgs args)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (vreme > 0)//Uslov za tajmerot, ako vremeto e pogolemo od 0
                vreme = vreme - 1;//tajmerot go namaluva na interval od 1000 ms
            label1.Text = vreme + "";//Vremeto se pokazuva ovde
            if (//Uslov za uspesno zavrsena igra, ako vremeto e pogolemo od 0 i
                //ako bojata na pozadinata na site kopcinja e zelena
                vreme > 0 && button1.BackColor == Color.Green && button2.BackColor == Color.Green &&
                button3.BackColor == Color.Green && button4.BackColor == Color.Green &&
                button5.BackColor == Color.Green && button6.BackColor == Color.Green &&
                button7.BackColor == Color.Green && button8.BackColor == Color.Green &&
                button9.BackColor == Color.Green && button10.BackColor == Color.Green &&
                button11.BackColor == Color.Green && button12.BackColor == Color.Green &&
                button13.BackColor == Color.Green && button14.BackColor == Color.Green &&
                button15.BackColor == Color.Green && button16.BackColor == Color.Green &&
                button17.BackColor == Color.Green && button18.BackColor == Color.Green &&
                button19.BackColor == Color.Green && button20.BackColor == Color.Green &&
                button21.BackColor == Color.Green && button22.BackColor == Color.Green &&
                button23.BackColor == Color.Green && button24.BackColor == Color.Green &&
                button25.BackColor == Color.Green && button26.BackColor == Color.Green &&
                button27.BackColor == Color.Green && button28.BackColor == Color.Green &&
                button29.BackColor == Color.Green && button30.BackColor == Color.Green &&
                button31.BackColor == Color.Green && button32.BackColor == Color.Green &&
                button33.BackColor == Color.Green && button34.BackColor == Color.Green &&
                button35.BackColor == Color.Green && button36.BackColor == Color.Green)
            {
                label2.Text = "Успешно завршена игра";//Se pokazuva tekst za 
                //uspesno zavrsena igra
                timer1.Stop();
                Muzika.close();
            }
            if (//Uslov za nezavrsena igra, ako vremeto dojde do 0 i nema tekst
                //za uspesno zavrsena igra
                vreme == 0 && label2.Text != "Успешно завршена игра")
            {
                label2.Text = "Повеќе среќа следниот пат";
                Muzika.close();
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Button kliknatokopce = sender as Button;
            if(button37ekliknato==true)//Ako kopceto start e kliknato
            {
                if(prvokliknato!=null && vtorokliknato!=null)
                {//Ako prvoto i vtoroto kopce se veke otvoreni, na klik od
                    //tretoto se zatvaraat i toa stanuva novo prvo otvoreno kopce
                    prvokliknato.ForeColor = prvokliknato.BackColor;
                    prvokliknato = null;
                    vtorokliknato.ForeColor = vtorokliknato.BackColor;
                    vtorokliknato = null;
                }
                if (kliknatokopce != null)
                {
                   // Ako kliknatoto kopce ima boja na tekst crna, igracot
                   // kliknal na kopce koe sto e veke otkrieno, klikot se ignorira
                    if (kliknatokopce.ForeColor == Color.Black)
                        return;
                    else
                        if (prvokliknato == null)
                        {
                            //Kopceto koe prvo e klinato i ostanuva otvoreno
                            prvokliknato = kliknatokopce;
                            prvokliknato.ForeColor = Color.Black;
                            return;
                        }
                    //Kopceto koe vtoro e kliknato i ostanuva otvoreno
                    vtorokliknato = kliknatokopce;
                    vtorokliknato.ForeColor = Color.Black;
                    
                    if (prvokliknato.Text == vtorokliknato.Text)
                    {//Uslov ako se otvorat kopcinja so ist broj, pozadinata 
                        //stanuva zelena i dobivaat vrednost null
                        prvokliknato.BackColor = Color.Green;
                        vtorokliknato.BackColor = Color.Green;
                        //Promena na bojata na kopcinjata so ist broj vo zelena
                        prvokliknato = null;
                        vtorokliknato = null;
                        
                        return;
                    }

                   
                }
                else
                    return ;
                
            }
        }
    }
}
