using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Library.ServiceInterface
{
    public static class ITenantService_Channel
    {
        public static ITenantService Create(Uri endpoint = null, Binding binding = null, List<IEndpointBehavior> behaviors = null)
        {
            endpoint = endpoint ?? GetUri();
            binding = binding ?? GetBinding(endpoint);

            var factory = new ChannelFactory<ITenantService>(binding);

            if (behaviors != null && behaviors.Any())
            {
                behaviors.ForEach(factory.Endpoint.Behaviors.Add);
            }

            return factory.CreateChannel(new EndpointAddress(endpoint));
        }

        public static BasicHttpBinding GetBinding(Uri uri)
        {
            var securityMode = uri.Scheme == "http" ? BasicHttpSecurityMode.None : BasicHttpSecurityMode.Transport;

            var binding = new BasicHttpBinding
            {
                MaxReceivedMessageSize = 50 * 1024 * 1024,
                Security = new BasicHttpSecurity { Mode = securityMode }
            };

            return binding;
        }

        public static Uri GetUri()
        {
            switch ("local")
            {
                case "local":
                    return LocalEndpoint;
                default:
                    throw new Exception("Having a few issues here, Mr Landlord! Please contact support.");
            }
        }
        public static Uri LocalEndpoint { get { return new Uri("http://localhost:25090/FylServices/TenantService/TenantService.svc"); } }
    }
}
