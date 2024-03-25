using System.IO;
using System.Threading.Tasks;

namespace NathanApp.Services
{
    public interface IImagePickerService
    {
        Task<Stream> PickImageAsync();
    }
}
