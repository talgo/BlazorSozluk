﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorSozluk.Common.Infrastructure.Results
{
    public class ValidationResponseModel
    {
        public IEnumerable<string> Errors { get; set; }

        public ValidationResponseModel(string message) : this(new List<string>() { message })
        {

        }

        public ValidationResponseModel(IEnumerable<string> errors)
        {
            Errors = errors;
        }

        [JsonIgnore]
        public string FlattenErrors => Errors is not null ? string.Join(Environment.NewLine, Errors) : string.Empty;
    }
}
