using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodDelivery.models;
using FoodDelivery.bll.validators;
using FoodDelivery.dao;

namespace FoodDelivery.bll
{
    public class ClientBLL
    {
        private List<IValidator<Client>> validators;

        public ClientBLL()
        {
            validators = new List<IValidator<Client>>();
            validators.Add(new CnpValidator());
            validators.Add(new EmailValidator());
            validators.Add(new NrTelefonValidator());
            validators.Add(new NumePrenumeValidator());
        }

        public int validareClient(Client c)
        {
            foreach (IValidator<Client> v in validators)
            {
                v.validate(c);
            }

            return 1;
        }

        public static void insertClient(Client c)
        {
            ReflectionDAO.insert(c, "Client");
        }

        public static Client getClientByUser(Cont a)
        {
            return ClientDAO.getById(a);
        }

        public static void updateClient(Client clientModificat, Client clientOriginal)
        {
            ReflectionDAO.update(clientModificat, clientOriginal, "Client");
        }

        public static void deleteClient(Client client)
        {
            ReflectionDAO.delete(client, "Client");
        }
    }
}
