﻿using MoviesApi.Domain.Package;

namespace MoviesApi.Domain.Dtos.Response
{
    public class AddressViews : EntityBase
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
