using Esercizio.Repositories;

namespace Esercizio.Service;

public class PersonaService
{

    private PersonaRepository personaRepository = new PersonaRepository();

    public IEnumerable<Persona> GetPeople()
    {
        return personaRepository.GetPeople();
    }

    public Persona GetPerson(int id)
    {
        return personaRepository.GetPerson(id);
    }

    public bool Create(Persona persona)
    {
        if (personaRepository.GetPerson(persona.Id) == null)
        {
            if (String.IsNullOrEmpty(persona.Nome))
            {
                return false;
            } 
            else if (persona.Nome.Length > 0) 
            {
                return false;
            }
            else
            {
                return personaRepository.Create(persona);
            }
            }
            else
            {
                return false;
            }

    }

    public bool Update(Persona persona)
    {
        return personaRepository.Update(persona);
    }

    public bool Delete(int id)
    {
        return personaRepository.Delete(id);
    }

}