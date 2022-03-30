namespace DatabaseConfiguration
{
    public class Queries
    {
        public string[] keys = {};
        public string[] values = {};

        public Queries(string[] keys, string[] values)
        {
            this.keys = keys;
            this.values = values;
        }

        public Queries()
        {
        }

        public string GetInsertQuery(string tableName)
        {
            /*
            string withAt = string.Join(",@", keys);
            string valuesName = "@" + withAt;
            */
            return $"insert into {tableName} ({string.Join(",", keys)}) values({string.Join(",", values)});";
        }

        public string GetUpdateQuery(string tableName, string where, string isEqual)
        {
            string updateText = "";
            for (int i = 0; i < keys.Length; i++)
            {
                updateText += $"{keys[i]}={values[i]}";
            }
            return $"Update {tableName} set {updateText} where {where}={isEqual};";
        }

        public string GetDeleteQuery(string tableName, string where, string isEqual)
        {
            return $"Delete from {tableName} where {where}={isEqual}";
        }


        public string GetDataQuery(string tableName, string where, string isEqual)
        {
            return $"Select * from {tableName} where {where}={isEqual}";
        }

        public string GetAllDataQuery(string tableName)
        {
            return $"Select * from {tableName}";
        }


    }
}
