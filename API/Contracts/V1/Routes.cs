using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "V1";

        public const string Base = $"{Root}/{Version}";
        public static class Customer
        {
            public const string GetAll = Base + "/customers";
            public const string Create = Base + "/customers";
            public const string Get = Base + "/customers/{id}";
            public const string GetOrderByCustomer = Base + "/customers/{id}/orders";
        }

        public static class Order
        {
            public const string GetAll = Base + "/orders";
            public const string Create = Base + "/orders";
            public const string Get = Base + "/orders/{id}";
            public const string ConfirmOrder = Base + "/orders/{id}/confirm";
        }

        public static class Flight
        {
            public const string GetAll = Base + "/flights";
            public const string Create = Base + "/flights";
            public const string Get = Base + "/flights/{id}";
            public const string Search = Base + "/flights/search";

        }

        public static class Airport
        {
            public const string GetAll = Base + "/airports";
            public const string Create = Base + "/airports";
            public const string Get = Base + "/airports/{id}";

        }


    }
}
