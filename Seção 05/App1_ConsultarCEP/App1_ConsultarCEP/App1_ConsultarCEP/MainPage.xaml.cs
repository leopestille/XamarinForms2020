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
            Endereço end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
            RESULTADO.Text = string.Format("Endereço: {0},{1},{2},{3},{4}", end.localidade, end.uf, end.logradouro, end.bairro, end.cep);



        }
    }
}
