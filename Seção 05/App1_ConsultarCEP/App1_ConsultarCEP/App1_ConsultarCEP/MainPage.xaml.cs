using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App1_ConsultarCEP.Servico.Modelo;
using App1_ConsultarCEP.Servico;

namespace App1_ConsultarCEP
{
    
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }
        private void BuscarCEP(object sender, EventArgs args)
        {
            // TODO - Validações.
            string cep = CEP.Text.Trim();
            if (isValidCEP(cep)) {
                try
                {
                    Endereço end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {0},{1},{2},{3},{4}", end.localidade, end.uf, end.logradouro, end.bairro, end.cep);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O Endereço não foi encontrado para o CEP informado: " + cep, "OK");
                    }
                }
                catch(Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message,"OK");
                }
            }
            
        }
        private bool isValidCEP(string cep)
        {
            bool valido = true;
            
            
            if(cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP Inválido! O CEP deve conter 8 caracteres.", "OK");

                valido = false;
            }

            int NovoCEP = 0;
            
            if(!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("ERRO", "CEP Inválido! O CEP deve conter apenas números.", "OK");

                valido = false;
            }
            return valido;
        }
    }
}
