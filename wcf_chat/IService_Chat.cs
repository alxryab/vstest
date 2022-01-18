using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace wcf_chat
{
    // ПРИМЕЧАНИЕ. Можно использовать команду "Переименовать" в меню "Рефакторинг", чтобы изменить имя интерфейса "IService_Chat" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService_Chat
    {
        [OperationContract]
        void DoWork();
    }
}
