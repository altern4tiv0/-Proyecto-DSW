using PrjEcommersProyect.Models;

namespace PrjEcommersProyect.DAO
{
    public class UsuarioDAO
    {
        private string cad_cn = "";

        public UsuarioDAO(IConfiguration config) 
        {
            cad_cn = config.GetConnectionString("cn1");
        }

        public string Validar_Usuario(Usuario obj)
        {
            int rpta = Convert.ToInt32(
                SqlHelper.ExecuteScalar(cad_cn, "pa_encontrar_usuario",
                                        obj.LoginUsu, obj.ClaveUsu)
                );

            if (rpta == 1)
                return "Bienvenido al Sistema: " +obj.LoginUsu;
            else
                return "Error, Login y/o clave incorrecta";
        }

        public string GrabarUsuario(Usuario obj)
        {
            try 
            {
                SqlHelper.ExecuteNonQuery(cad_cn, "InsertarUsuario",
                                obj.LoginUsu, obj.ClaveUsu);

                return $"El Usuario: {obj.LoginUsu}" +
                    "fue Registrado correctamente";
            }
            catch (Exception ex) 
            {
                return ex.Message;
            }
        }
    }
}
