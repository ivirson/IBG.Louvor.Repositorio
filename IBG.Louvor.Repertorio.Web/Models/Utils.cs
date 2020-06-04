using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IBG.Louvor.Repertorio.Web.Models
{
    public class Utils
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public static void SalvaLog(string message, string stackTrace, int usuarioId)
        {
            var text = string.Concat("Usuario: ", usuarioId, " | Error Message: ", message, " | Stack Trace: ", stackTrace, "\r\n");
            log.Info(text);
        }
    }
}