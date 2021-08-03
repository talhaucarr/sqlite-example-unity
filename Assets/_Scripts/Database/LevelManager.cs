using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using Utilities;

public class LevelManager : AutoCleanupSingleton<LevelManager>
{
    private SqliteConnection _connection;
    private SqliteCommand _command;
}
