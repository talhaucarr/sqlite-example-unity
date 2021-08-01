using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public interface IDatabaseConenction
{
    void SetDBName(string dbName);
    SqliteConnection ConnectDB();
    void ConnectionCloseDB();
}
