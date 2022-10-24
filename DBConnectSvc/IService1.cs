using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DBConnectSvc
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        IEnumerable<ToDoListDataContract> Consultar();

        [OperationContract]
        void Eliminar(int id);

        [OperationContract]
        void Guardar(ToDoListDataContract modelo);

        [OperationContract]
        void Modificar(ToDoListDataContract modelo);
    }

    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    [DataContract]
    public class ToDoListDataContract
    {

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Titulo { get; set; } 
        [DataMember]
        public bool EstadoTarea { get; set; } 
        [DataMember]
        public DateTime FechaCreacion { get; set; } 
        [DataMember]
        public DateTime FechaFin { get; set; } 
        [DataMember]
        public string Notas { get; set; }
        [DataMember]
        public int Prioridad { get; set; }
    }
}
