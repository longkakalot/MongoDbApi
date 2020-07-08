using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMongoDb.Models;
using ApiMongoDb.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;

namespace ApiMongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhVienController : ControllerBase
    {
        private readonly SinhVienService _sinhVienContext;

        public SinhVienController(SinhVienService sinhVienContext)
        {
            _sinhVienContext = sinhVienContext;
        }

        [HttpGet]
        [Route("GetAll")]
        public List<SinhVien> GetAll()
        {
            return _sinhVienContext.GetAll();
        }

        [HttpGet]
        [Route("GetById")]
        public SinhVien GetById(string id)
        {
            return _sinhVienContext.GetById(id);
        }

        [HttpGet]
        [Route("GetSinhVienMath")]
        public List<SinhVien> GetSinhVienMath(string math, string viet)
        {
            return _sinhVienContext.GetSinhVienMath(math,viet);
        }

        [HttpPost]
        [Route("GetSinhVienMath1")]
        public List<SinhVien> GetSinhVienMath1(SinhVien sv)
        {
            return _sinhVienContext.GetSinhVienMath1(sv);
        }
    }
}