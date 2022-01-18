﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace wcf_chat
{
    // ПРИМЕЧАНИЕ. Можно использовать команду "Переименовать" в меню "Рефакторинг", чтобы изменить имя интерфейса "IService_Chat" в коде и файле конфигурации.
    [ServiceContract(CallbackContract = typeof(IServerChatCallback))]
    public interface IService_Chat
    {
        [OperationContract]
        int Connect(string name);

        [OperationContract]
        void Disconnect(int id);

        [OperationContract(IsOneWay = true)]
        void SendMsg(string msg, int id);

    }

    public interface IServerChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void MsgCallback(string msg);

    }
}
