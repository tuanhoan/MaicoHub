using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MaicoHub.DataAccess
{
    public class Mutation
    {
        private static GraphQLHttpClient graphQLHttpClient;

        static Mutation()
        {
            var uri = new Uri("https://fd35c724c4be.ngrok.io/graphql");
            var graphQLOptions = new GraphQLHttpClientOptions
            {
                EndPoint = uri,
                HttpMessageHandler = new NativeMessageHandler(),
            };

            graphQLHttpClient = new GraphQLHttpClient(graphQLOptions, new NewtonsoftJsonSerializer());
        }

        public static async Task<T> ExceuteMutationAsyn<T>(string graphQLQueryType, string completeQueryString)
        {
            T result;
            try
            {
                //completeQueryString = "mutation{addInformation(filePath:\"C:/Users/Administrator/Downloads/1.jpg\", phoneNumber:\"900\"){    filePath,    phoneNumber,    id  }}";
                var request = new GraphQLRequest
                {
                    Query = completeQueryString
                }; 
                var response = await graphQLHttpClient.SendMutationAsync<object>(request);

                var stringResult = response.Data.ToString();
                stringResult = stringResult.Replace($"\"{graphQLQueryType}\":", string.Empty);
                stringResult = stringResult.Remove(0, 1);
                stringResult = stringResult.Remove(stringResult.Length - 1, 1);

                result = JsonConvert.DeserializeObject<T>(stringResult);

                return result;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                result = JsonConvert.DeserializeObject<T>("sđá");
                return result;
            }
        }
    }
}
