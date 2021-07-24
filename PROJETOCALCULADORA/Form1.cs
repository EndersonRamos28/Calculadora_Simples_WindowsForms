using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PROJETOCALCULADORA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int parcela1;
            int parcela2;
            string tipo_operacao;
            int resultado= -111111111;

            string algoritmo = txtOperacao.Text;

            string sinais = "+,-,*,/";

            int index = 0;
            foreach( char c in algoritmo)
            {
                foreach(char s in sinais)
                {
                    if (c == s){
                        //DEFINE OS 3 ELEMENTOS DA OPERACAO
                        //parcela1!
                        parcela1 = int.Parse(algoritmo.Substring(0,index));
                        //SINAL
                        tipo_operacao = s.ToString();
                        //PARCELA2
                        parcela2 = int.Parse(algoritmo.Substring(index + 1));
                        //ANALISE A OPERACAO QUE VAI SER REALIZADA
                        switch (tipo_operacao)
                        {
                            //ADICAO
                            case "+":
                                resultado = parcela1 + parcela2;
                                break;
                                //SUBTRACAO
                            case "-":
                                resultado = parcela1 - parcela2;
                                break;
                                //MULTIPLICACAO
                            case "*":
                                resultado = parcela1 * parcela2;
                                break;
                                //DIVISAO
                            case "/":
                                resultado = parcela1 / parcela2;
                                break;

                        }
                        break;
                            
                    }
                }
                if (resultado != -111111111)
                    break;
                index++;
            }
            if (resultado == -111111111)
                MessageBox.Show("Houve um erro, por favor tente novamente");
            //APRESENTAR RESULTADO FINAL
            else
            {
                MessageBox.Show(algoritmo + " = " + resultado.ToString(),"Resultado", MessageBoxButtons.OK);
            }

            txtOperacao.Text = "";
            txtOperacao.Focus();

            
        }

        private void txtOperacao_KeyDown(object sender, KeyEventArgs e)
        {
            //VERIFICA SE TEM TEXTO PRA CALCULAR
            if (txtOperacao.Text == "") return;

            //SE APERTAR ENTER EXECUTA O CALCULO
            if (e.KeyCode == Keys.Return)
                btnCalcular_Click(btnCalcular, EventArgs.Empty);

            else if (e.KeyCode == Keys.Escape)
            {
                txtOperacao.Text="";
                txtOperacao.Focus();
            }

        }
    }
}
