﻿using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

namespace Akeneo.Client
{
	public class AkeneoResponse
	{
		public HttpStatusCode Code { get; set; }
		public string Message { get; set; }

		[JsonProperty("_links")]
		public Dictionary<string, PaginationLink> Links { get; set; }
		public List<ValidationError> Errors { get; set; }

		public static AkeneoResponse Success(HttpStatusCode code, params KeyValuePair<string, PaginationLink>[] links)
		{
			return new AkeneoResponse
			{
				Code = code,
				Links = links?.ToDictionary(kvp => kvp.Key, kvp => kvp.Value)
			};
		}
	}

	public class ValidationError
	{
		public string Property { get; set; }
		public string Message { get; set; }
		public string Attribute { get; set; }
		public string Locale { get; set; }
		public string Scope { get; set; }
		public string Currency { get; set; }
	}
}
