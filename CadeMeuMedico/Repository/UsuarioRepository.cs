using CadeMeuMedico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace CadeMeuMedico.Repository
{
    public class UsuarioRepository
    {
        public static bool AutenticarUsuario(string login, string senha)
        {
            var senhaCript = FormsAuthentication.HashPasswordForStoringInConfigFile(senha, "sha1");

            try
            {
                using (EntidadesCadeMeuMedicoBD db = new EntidadesCadeMeuMedicoBD())
                {
                    var QueryAutenticaUsuario = db.Usuario.Where(x => x.Login == login && x.Senha == senhaCript).SingleOrDefault();

                    if (QueryAutenticaUsuario == null)
                    {
                        return false;
                    }
                    else
                    {
                        //CookiesRepository.RegistraCookieAutenticacao(QueryAutenticaUsuario.IDUsuario);
                        return true;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        } 
    }
}