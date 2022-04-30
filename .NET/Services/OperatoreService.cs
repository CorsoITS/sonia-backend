using System.Security.Cryptography;
using System.Text;
using Esercizio.Models;
using Esercizio.Repositories;

namespace Esercizio.Services;

public class OperatoreService
{

    private OperatoreRepository operatoreRepository = new OperatoreRepository();

    public IEnumerable<Operatore> GetOperatori()
    {
        return operatoreRepository.GetOperatori();
    }

    public Operatore GetOperatore(int id)
    {
        return operatoreRepository.GetOperatore(id);
    }

    public string passwordHash(string text) 
    {
            var byteArray = ASCIIEncoding.ASCII.GetBytes(text);
            byte[] mySHA256 = SHA256.Create().ComputeHash(byteArray);
            return Convert.ToBase64String(mySHA256);
    }

    public bool Create(Operatore operatore)
    {
        if (operatoreRepository.GetOperatore(operatore.Id) == null)
        {
            if ((!String.IsNullOrEmpty(operatore.Nome)) & (operatore.Nome.Length > 0))
            {
                operatore.Password = passwordHash(operatore.Password);
                return operatoreRepository.Create(operatore);
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

    public bool Update(Operatore operatore)
    {
        return operatoreRepository.Update(operatore);
    }

    public bool Delete(int id)
    {
        return operatoreRepository.Delete(id);
    }

}