using System;
using RestSharp;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ControleClientes.API.Core.Entities;
using ControleClientes.API.Application.Models.ViewModels;

namespace ControleClientes.API.Controllers
{
    
    public class BaseController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public  CepViewModel BuscarCep(long cep)
        {
            if (cep <= 0)
            {
                return null;
            }
            if (cep.ToString().Length < 8)
            {
                return null;
            }

            CepViewModel result = new CepViewModel();
            
            var client = new RestClient("https://brasilapi.com.br/api/cep/v1/");
            var request = new RestRequest(cep.ToString(), Method.GET);
            var response = client.Execute<CepViewModel>(request);

            result = response.Data;
            return result;
        }
    }

}


