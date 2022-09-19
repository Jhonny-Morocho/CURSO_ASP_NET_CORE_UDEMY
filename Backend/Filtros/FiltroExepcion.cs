﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Filtros
{
    public class FiltroExepcion:ExceptionFilterAttribute
    {
        private readonly ILogger<FiltroExepcion> logger;
        public FiltroExepcion(ILogger<FiltroExepcion> logger)
        {
            this.logger = logger;
        }
        public override void OnException(ExceptionContext context)
        {
            logger.LogError(context.Exception,context.Exception.Message);
            base.OnException(context);
        }
    }
}
