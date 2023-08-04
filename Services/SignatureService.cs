//  ╬═════════╬ ***
//  ║░█░█░█░█░║ /dogukanzder
//  ║█░█░█░█░█║ ©2023
//  ╬═════════╬ ***

using eSignAPI.Interfaces;
using eSignAPI.Models;
using MongoDB.Driver;

namespace eSignAPI.Services
{
    public class SignatureService : ISignatureService
    {
        private readonly IMongoCollection<Signature> _signatures;

        public SignatureService(ISignatureDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _signatures = database.GetCollection<Signature>(settings.SignatureCollectionName);
        }

        

        public List<Signature> GetAllSignature()
        {
            return _signatures.Find(signature => true).ToList();
        }

        public Signature GetSignatureById(string id)
        {
            return _signatures.Find(signature => signature.Id == id).FirstOrDefault();
        }

        public List<Signature> GetSignaturesByIds(string[] ids)
        {
            List<Signature> signatureList = new();

            foreach (string id in ids)
            {
                signatureList.Add(_signatures.Find(signature => signature.Id == id).FirstOrDefault());
            }

            return signatureList;
        }

        public Signature CreateSignature(Signature signature)
        {
            _signatures.InsertOne(signature);
            return signature;
        }

        public bool UpdateSignature(string id, Signature signature)
        {
            _signatures.ReplaceOne(signature => signature.Id == id, signature);
            return true;
        }

        public bool DeleteSignature(string id)
        {
            _signatures.DeleteOne(signature => signature.Id == id);
            return true;
        }
    }
}
