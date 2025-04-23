namespace Juges
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DbMsql dbMsql = new DbMsql();
            dbMsql.InitialiserConnexion();
            dbMsql.SelectionerJoueurs();
        }
    }
}
