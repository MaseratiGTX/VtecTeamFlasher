using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;

namespace VtecTeamFlasher.Helpers
{
    public class ClientMessageInspector : IClientMessageInspector
    {
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {

            if (Session.CurrentUser != null)
            {
                var userToken = Session.CurrentUser.Token;

                HttpResponseMessageProperty httpProp = null;
                if (request.Properties.ContainsKey(HttpResponseMessageProperty.Name))
                    httpProp = (HttpResponseMessageProperty)request.Properties[HttpResponseMessageProperty.Name];
                else
                {
                    httpProp = new HttpResponseMessageProperty();
                    request.Properties.Add(HttpResponseMessageProperty.Name, httpProp);
                }
                //request.Properties.Add("P1", "Test User");
                request.Headers.Add(MessageHeader.CreateHeader("UserToken", "http://vtecteam.com/", userToken));

            }
            
            
            return null;
        }

        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
        }
    }
}
