using Microsoft.EntityFrameworkCore;
using ProductSystem.Services.Data.Interfaces;
using Shop.System.Data;
using ShopSystem.Data.Models;
using ShopSystems.Web.ViewModels.Cart;
using ShopSystems.Web.ViewModels.Client;

namespace ProductSystem.Services.Data
{
    public class ClientService : IClientService
    {
        private readonly Sh0pDBContext dbContext;

        public ClientService(Sh0pDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddClient(AddClientViewModel model)
        {
            Client client = new Client()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                City = model.City,
                PhoneNumber = model.PhoneNumber,
                OrderDate = model.OrderDate,
                Country = model.Country
            };
            await dbContext.Clients.AddAsync(client);
            await dbContext.SaveChangesAsync();
        }

        //public async Task AddOrder(AllProductsToCart bill, ClientViewModel client)
        //{
        //    bool alreadyAdded = await dbContext.BillsClients
        //                .AnyAsync(ub => ub.BillId.ToString() == bill.Id && ub.ClientId.ToString() == client.Id);

        //    if (alreadyAdded == false)
        //    {
        //        var clientBills = new BillsClients
        //        {
        //            BillId = Guid.Parse(bill.Id),
        //            ClientId = Guid.Parse(client.Id)
        //        };

        //        await dbContext.BillsClients.AddAsync(clientBills);
        //        await dbContext.SaveChangesAsync();
        //    }
        //}

        public async Task<AllProductsToCart?> GetBillByIdAsync(string id)
        {
            return await dbContext.Bills
        .Where(b => b.Id.ToString() == id)
        .Select(b => new AllProductsToCart
        {
            Id = b.Id.ToString(),
            Name = b.Cart.Product.Name,
            Price = b.Cart.Product.Price,
            Quantity = b.Cart.Quantity,
            ImageUrl = b.Cart.Product.ImageUrl,
            Description = b.Cart.Product.Description,
            Category = b.Cart.Product.Category.Name
        }).FirstOrDefaultAsync();
        }

        public async Task<ClientViewModel?> GetClientByIdAsync(string id)
        {
            return await dbContext.Clients
    .Where(b => b.Id.ToString() == id)
    .Select(b => new ClientViewModel
    {
        Id = b.Id.ToString(),
        FirstName = b.FirstName,
        LastName = b.LastName,
        Address = b.Address,
        City = b.City,
        Country = b.Country,
        OrderDate = b.OrderDate,
        PhoneNumber = b.PhoneNumber
    }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AllOrdersViewModel>> GetMyOrdersAsync()
        {
            return await dbContext.Clients
                .Select(p => new AllOrdersViewModel
                    {
                    Id = p.Id.ToString(),
                    FirstName=p.FirstName,
                    LastName=p.LastName,
                    Address = p.Address,
                    City = p.City,
                    Country = p.Country,
                    OrderDate = p.OrderDate,
                    PhoneNumber = p.PhoneNumber
                    }).ToArrayAsync();
        }
    }
}
