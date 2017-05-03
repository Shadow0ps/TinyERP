namespace App.Common.Data.MongoDB
{
    public class MongoConnectionString : ConnectionString
    {
        public MongoConnectionString(string connectionName = "")
            : base(DatabaseType.MongoDB, connectionName)
        {
        }
        public override string ToString()
        {
            return string.Format(
                "mongodb://{3}:{4}@{0}:{1}/{2}", 
                this.Server,
                this.Port,
                this.Database, 
                this.UserName, 
                this.Password
                );
        }
    }
}
