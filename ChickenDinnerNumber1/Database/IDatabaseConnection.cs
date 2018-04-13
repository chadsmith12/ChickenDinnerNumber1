using SQLite;

namespace ChickenDinnerNumber1.Database
{
    /// <summary>
    /// Provides a conecting interface for all sqlite connections.
    /// </summary>
    public interface IDatabaseConnection
    {
        /// <summary>
        /// Initiates an async SQLite Connection.
        /// </summary>
        /// <param name="dbName">Name of the database to connect to.</param>
        /// <returns>The async connection to the db.</returns>
        SQLiteAsyncConnection DbConnect(string dbName);
    }
}
