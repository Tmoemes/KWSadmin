using System;
using KWSAdmin.Persistence;
using KWSAdmin.Persistence.Interface.Dtos;

namespace dbtest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ClientDal test = new ClientDal(new DbConnection());

            ClientDto temp = new ClientDto(1,"Kees","Mees","+31-68458466","MeesKees@yahoo.co","straatnaam 8");
            test.Add(temp);

            Console.WriteLine(test.GetById(1).ToString());
            Console.WriteLine("Hello World!");
        }
    }
}
