using Gremlin.Net.CosmosDb.Structure;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Gremlin.Net.CosmosDb
{
    /// <summary>
    /// Cosmos Db graph client that can be used for querying and mutation of the graph
    /// </summary>
    public interface IGraphClient
    {
        /// <summary>
        /// Creates the traversal source (g).
        /// </summary>
        /// <returns>Returns the traversal source</returns>
        IGraphTraversalSource CreateTraversalSource();

        /// <summary>
        /// Submits the given gremlin query to the Cosmos Db instance and returns the results.
        /// </summary>
        /// <param name="gremlinQuery">The gremlin query.</param>
        /// <returns>Returns the results</returns>
        Task<GraphResult> QueryAsync(
            string gremlinQuery,
            [CallerMemberName] string caller = "",
            [CallerFilePath] string filePath = "",
            [CallerLineNumber] int sourceLineNumber = 0);

        /// <summary>
        /// Submits the given gremlin query to the Cosmos Db instance.
        /// </summary>
        /// <param name="gremlinQuery">The gremlin query.</param>
        /// <returns>Returns the results</returns>
        [Obsolete("Renaming to QueryAsync")]
        Task<GraphResult> SubmitAsync(string gremlinQuery);
    }
}