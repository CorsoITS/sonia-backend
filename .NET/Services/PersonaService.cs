using Esercizio.Repositories;
using Esercizio.Models;

namespace Esercizio.Services;

public class PersonaService{

    private PersonaRepository personaRepository = new PersonaRepository();

    public IEnumerable<Persona> GetPeople(){
        return personaRepository.GetPeople();
    }

    public Persona GetPersona(int id){
        return personaRepository.GetPersona(id);
    }

    public bool Create(Persona persona){
        if (personaRepository.GetPersona(persona.id) == null){
            if (!String.IsNullOrEmpty(persona.nome) & persona.nome.Length > 0 & persona.cognome.Length > 0){
                return personaRepository.Create(persona);
            }
            else{
                return false;
            }
        }
        else{
            return false;
        }
    }

    public bool Update(Persona persona){
        return personaRepository.Update(persona);
    }

    public bool Delete(int id){
        return personaRepository.Delete(id);
    }
}