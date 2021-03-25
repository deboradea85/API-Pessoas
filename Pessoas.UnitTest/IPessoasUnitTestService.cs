using Microsoft.AspNetCore.Mvc;
using Pessoas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pessoas.UnitTest
{
    public interface IPessoasUnitTestService
    {
        Task GetAsync();
        Task GetByCPFAsync();
        Task PostAsync();
        Task PutByCPFAsync();
        Task DeleteByCPFAsync();
    }
}
