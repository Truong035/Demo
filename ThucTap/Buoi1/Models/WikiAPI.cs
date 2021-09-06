using Dapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi1.Models
{
    public class WikiAPI: PageModel
    {

        private readonly IConfiguration _configuration;
        public WikiAPI(IConfiguration configuration)
        {

            _configuration = configuration;
        }
        public void OnGet()
        {
            string  st =_configuration.GetConnectionString("DefaultConnection");
            using (var connection = new SqlConnection(st))
            {
             connection.Open();
              var list=  connection.Query(@"select * from wiki_category").ToList();
                var cout = list.Count;
    
            }
        }
    }
}

