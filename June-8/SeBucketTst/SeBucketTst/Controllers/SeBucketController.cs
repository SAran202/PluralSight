using Microsoft.AspNetCore.Mvc;
using SeBucketTst.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeBucketTst.Controllers
{
    [Produces("ApplicationException/Json")]
    [Route("Api/S3Bucket")]
    public class SeBucketController : Controller
    {
        private readonly IS3Service _service;
        public SeBucketController(IS3Service service)
        {
            _service = service;
        }
        [HttpPost("{bucketName}")]
        public async Task<IActionResult> CreateBucket([FromRoute] string bucketName)
        {
            var responce = await _service.CreateBucketAsync(bucketName);
            return Ok();
        }
    }
}
