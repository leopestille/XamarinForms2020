using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App1_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace App1_ConsultarCEP.Servico
{
    public class ViaCEPServico
    {
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static  Endereço BuscarEnderecoViaCEP(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient webClient = new WebClient();
            string Conteudo = webClient.DownloadString(NovoEnderecoURL);

            Endereço end =  JsonConvert.DeserializeObject<Endereço>(Conteudo);

            if (end.cep == null) return null;


            return end;

        }
    }
}
