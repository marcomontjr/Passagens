﻿
using Passagens;
using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel.Description;

namespace Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ClienteService));
            Uri endereco = new Uri("http://localhost:8080/clientes"); 

            host.AddServiceEndpoint(typeof(IClienteService), new BasicHttpBinding(), endereco);

            try
            {
                host.Open();
                ExibirInformacoesServico(host);
                Console.ReadLine();
                host.Close();
            }
            catch (Exception ex)
            {
                host.Abort();
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

        }
        public static void ExibirInformacoesServico(ServiceHost sh)
        {
            Console.WriteLine("{0} online", sh.Description.ServiceType);
            foreach (ServiceEndpoint se in sh.Description.Endpoints)
            {
                Console.WriteLine(se.Address);
            }
        }
    }
}
