//  ╬═════════╬ ***
//  ║░█░█░█░█░║ /dogukanzder
//  ║█░█░█░█░█║ ©2023
//  ╬═════════╬ ***

using eSignAPI.Models;

namespace eSignAPI.Interfaces
{
    public interface ISignatureService
    {
        List<Signature> GetAllSignature();
        Signature GetSignatureById(string id);
        List<Signature> GetSignaturesByIds(string[] ids);
        Signature CreateSignature(Signature signature);
        bool UpdateSignature(string id, Signature signature);
        bool DeleteSignature(string id);
    }
}
