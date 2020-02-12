using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OtpNet;
using TOTPProject.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotpController : ControllerBase
    {
        private Totp _totpManager;
        private DafaqModel dafaq;

        public TotpController()
        {
            _totpManager = new Totp(KeyGeneration.GenerateRandomKey());

            dafaq = new DafaqModel();
        }

        [HttpGet]
        public IActionResult OnGet()
        {
            //first test to verify right away
            dafaq.codeOne = _totpManager.ComputeTotp(DateTime.UtcNow);

            long hasBeenVerifiedBefore = 0;

            dafaq.totpTestOne = _totpManager.VerifyTotp(dafaq.codeOne, out hasBeenVerifiedBefore);

            dafaq.timesCodeOneBeenVerified = hasBeenVerifiedBefore;

            //create new code to be past into Post Method

            dafaq.codeTwo = _totpManager.ComputeTotp(DateTime.UtcNow);

            return Ok(dafaq);
        }

        [HttpPost]
        public IActionResult OnPost([FromBody]TotpModel input)
        {
            dafaq.codeTwo = input.code;

            long hasBeenVerifiedBefore = 0;

            dafaq.totpTestTwo = _totpManager.VerifyTotp(dafaq.codeTwo, out hasBeenVerifiedBefore);

            dafaq.timesCodeTwoBeenVerified = hasBeenVerifiedBefore;

            return Ok(dafaq);
        }
    }
}