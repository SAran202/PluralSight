using SeBucketTst.Models;
using System.Threading.Tasks;

namespace SeBucketTst.Services
{
    public interface IS3Service
    {
        Task<S3Response> CreateBucketAsync(string bucketName);
    }
}
