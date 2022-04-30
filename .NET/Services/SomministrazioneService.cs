using System.Security.Cryptography;
using System.Text;
using Esercizio.Models;
using Esercizio.Repositories;

namespace Esercizio.Services;

public class SomministrazioneService
{

    private SomministrazioneRepository somministrazioneRepository = new SomministrazioneRepository();

    public IEnumerable<Somministrazione> GetSomministrazioni()
    {
        return somministrazioneRepository.GetSomministrazioni();
    }

    public Somministrazione GetSomministrazione(int id)
    {
        return somministrazioneRepository.GetSomministrazione(id);
    }

    public bool Create(Somministrazione somministrazione)
    {
        if (somministrazioneRepository.GetSomministrazione(somministrazione.id) == null)
        {
            if (!String.IsNullOrEmpty(somministrazione.vaccino))
            {
                return somministrazioneRepository.Create(somministrazione);
            } 
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

    }

    public bool Update(Somministrazione somministrazione)
    {
        return somministrazioneRepository.Update(somministrazione);
    }

    public bool Delete(int id)
    {
        return somministrazioneRepository.Delete(id);
    }

}