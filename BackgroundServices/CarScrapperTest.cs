using CarTradeCenter.Contracts;
using CarTradeCenter.Data;
using CarTradeCenter.Data.Models;
using CarTradeCenter.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CarTradeCenter.BackgroundServices
{
    public class CarScrapperTest : BackgroundService, IHostedService
    {
        private readonly Random rnd;
        private readonly IRepositoryVehicle Repo;


        public CarScrapperTest(IServiceScopeFactory factory)
        {
            this.rnd = new Random();
            this.Repo = factory.CreateScope().ServiceProvider.GetRequiredService<IRepositoryVehicle>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                TryToAddVehicleDamaged(10);
                await Task.Delay(60000);
            }
        }


        public void TryToAddVehicleDamaged(int limitCarsInTheDb)
        {
            if (Repo.FindAll().Count() < limitCarsInTheDb)
            {
                Repo.Create(CreateDummyCar());
            }
        }

        public Vehicle CreateDummyCar()
        {
            Vehicle dummyCar = new Vehicle
            {
                Title = "Car " + rnd.Next(),
                DateAuctionEnd = DateTime.Now.AddDays(30),
                DateAuctionStart = DateTime.Now,
                DamageDescription = "brak uszkodzen",
                Url = "google.com",
            };
            dummyCar.Images.Append<Image>(new Image(CreateDummyImage()));
            return dummyCar;
        }

        private string CreateDummyImage()
        {
            List<string> dummyLinks = new List<string>
            {
                "https://upload.wikimedia.org/wikipedia/commons/thumb/3/31/2019_Peugeot_508_GT-Line_BlueHDi_1.5_%28130_PS%29_Front_%281%29.jpg/1920px-2019_Peugeot_508_GT-Line_BlueHDi_1.5_%28130_PS%29_Front_%281%29.jpg",
                "https://upload.wikimedia.org/wikipedia/commons/thumb/1/1c/2018_Ford_Mondeo_Vignale_TDCi_Automatic_2.0_Front.jpg/1920px-2018_Ford_Mondeo_Vignale_TDCi_Automatic_2.0_Front.jpg",
                "https://upload.wikimedia.org/wikipedia/commons/1/19/20160311_Renault_Samsung_SM6_01.jpg",
                "https://images.unsplash.com/photo-1503376780353-7e6692767b70?ixid=MXwxMjA3fDB8MHxzZWFyY2h8MTN8fGNhcnxlbnwwfHwwfA%3D%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                "https://images.unsplash.com/photo-1511919884226-fd3cad34687c?ixid=MXwxMjA3fDB8MHxzZWFyY2h8MTF8fGNhcnxlbnwwfHwwfA%3D%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                "https://images.unsplash.com/photo-1502877338535-766e1452684a?ixid=MXwxMjA3fDB8MHxzZWFyY2h8MTZ8fGNhcnxlbnwwfHwwfA%3D%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                "https://images.unsplash.com/photo-1541899481282-d53bffe3c35d?ixid=MXwxMjA3fDB8MHxzZWFyY2h8Mjd8fGNhcnxlbnwwfHwwfA%3D%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                "https://images.unsplash.com/photo-1502489597346-dad15683d4c2?ixlib=rb-1.2.1&ixid=MXwxMjA3fDB8MHxzZWFyY2h8MzB8fGNhcnxlbnwwfHwwfA%3D%3D&auto=format&fit=crop&w=500&q=60",
                "https://images.unsplash.com/photo-1504215680853-026ed2a45def?ixid=MXwxMjA3fDB8MHxzZWFyY2h8NDB8fGNhcnxlbnwwfHwwfA%3D%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                "https://images.unsplash.com/photo-1546614042-7df3c24c9e5d?ixid=MXwxMjA3fDB8MHxzZWFyY2h8NDZ8fGNhcnxlbnwwfHwwfA%3D%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                "https://images.unsplash.com/photo-1549925862-990ac5b34e35?ixid=MXwxMjA3fDB8MHxzZWFyY2h8NTd8fGNhcnxlbnwwfHwwfA%3D%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                "https://images.unsplash.com/photo-1592840062661-a5a7f78e2056?ixid=MXwxMjA3fDB8MHxzZWFyY2h8NjV8fGNhcnxlbnwwfHwwfA%3D%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                "https://images.unsplash.com/photo-1547165900-656dbc4f4557?ixid=MXwxMjA3fDB8MHxzZWFyY2h8NjJ8fGNhcnxlbnwwfHwwfA%3D%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                "https://images.unsplash.com/photo-1592797520856-883837ddd186?ixid=MXwxMjA3fDB8MHxzZWFyY2h8Nzh8fGNhcnxlbnwwfHwwfA%3D%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/2020-audi-rs7-112-1569274021.jpg?crop=0.735xw:0.673xh;0.141xw,0.270xh&resize=480:*",
                "https://www.topgear.com/sites/default/files/styles/16x9_1280w/public/images/gallery-migration/2014-04/EAB5CCC2-C5D7-48F1-9224-549434C247A0_0.jpg?itok=lYJGCYR6",
                "https://images.unsplash.com/photo-1597404294360-feeeda04612e?ixid=MXwxMjA3fDB8MHxzZWFyY2h8MXx8Y2FyfGVufDB8fDB8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
                "https://ocdn.eu/pulscms-transforms/1/fvkk9kpTURBXy82MzE5YmFkNTRkNjU1ZWU3ZDBjMDI4ZmNiOWNlMTIyNC5qcGeSlQMAzMrNBjbNA4CTBc0DFM0BvIGhMAE",
                "https://wokolmotoryzacji.pl/wp-content/uploads/2020/05/alfa-romeo-giulia-gtam-coupe-rendering.jpg",
                "https://images.unsplash.com/photo-1550355291-bbee04a92027?ixid=MXwxMjA3fDB8MHxzZWFyY2h8NHx8Y2FyfGVufDB8fDB8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60",
            };
            return dummyLinks[rnd.Next(dummyLinks.Count - 1)];
        }

    }

}
