//Hannah Kops
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ServiceStack.Redis;

namespace Survey_Database
{
    class RedisUtil
    {
        private String host;
        private int port = 6379;
        private string pw;

        public RedisUtil(String host, int port, String pw)
        {
            this.host = host;
            this.port = port;
            this.pw = pw;
        }

        public IRedisNativeClient GetNativeClient()
        {
            return new RedisNativeClient(host, port, pw);
        }

        public IRedisClient GetClient()
        {
            return new RedisClient(host, port, pw);
        }

        public UserInput StoreInput(UserInput userIn)
        {
            UserInput storedEntry = null;
            using (IRedisClient client = new RedisClient(host, port, pw))
            {
                var entryClient = client.As<UserInput>();
                storedEntry = entryClient.Store(userIn);
            }
            return storedEntry;
        }

        public void StoreManyEntries(List<UserInput> userIn)
        {
            using (IRedisClient client = new RedisClient(host, port, pw))
            {
                var entryClient = client.As<UserInput>();
                entryClient.StoreAll(userIn);
            }
        }

        public UserInput GetInputEntry(int id)
        {
            UserInput storedEntry = null;
            using (IRedisClient client = new RedisClient(host, port, pw))
            {
                var entryClient = client.As<UserInput>();
                storedEntry = entryClient.GetById(id);
            }
            return storedEntry;
        }

        public IList<UserInput> GetAllEntries()
        {
            IList<UserInput> storedEntry = null;
            using (IRedisClient client = new RedisClient(host, port, pw))
            {
                var entryClient = client.As<UserInput>();
                storedEntry = entryClient.GetAll();
            }
            return storedEntry;
        }

        public void DeleteAllEntries()
        {
            using (IRedisClient client = new RedisClient(host, port, pw))
            {
                var entryClient = client.As<UserInput>();
                entryClient.DeleteAll();
            }
        }

    }
}
