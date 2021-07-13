
using System.Runtime.Serialization;
namespace WcfTelcoServices.Utilitarios
{
    [DataContract()]
    public class RecordResponseObject<T>
    {
        private T _data;
        private bool _success = true; 
        private string _message;

        [DataMember()]
        public bool success
        { get { return _success; } set { _success = value; } }

        [DataMember()]
        public string message { get { return _message; } set { _message = value; } }

        [DataMember()]
        public T data { get { return _data; } set { _data = value; } }
        public RecordResponseObject(ref T data) { _data = data; }
    }
}