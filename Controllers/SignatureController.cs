//  ╬═════════╬ ***
//  ║░█░█░█░█░║ /dogukanzder
//  ║█░█░█░█░█║ ©2023
//  ╬═════════╬ ***

using eSignAPI.Interfaces;
using eSignAPI.Models;
using eSignAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using Signature = eSignAPI.Models.Signature;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eSignAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignatureController : ControllerBase
    {
        private readonly ISignatureService signatureService;

        public SignatureController(ISignatureService signatureService)
        {
            this.signatureService = signatureService;
        }

        // GET: api/<SignatureController>
        [HttpGet]
        [Authorize]
        public ActionResult<List<Signature>> Get()
        {
            try
            {
                return signatureService.GetAllSignature();
            }
            catch (Exception)
            {
                return NotFound();
            }
            
        }

        [Route("[action]")]
        [HttpPost]
        [Authorize]
        public ActionResult<List<Signature>> GetWithIds([FromBody] string[] ids) {
            try
            {
                return signatureService.GetSignaturesByIds(ids);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        // GET api/<SignatureController>/5
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Signature> Get(string id)
        {
            try
            {
                var signature = signatureService.GetSignatureById(id);

                if (signature == null)
                    return NotFound($"There is no signature with this id: {id}");

                return signature;
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        
        // POST api/<SignatureController>
        [HttpPost]
        [Authorize]
        public ActionResult<Signature> Post([FromBody] Signature signature)
        {
            try
            {
                signatureService.CreateSignature(signature);

                return CreatedAtAction(nameof(Get), new { id = signature.Id }, signature);
            }
            catch (Exception)
            {
                return NotFound();
            }


        }

        // PUT api/<SignatureController>/5
        [HttpPut("{id}")]
        [Authorize]
        public ActionResult<Signature> Put(string id, [FromBody] Signature signature)
        {
            try
            {
                var existingSignature = signatureService.GetSignatureById(id);

                if (existingSignature == null)
                    return NotFound($"There is no signature with this id: {id}");

                signatureService.UpdateSignature(id, signature);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        // DELETE api/<SignatureController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult<Signature> Delete(string id)
        {
            try
            {
                var signature = signatureService.GetSignatureById(id);

                if (signature == null)
                    return NotFound($"There is no signature with this id: {id}");

                signatureService.DeleteSignature(id);
                return Ok($"Signature deleted with this id: {id}");
            }
            catch (Exception)
            {
                return NotFound();
            }

        }
    }
}
