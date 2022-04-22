using System.Collections;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using System.Data;
using System;
using UnityEngine;

public class dbtest : MonoBehaviour
{
    private void Start()
    {
        ReadDB;
    }

    // Start is called before the first frame update
    void ReadDB()
    {
        string conn = "URI=file:" + Application.dataPath + "/SE project.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT Threat" + "FROM game";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read()) 
        {
            string Threat = reader.GetString(0);
            
            Debug.Log("Threat= "+ Threat);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;


        
    }

}
