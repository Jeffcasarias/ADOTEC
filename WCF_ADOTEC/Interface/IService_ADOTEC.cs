using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Data;

namespace WCF_ADOTEC.Interface
{
    [ServiceContract]
    public interface IService_ADOTEC
    {
        [OperationContract]
        string Metodo_Prueba(string value);

        [OperationContract]
        DataTable Validar_Usuario(string Usuario, string Contrasena);

        [OperationContract]
        string Recuperar_Contrasena(string Correo);

        [OperationContract]
        void RespuestasTest(string[] Respuestas);

        [OperationContract]
        DataTable Filtrar_Estudiante(int iIdEstudiante);

        [OperationContract]
        DataTable Genera_Reporte();

        [OperationContract]
        void InsertarPersona(int IdPersona, string Nombre, string Ap1, string Ap2, DateTime FechaNacimiento, char Rol);
    }
}
