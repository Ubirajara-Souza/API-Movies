﻿namespace UserApi.Domain.Entities
{
    public class TokenModel
    {
        public TokenModel(string value)
        {
            Value = value;
        }
        public string Value { get; }
    }
}
