using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommInterface
{
    // server side interface
    interface ICommServer
    {
        // return setting, when client calls this, it expects ICommClient.DataSetting(...) as response
        void ReadSetting(int id, TYPE type);

        // write setting, when client calls this, it expects ICommClient.SettingSet(...) as response
        void WriteSetting(int id, TYPE type, byte length, byte[] data);
    }

    // client side interface
    interface ICommClient
    {
        // state .. return state of client
        STATE State();

        // data setting ... response to ICommServer.ReadSetting()
        void DataSetting(int id, TYPE type, byte length, byte[] data, ERROR error);

        // setting set ... response to ICommServer.WriteSetting()
        void SettingSet(int id, ERROR error);
    }

    public enum STATE : byte
    {
        OK = 1,
        ERROR = 2,
        Unknown = 255
    }

    public enum TYPE : byte
    {
        Bool = 1,
        Int8 = 16,
        Int16 = 17,
        CharStr = 255
    }

    public enum ERROR : byte
    {
        OK = 0,
        MissingID = 16,
        DataTypeError = 32,
        DataLengthError = 128,
        UnknownError = 255
    }
}
