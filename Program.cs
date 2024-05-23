using HoneyRaesAPI.Models;

List<Customer> customers = new List<Customer>() {
        new Customer()
        {
            Id = 1,
            Name = "Acme Inc.",
            Address = "123 Main St, Anytown USA"
        },

        new Customer()
        {
            Id = 2,
            Name = "Globex Corp.",
            Address = "456 Oak Ave, Metropolis"
        },

        new Customer()
        {
            Id = 3,
            Name = "Stark Industries",
            Address = "789 Maple Ln, New York City"
        }
};
List<Employee> employees = new List<Employee> {

        new Employee()
            {
                Id = 1,
                Name = "John Doe",
                Specialty = "Software Development"
            },

        new Employee()
            {
                Id = 2,
                Name = "Jane Smith",
                Specialty = "Network Administration"
            }
    };
List<ServiceTicket> serviceTickets = new List<ServiceTicket>() {
        new ServiceTicket()
        {
            Id = 1,
            CustomerId = 1,
            EmployeeId = 1,
            Description = "Website is down",
            Emergency = true,
            DateCompleted = DateTime.Now
        },

        new ServiceTicket()
            {
                Id = 2,
                CustomerId = 2,
                EmployeeId = 2,
                Description = "Printer issue in office",
                Emergency = false,
                DateCompleted = DateTime.Now.AddDays(-2)
            },

        new ServiceTicket()
        {
            Id = 3,
            CustomerId = 3,
            EmployeeId = 1,
            Description = "Software update required",
            Emergency = false,
            DateCompleted = DateTime.Now.AddDays(-5)
        },

        new ServiceTicket()
        {
            Id = 4,
            CustomerId = 1,
            EmployeeId = 2,
            Description = "Network connectivity issues",
            Emergency = true,
            DateCompleted = DateTime.Now.AddDays(-1)
        },

        new ServiceTicket()
        {
            Id = 5,
            CustomerId = 2,
            EmployeeId = 1,
            Description = "New user account setup",
            Emergency = false,
            DateCompleted = DateTime.Now.AddDays(-3)
        }
};

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/servicetickets", () =>
{
    return serviceTickets.Select(t => new ServiceTicketDTO
    {
        Id = t.Id,
        CustomerId = t.CustomerId,
        EmployeeId = t.EmployeeId,
        Description = t.Description,
        Emergency = t.Emergency,
        DateCompleted = t.DateCompleted
    });
});

app.MapGet("/servicetickets/{id}", (int id) =>
{
    ServiceTicket serviceTicket = serviceTickets.FirstOrDefault(st => st.Id == id);
  
    return new ServiceTicketDTO
    {
        Id = serviceTicket.Id,
        CustomerId = serviceTicket.CustomerId,
        EmployeeId = serviceTicket.EmployeeId,
        Description = serviceTicket.Description,
        Emergency = serviceTicket.Emergency,
        DateCompleted = serviceTicket.DateCompleted
    };
});

app.Run();


