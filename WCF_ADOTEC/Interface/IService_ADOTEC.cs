using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WCF_ADOTEC.Interface
{
    [ServiceContract]
    public interface IService_ADOTEC
    {
        [OperationContract]
        string Metodo_Prueba(string value);

        [OperationContract]
        string Validar_Usuario(string Usuario, string Contrasena);

        [OperationContract]
        string Recuperar_Contrasena(string Correo);

        [OperationContract]
        void GeneraExcel(string NombreArchivo);

        [OperationContract]
        void RespuestasTest(string[] Respuestas);
    }
}
