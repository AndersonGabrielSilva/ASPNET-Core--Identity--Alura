﻿using CasaDoCodigo.Areas.Identity.Data;
using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace CasaDoCodigo
{
    //TAREFA 05: INJETAR UserManager PARA OBTER clienteId
    public class HttpHelper : IHttpHelper
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly UserManager<AppIdentityUser> userManager;

        public IConfiguration Configuration { get; }

        public HttpHelper(IHttpContextAccessor contextAccessor, IConfiguration configuration, UserManager<AppIdentityUser> userManager)
        {
            this.contextAccessor = contextAccessor;
            this.Configuration = configuration;
            this.userManager = userManager;
        }

        public int? GetPedidoId()
        {
            string clienteId = GetClienteId();
            return contextAccessor.HttpContext.Session.GetInt32($"pedidoId_{clienteId}");
        }

        public string GetClienteId()
        {
            //Claims Principal é o usuario logado no momento;
            var claimsPrincipal = contextAccessor.HttpContext.User;

            //Para selecionar qualquer propriedade do Usuario é necessario informar o ClaimsPrincipal.
            //Que vem do HttpContext.
            var clienteId = userManager.GetUserId(claimsPrincipal);
            return clienteId;
        }

        public void SetPedidoId(int pedidoId)
        {
            contextAccessor.HttpContext.Session.SetInt32($"pedidoId_{GetClienteId()}", pedidoId);
        }

        public void ResetPedidoId()
        {
            contextAccessor.HttpContext.Session.Remove($"pedidoId_{GetClienteId()}");
        }
    }
}
