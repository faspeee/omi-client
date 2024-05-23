using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using OmiApplication.Proto;
using OmiApplication.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmiApplication.Services
{
    public class ValueOmiService :BaseClass, IValueOmiService, IDisposable
    {
        
        private readonly  ValueOmiGrpc.ValueOmiGrpcClient _clientValueOmiGrpc;

        public ValueOmiService() {
            _clientValueOmiGrpc = new ValueOmiGrpc.ValueOmiGrpcClient(channel);
        }

        public async IAsyncEnumerable<OmiValue> RetrieveAllValueOmi()
        {
           AsyncServerStreamingCall<ResponseValueOmi> _asyncServerObtainInfoValueOmi = _clientValueOmiGrpc.allValueOmi(new Empty());
          await foreach(var responseValueOmi in _asyncServerObtainInfoValueOmi.ResponseStream.ReadAllAsync())
            {
                yield return responseValueOmi.OmiValue;
            }
        }
    }
}
