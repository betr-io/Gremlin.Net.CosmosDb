using Gremlin.Net.CosmosDb.Serialization;
using Gremlin.Net.CosmosDb.Structure;
using Gremlin.Net.Process.Traversal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Gremlin.Net.CosmosDb
{
    /// <summary>
    /// Helper extension methods for the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> object
    /// </summary>
    public static class IGraphClientExensions
    {
        #region ExecuteAsync

        /// <summary>
        /// Submits the given query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/>
        /// </summary>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="gremlinQuery">The traversal query.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static Task ExecuteAsync(this IGraphClient graphClient, string gremlinQuery, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return graphClient.QueryAsync(gremlinQuery, caller, filePath, sourceLineNumber);
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/>
        /// </summary>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static Task ExecuteAsync(this IGraphClient graphClient, ITraversal traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return graphClient.QueryAsync<object>(traversal, caller, filePath, sourceLineNumber);
        }

        #endregion ExecuteAsync

        #region QueryAsync

        /// <summary>
        /// Submits the given query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="gremlinQuery">The traversal query.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static Task<GraphResult<T>> QueryAsync<T>(this IGraphClient graphClient, string gremlinQuery, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return graphClient.QueryAsync<T>(gremlinQuery, BuildDefaultSerializerSettings(), caller, filePath, sourceLineNumber);
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static Task<GraphResult<T>> QueryAsync<T>(this IGraphClient graphClient, ITraversal traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return graphClient.QueryAsync<T>(traversal, BuildDefaultSerializerSettings(), caller, filePath, sourceLineNumber);
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static Task<GraphResult<E>> QueryAsync<S, E>(this IGraphClient graphClient, ITraversal<S, E> traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return graphClient.QueryAsync(traversal, BuildDefaultSerializerSettings(), caller, filePath, sourceLineNumber);
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static Task<GraphResult<E>> QueryAsync<S, E>(this IGraphClient graphClient, ISchemaBoundTraversal<S, E> traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return graphClient.QueryAsync(traversal, BuildDefaultSerializerSettings(), caller, filePath, sourceLineNumber);
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static Task<GraphResult<Vertex>> QueryAsync<S>(this IGraphClient graphClient, ITraversal<S, Gremlin.Net.Structure.Vertex> traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return graphClient.QueryAsync<Vertex>(traversal, caller, filePath, sourceLineNumber);
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static Task<GraphResult<Edge>> QueryAsync<S>(this IGraphClient graphClient, ITraversal<S, Gremlin.Net.Structure.Edge> traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return graphClient.QueryAsync<Edge>(traversal, caller, filePath, sourceLineNumber);
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static Task<GraphResult<Property>> QueryAsync<S>(this IGraphClient graphClient, ITraversal<S, Gremlin.Net.Structure.Property> traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return graphClient.QueryAsync<Property>(traversal, caller, filePath, sourceLineNumber);
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="gremlinQuery">The traversal query.</param>
        /// <param name="serializerSettings">The serializer settings.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<GraphResult<T>> QueryAsync<T>(this IGraphClient graphClient, string gremlinQuery, JsonSerializerSettings serializerSettings, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            var result = await graphClient.QueryAsync(gremlinQuery, caller, filePath, sourceLineNumber);
            var serializer = JsonSerializer.Create(serializerSettings);

            return result.ApplyType<T>(serializer);
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="serializerSettings">The serializer settings.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static Task<GraphResult<E>> QueryAsync<S, E>(this IGraphClient graphClient, ITraversal<S, E> traversal, JsonSerializerSettings serializerSettings, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return graphClient.QueryAsync<E>(traversal, serializerSettings, caller, filePath, sourceLineNumber);
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="serializerSettings">The serializer settings.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static Task<GraphResult<E>> QueryAsync<S, E>(this IGraphClient graphClient, ISchemaBoundTraversal<S, E> traversal, JsonSerializerSettings serializerSettings, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return graphClient.QueryAsync<E>(traversal.AsGraphTraversal(), serializerSettings, caller, filePath, sourceLineNumber);
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="serializerSettings">The serializer settings.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static Task<GraphResult<T>> QueryAsync<T>(this IGraphClient graphClient, ITraversal traversal, JsonSerializerSettings serializerSettings, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (traversal == null)
                throw new ArgumentNullException(nameof(traversal));

            var gremlinQuery = traversal.ToGremlinQuery();

            return graphClient.QueryAsync<T>(gremlinQuery, serializerSettings, caller, filePath, sourceLineNumber);
        }

        /// <summary>
        /// Builds the default serializer settings.
        /// </summary>
        /// <returns>Returns the settings</returns>
        private static JsonSerializerSettings BuildDefaultSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                Converters = new JsonConverter[]
                {
                    new TreeJsonConverter(),
                    new IEdgeJsonConverter(),
                    new ElementJsonConverter(),
                    new IVertexJsonConverter(),
                    new IsoDateTimeConverter
                    {
                        DateTimeStyles = DateTimeStyles.AdjustToUniversal
                    }
                },
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                DateParseHandling = DateParseHandling.DateTimeOffset,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };
        }

        #endregion QueryAsync

        #region QueryFirstAsync

        /// <summary>
        /// Submits the given query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the first result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="gremlinQuery">The traversal query.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<T> QueryFirstAsync<T>(this IGraphClient graphClient, string gremlinQuery, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync<T>(gremlinQuery, caller, filePath, sourceLineNumber)).First();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<T> QueryFirstAsync<T>(this IGraphClient graphClient, ITraversal traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync<T>(traversal, caller, filePath, sourceLineNumber)).First();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<E> QueryFirstAsync<S, E>(this IGraphClient graphClient, ITraversal<S, E> traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, caller, filePath, sourceLineNumber)).First();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<E> QueryFirstAsync<S, E>(this IGraphClient graphClient, ISchemaBoundTraversal<S, E> traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, caller, filePath, sourceLineNumber)).First();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<Vertex> QueryFirstAsync<S>(this IGraphClient graphClient, ITraversal<S, Gremlin.Net.Structure.Vertex> traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, caller, filePath, sourceLineNumber)).First();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<Edge> QueryFirstAsync<S>(this IGraphClient graphClient, ITraversal<S, Gremlin.Net.Structure.Edge> traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, caller, filePath, sourceLineNumber)).First();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<Property> QueryFirstAsync<S>(this IGraphClient graphClient, ITraversal<S, Gremlin.Net.Structure.Property> traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, caller, filePath, sourceLineNumber)).First();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="gremlinQuery">The traversal query.</param>
        /// <param name="serializerSettings">The serializer settings.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<T> QueryFirstAsync<T>(this IGraphClient graphClient, string gremlinQuery, JsonSerializerSettings serializerSettings, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync<T>(gremlinQuery, serializerSettings, caller, filePath, sourceLineNumber)).First();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="serializerSettings">The serializer settings.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<E> QueryFirstAsync<S, E>(this IGraphClient graphClient, ITraversal<S, E> traversal, JsonSerializerSettings serializerSettings, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, serializerSettings, caller, filePath, sourceLineNumber)).First();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="serializerSettings">The serializer settings.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<E> QueryFirstAsync<S, E>(this IGraphClient graphClient, ISchemaBoundTraversal<S, E> traversal, JsonSerializerSettings serializerSettings, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, serializerSettings, caller, filePath, sourceLineNumber)).First();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="serializerSettings">The serializer settings.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<T> QueryFirstAsync<T>(this IGraphClient graphClient, ITraversal traversal, JsonSerializerSettings serializerSettings, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync<T>(traversal, serializerSettings, caller, filePath, sourceLineNumber)).First();
        }

        #endregion QueryFirstAsync

        #region QueryFirstOrDefaultAsync

        /// <summary>
        /// Submits the given query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the first result,
        /// or the default value of <typeparamref name="T"/> if no results were found
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="gremlinQuery">The traversal query.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<T> QueryFirstOrDefaultAsync<T>(this IGraphClient graphClient, string gremlinQuery, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync<T>(gremlinQuery, caller, filePath, sourceLineNumber)).FirstOrDefault();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result, or the default value of <typeparamref name="T"/> if no results were found
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<T> QueryFirstOrDefaultAsync<T>(this IGraphClient graphClient, ITraversal traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync<T>(traversal, caller, filePath, sourceLineNumber)).FirstOrDefault();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result, or the default value of <typeparamref name="E"/> if no results were found
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<E> QueryFirstOrDefaultAsync<S, E>(this IGraphClient graphClient, ITraversal<S, E> traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, caller, filePath, sourceLineNumber)).FirstOrDefault();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result, or the default value of <typeparamref name="E"/> if no results were found
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<E> QueryFirstOrDefaultAsync<S, E>(this IGraphClient graphClient, ISchemaBoundTraversal<S, E> traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, caller, filePath, sourceLineNumber)).FirstOrDefault();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first vertex, or <c>null</c> if no results were found
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<Vertex> QueryFirstOrDefaultAsync<S>(this IGraphClient graphClient, ITraversal<S, Gremlin.Net.Structure.Vertex> traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, caller, filePath, sourceLineNumber)).FirstOrDefault();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first edge, or <c>null</c> if no results were found
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<Edge> QueryFirstOrDefaultAsync<S>(this IGraphClient graphClient, ITraversal<S, Gremlin.Net.Structure.Edge> traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, caller, filePath, sourceLineNumber)).FirstOrDefault();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first property, or <c>null</c> if no results were found
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<Property> QueryFirstOrDefaultAsync<S>(this IGraphClient graphClient, ITraversal<S, Gremlin.Net.Structure.Property> traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, caller, filePath, sourceLineNumber)).FirstOrDefault();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result, or the default value of <typeparamref name="T"/> if no results were found
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="gremlinQuery">The traversal query.</param>
        /// <param name="serializerSettings">The serializer settings.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<T> QueryFirstOrDefaultAsync<T>(this IGraphClient graphClient, string gremlinQuery, JsonSerializerSettings serializerSettings, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync<T>(gremlinQuery, serializerSettings, caller, filePath, sourceLineNumber)).FirstOrDefault();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result, or the default value of <typeparamref name="E"/> if no results were found
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="serializerSettings">The serializer settings.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<E> QueryFirstOrDefaultAsync<S, E>(this IGraphClient graphClient, ITraversal<S, E> traversal, JsonSerializerSettings serializerSettings, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, serializerSettings, caller, filePath, sourceLineNumber)).FirstOrDefault();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result, or the default value of <typeparamref name="E"/> if no results were found
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="serializerSettings">The serializer settings.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<E> QueryFirstOrDefaultAsync<S, E>(this IGraphClient graphClient, ISchemaBoundTraversal<S, E> traversal, JsonSerializerSettings serializerSettings, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, serializerSettings, caller, filePath, sourceLineNumber)).FirstOrDefault();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result, or the default value of <typeparamref name="T"/> if no results were found
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="serializerSettings">The serializer settings.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<T> QueryFirstOrDefaultAsync<T>(this IGraphClient graphClient, ITraversal traversal, JsonSerializerSettings serializerSettings, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync<T>(traversal, serializerSettings, caller, filePath, sourceLineNumber)).FirstOrDefault();
        }

        #endregion QueryFirstOrDefaultAsync

        #region QuerySingleAsync

        /// <summary>
        /// Submits the given query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the first result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="gremlinQuery">The traversal query.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<T> QuerySingleAsync<T>(this IGraphClient graphClient, string gremlinQuery, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync<T>(gremlinQuery, caller, filePath, sourceLineNumber)).Single();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<T> QuerySingleAsync<T>(this IGraphClient graphClient, ITraversal traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync<T>(traversal, caller, filePath, sourceLineNumber)).Single();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<E> QuerySingleAsync<S, E>(this IGraphClient graphClient, ITraversal<S, E> traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, caller, filePath, sourceLineNumber)).Single();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<E> QuerySingleAsync<S, E>(this IGraphClient graphClient, ISchemaBoundTraversal<S, E> traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, caller, filePath, sourceLineNumber)).Single();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<Vertex> QuerySingleAsync<S>(this IGraphClient graphClient, ITraversal<S, Gremlin.Net.Structure.Vertex> traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, caller, filePath, sourceLineNumber)).Single();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<Edge> QuerySingleAsync<S>(this IGraphClient graphClient, ITraversal<S, Gremlin.Net.Structure.Edge> traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, caller, filePath, sourceLineNumber)).Single();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<Property> QuerySingleAsync<S>(this IGraphClient graphClient, ITraversal<S, Gremlin.Net.Structure.Property> traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, caller, filePath, sourceLineNumber)).Single();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="gremlinQuery">The traversal query.</param>
        /// <param name="serializerSettings">The serializer settings.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<T> QuerySingleAsync<T>(this IGraphClient graphClient, string gremlinQuery, JsonSerializerSettings serializerSettings, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync<T>(gremlinQuery, serializerSettings, caller, filePath, sourceLineNumber)).Single();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="serializerSettings">The serializer settings.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<E> QuerySingleAsync<S, E>(this IGraphClient graphClient, ITraversal<S, E> traversal, JsonSerializerSettings serializerSettings, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, serializerSettings, caller, filePath, sourceLineNumber)).Single();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="serializerSettings">The serializer settings.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<E> QuerySingleAsync<S, E>(this IGraphClient graphClient, ISchemaBoundTraversal<S, E> traversal, JsonSerializerSettings serializerSettings, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, serializerSettings, caller, filePath, sourceLineNumber)).Single();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="serializerSettings">The serializer settings.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<T> QuerySingleAsync<T>(this IGraphClient graphClient, ITraversal traversal, JsonSerializerSettings serializerSettings, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync<T>(traversal, serializerSettings, caller, filePath, sourceLineNumber)).Single();
        }

        #endregion QuerySingleAsync

        #region QuerySingleOrDefaultAsync

        /// <summary>
        /// Submits the given query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the first result,
        /// or the default value of <typeparamref name="T"/> if no results were found
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="gremlinQuery">The traversal query.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<T> QuerySingleOrDefaultAsync<T>(this IGraphClient graphClient, string gremlinQuery, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync<T>(gremlinQuery, caller, filePath, sourceLineNumber)).SingleOrDefault();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result, or the default value of <typeparamref name="T"/> if no results were found
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<T> QuerySingleOrDefaultAsync<T>(this IGraphClient graphClient, ITraversal traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync<T>(traversal, caller, filePath, sourceLineNumber)).SingleOrDefault();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result, or the default value of <typeparamref name="E"/> if no results were found
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<E> QuerySingleOrDefaultAsync<S, E>(this IGraphClient graphClient, ITraversal<S, E> traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, caller, filePath, sourceLineNumber)).SingleOrDefault();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result, or the default value of <typeparamref name="E"/> if no results were found
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<E> QuerySingleOrDefaultAsync<S, E>(this IGraphClient graphClient, ISchemaBoundTraversal<S, E> traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, caller, filePath, sourceLineNumber)).SingleOrDefault();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first vertex, or <c>null</c> if no results were found
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<Vertex> QuerySingleOrDefaultAsync<S>(this IGraphClient graphClient, ITraversal<S, Gremlin.Net.Structure.Vertex> traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, caller, filePath, sourceLineNumber)).SingleOrDefault();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first edge, or <c>null</c> if no results were found
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<Edge> QuerySingleOrDefaultAsync<S>(this IGraphClient graphClient, ITraversal<S, Gremlin.Net.Structure.Edge> traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, caller, filePath, sourceLineNumber)).SingleOrDefault();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first property, or <c>null</c> if no results were found
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<Property> QuerySingleOrDefaultAsync<S>(this IGraphClient graphClient, ITraversal<S, Gremlin.Net.Structure.Property> traversal, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, caller, filePath, sourceLineNumber)).SingleOrDefault();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result, or the default value of <typeparamref name="T"/> if no results were found
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="gremlinQuery">The traversal query.</param>
        /// <param name="serializerSettings">The serializer settings.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<T> QuerySingleOrDefaultAsync<T>(this IGraphClient graphClient, string gremlinQuery, JsonSerializerSettings serializerSettings, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync<T>(gremlinQuery, serializerSettings, caller, filePath, sourceLineNumber)).SingleOrDefault();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result, or the default value of <typeparamref name="E"/> if no results were found
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="serializerSettings">The serializer settings.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<E> QuerySingleOrDefaultAsync<S, E>(this IGraphClient graphClient, ITraversal<S, E> traversal, JsonSerializerSettings serializerSettings, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, serializerSettings, caller, filePath, sourceLineNumber)).SingleOrDefault();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result, or the default value of <typeparamref name="E"/> if no results were found
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="serializerSettings">The serializer settings.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<E> QuerySingleOrDefaultAsync<S, E>(this IGraphClient graphClient, ISchemaBoundTraversal<S, E> traversal, JsonSerializerSettings serializerSettings, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync(traversal, serializerSettings, caller, filePath, sourceLineNumber)).SingleOrDefault();
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the
        /// first result, or the default value of <typeparamref name="T"/> if no results were found
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="serializerSettings">The serializer settings.</param>
        /// <param name="caller">Method name or property name of the caller.</param>
        /// <param name="filePath">Full path of the source file that contains the caller. The full path is the path at compile time.</param>
        /// <param name="sourceLineNumber">Line number in the source file from which the method is called.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        public static async Task<T> QuerySingleOrDefaultAsync<T>(this IGraphClient graphClient, ITraversal traversal, JsonSerializerSettings serializerSettings, [CallerMemberName] string caller = "", [CallerFilePath] string filePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            return (await graphClient.QueryAsync<T>(traversal, serializerSettings, caller, filePath, sourceLineNumber)).SingleOrDefault();
        }

        #endregion QuerySingleOrDefaultAsync

        #region SubmitAsync (Obsolete)

        /// <summary>
        /// Submits the given query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="gremlinQuery">The traversal query.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        [Obsolete("Please use QueryAsync or other method instead")]
        public static Task<GraphResult<T>> SubmitAsync<T>(this IGraphClient graphClient, string gremlinQuery)
        {
            return graphClient.QueryAsync<T>(gremlinQuery);
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        [Obsolete("Please use QueryAsync or other method instead")]
        public static Task<GraphResult<T>> SubmitAsync<T>(this IGraphClient graphClient, ITraversal traversal)
        {
            return graphClient.QueryAsync<T>(traversal);
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        [Obsolete("Please use QueryAsync or other method instead")]
        public static Task<GraphResult<E>> SubmitAsync<S, E>(this IGraphClient graphClient, ITraversal<S, E> traversal)
        {
            return graphClient.QueryAsync(traversal);
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        [Obsolete("Please use QueryAsync or other method instead")]
        public static Task<GraphResult<E>> SubmitAsync<S, E>(this IGraphClient graphClient, ISchemaBoundTraversal<S, E> traversal)
        {
            return graphClient.QueryAsync(traversal);
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        [Obsolete("Please use QueryAsync or other method instead")]
        public static Task<GraphResult<Vertex>> SubmitAsync<S>(this IGraphClient graphClient, ITraversal<S, Gremlin.Net.Structure.Vertex> traversal)
        {
            return graphClient.QueryAsync(traversal);
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        [Obsolete("Please use QueryAsync or other method instead")]
        public static Task<GraphResult<Edge>> SubmitAsync<S>(this IGraphClient graphClient, ITraversal<S, Gremlin.Net.Structure.Edge> traversal)
        {
            return graphClient.QueryAsync(traversal);
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        [Obsolete("Please use QueryAsync or other method instead")]
        public static Task<GraphResult<Property>> SubmitAsync<S>(this IGraphClient graphClient, ITraversal<S, Gremlin.Net.Structure.Property> traversal)
        {
            return graphClient.QueryAsync(traversal);
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="gremlinQuery">The traversal query.</param>
        /// <param name="serializerSettings">The serializer settings.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        [Obsolete("Please use QueryAsync or other method instead")]
        public static Task<GraphResult<T>> SubmitAsync<T>(this IGraphClient graphClient, string gremlinQuery, JsonSerializerSettings serializerSettings)
        {
            return graphClient.QueryAsync<T>(gremlinQuery, serializerSettings);
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="serializerSettings">The serializer settings.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        [Obsolete("Please use QueryAsync or other method instead")]
        public static Task<GraphResult<E>> SubmitAsync<S, E>(this IGraphClient graphClient, ITraversal<S, E> traversal, JsonSerializerSettings serializerSettings)
        {
            return graphClient.QueryAsync(traversal, serializerSettings);
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the result
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <typeparam name="E"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="serializerSettings">The serializer settings.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        [Obsolete("Please use QueryAsync or other method instead")]
        public static Task<GraphResult<E>> SubmitAsync<S, E>(this IGraphClient graphClient, ISchemaBoundTraversal<S, E> traversal, JsonSerializerSettings serializerSettings)
        {
            return graphClient.QueryAsync(traversal, serializerSettings);
        }

        /// <summary>
        /// Submits the given traversal query to the <see cref="Gremlin.Net.CosmosDb.IGraphClient"/> and returns the result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="graphClient">The graph client.</param>
        /// <param name="traversal">The traversal.</param>
        /// <param name="serializerSettings">The serializer settings.</param>
        /// <returns>Returns the result</returns>
        /// <exception cref="ArgumentNullException">traversal</exception>
        [Obsolete("Please use QueryAsync or other method instead")]
        public static Task<GraphResult<T>> SubmitAsync<T>(this IGraphClient graphClient, ITraversal traversal, JsonSerializerSettings serializerSettings)
        {
            return graphClient.QueryAsync<T>(traversal, serializerSettings);
        }

        #endregion SubmitAsync (Obsolete)
    }
}