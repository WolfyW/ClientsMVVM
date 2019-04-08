using ClientsMVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientsMVVM
{
    static class CRUDOperation
    {
        private static ClientContext context = new ClientContext();

        public static void AddClient(Client client)
        {
            context.Clients.Add(client);
            context.SaveChanges();
        }

        public static void RemoveClient(Client client)
        {
            context.Clients.Remove(client);
            context.SaveChanges();
        }

        public static List<Client> GetClients()
        {
            return context.Clients.ToList();
        }

        public static void Updateclient()
        {
            context.SaveChanges();
        }
    }
}
