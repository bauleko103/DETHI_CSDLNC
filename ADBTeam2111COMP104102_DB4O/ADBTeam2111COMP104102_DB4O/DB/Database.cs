using Db4objects.Db4o;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADBTeam2111COMP104102_DB4O.EF;

namespace ADBTeam2111COMP104102_DB4O.DB
{
    class Database
    {
        public static string DbFileName { get; set; }
        public static IObjectContainer DB = null;
        public static void Open()
        {
            DB = Db4oEmbedded.OpenFile(DbFileName);
        }
        public static void CloseDB() { DB.Close(); }

        public static void Store<T>(T obj)
        {
            try
            {
                DB.Store(obj);
                DB.Commit();
            }
            catch
            {
                DB.Rollback();
            }
        }
        public static void Save<A, B>(A obj1, B obj2)
        {
            try
            {
                DB.Store(obj1);
                DB.Store(obj2);
                DB.Commit();
            }
            catch
            {
                DB.Rollback();
            }
        }
        public static void Delete<T>(T obj)
        {
            try
            {
                DB.Delete(obj);
                DB.Commit();
            }
            catch
            {
                DB.Rollback();
            }
        }
    }
}
