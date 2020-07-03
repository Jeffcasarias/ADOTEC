using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Net.Mail;
using System.Net;
using DAL_ADOTEC.ConexionBD;

namespace BLL_ADOTEC.Login
{
    public class cls_Login_BLL
    {
        cls_VariablesConexBD_DAL Obj_Variables = new cls_VariablesConexBD_DAL();
        cls_ConexBD_DAL Obj_Conexion = new cls_ConexBD_DAL();


        public string ValidarUsuario(string User, string Password)
        {
            Obj_Conexion.CrearParametros(ref Obj_Variables);
            Obj_Variables.DT_Parametros.Rows.Add("@IDUSUARIO", 4, User.ToString().Trim());
            Obj_Variables.DT_Parametros.Rows.Add("@CONTRASENA", 4, Password.ToString().Trim());
            Obj_Variables.sTableName = "Usuarios";
            Obj_Variables.sSP_Name = "dbo.SP_Login";
            Obj_Conexion.Execute_DataAdapter(ref Obj_Variables);
            DataTable dt = new DataTable();
            dt = Obj_Variables.Obj_DSet.Tables[0];

            if (dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return "Login exitoso";
            }

        }

        public string RecuperarContrasena(string Correo)
        {
            string Contrasena = "";
            Obj_Conexion.CrearParametros(ref Obj_Variables);
            Obj_Variables.DT_Parametros.Rows.Add("@CORREO", 4, Correo.ToString().Trim());
            Obj_Variables.sTableName = "Recuperar Contrasena";
            Obj_Variables.sSP_Name = "dbo.SP_RecuperarContrasena";
            Obj_Conexion.Execute_DataAdapter(ref Obj_Variables);
            DataTable dt = new DataTable();
            dt = Obj_Variables.Obj_DSet.Tables[0];


            if (dt.Rows.Count > 0)
            {

                Contrasena = dt.Rows[0]["CONTRASENA"].ToString().Trim();

                MailMessage msg = new MailMessage();
                msg.To.Add(Correo);
                msg.Subject = "Recuperación de contraseña";
                msg.Body = "Su contraseña es: " + Contrasena;
                msg.From = new MailAddress("requerimientosrecuperacion@gmail.com");

                SmtpClient ClienteSmtp = new SmtpClient();
                ClienteSmtp.Credentials = new NetworkCredential("requerimientosrecuperacion@gmail.com", "Recuperacion123");
                ClienteSmtp.Port = 587;
                ClienteSmtp.EnableSsl = true;
                ClienteSmtp.Host = "smtp.gmail.com";

                try
                {
                    ClienteSmtp.Send(msg);
                    return "El correo fue enviado exitosamente";
                }
                catch (Exception e)
                {

                    return e.Message;
                }
            }

            else
            {
                return "El correo brindado no está vinculado a su cuenta de usuario, por favor verifique e intente nuevamente";
            }
        }
    }
}
