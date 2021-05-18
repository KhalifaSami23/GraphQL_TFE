using System;
using System.Linq;
using System.Threading.Tasks;
using Backend_RentHouse_Khalifa_Sami.Model.Documents;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFE_Khalifa_Sami_2021.DAL;
using TFE_Khalifa_Sami_2021.Models;

namespace TFE_Khalifa_Sami_2021.GraphQL
{
    public class Queries
    {

        /* private readonly AppDbContext _context;
        public Queries(AppDbContext context)
        {
            _context = context;
        } */

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [GraphQLDescription("Gets All Users.")]
        public IQueryable<User> GetUsers([ScopedService] AppDbContext context)
        {
            return context.CommandUser.Include(p => p.PropertiesList);
        }
        
        [UseDbContext(typeof(AppDbContext))]
        [UseSorting]
        [GraphQLDescription("Gets All Properties.")]
        public IQueryable<Property> GetProperties([ScopedService] AppDbContext context)
        {
            return context.CommandProperty;
        }
        
        [UseDbContext(typeof(AppDbContext))]
        [UseSorting]
        [UseFiltering]
        [GraphQLDescription("Gets All Contracts with filtering/sorting.")]
        public IQueryable<Contract> GetContracts([ScopedService] AppDbContext context)
        {
            return context.CommandContract
            .Include(p => p.User)
            .Include(p => p.Property);
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseFiltering]
        [GraphQLDescription("Gets One Doc from Contract.")]
        public string GetDoc([ScopedService] AppDbContext context, int id, string type)
        {
            Contract c = context.CommandContract
                .Include(p => p.User)
                .Include(p => p.Property)
                .SingleOrDefault(p => p.IdContract == id);
            
            TypeContract tp;
            Enum.TryParse(type, out tp);
            
            Document doc = new Document(c,tp);
            string filePath = doc.GenerateDocument();
            string fileName =  doc.GetFileName();
            Console.WriteLine(filePath);
            Console.WriteLine(fileName);
            return fileName;
            /*const string mimeType ="application/vnd.ms-word"; 

            return new FileStreamResult(System.IO.File.OpenRead(filePath), mimeType)
            {
                FileDownloadName = fileName
            };*/
        }
    }
}