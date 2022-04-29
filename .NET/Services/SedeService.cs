using Esercizio.Repositories;
using Esercizio.Models;

namespace Esercizio.Services;

public class SedeService{

    private SedeRepository sedeRepository = new SedeRepository();

    public IEnumerable<Sede> GetSedi(){
        return sedeRepository.GetSedi();
    }

    public Sede GetSede(int id){
        return sedeRepository.GetSede(id);
    }

    public bool Create(Sede sede){
        if (sedeRepository.GetSede(sede.id) == null){
            if (!String.IsNullOrEmpty(sede.nome) & sede.nome.Length > 0 & sede.citta.Length > 0 & sede.indirizzo.Length > 0){
                return sedeRepository.Create(sede);
            }
            else{
                return false;
            }
        }
        else{
            return false;
        }
    }

    public bool Update(Sede sede){
        return sedeRepository.Update(sede);
    }

    public bool Delete(int id){
        return sedeRepository.Delete(id);
    }
}